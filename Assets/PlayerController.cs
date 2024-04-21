using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Transform playerTransform;
    Vector3 cameraRotation;
    LevelIncrementLogic levelManager;
    int numDartCollisions = 1;
    float delayToFire;
    float timeSinceLastFire;
    float forwardSpeed;
    float lateralSpeed;
    bool noForward;
    bool noBackward;
    bool noLeft;
    bool noRight;
    const float MOVEMENT_SPEED_INCREMENT = 120f;
    const float MOVEMENT_SPEED_CAP = 2000f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerTransform = gameObject.transform;
        controller = gameObject.GetComponent<CharacterController>();
        levelManager = GameObject.Find("MetaLogicManager").GetComponent<LevelIncrementLogic>();
        timeSinceLastFire = 1;
        delayToFire = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t")) {
            numDartCollisions = 1;
            timeSinceLastFire = 1;
            delayToFire = 1.5f;
            textManager.resetGame();
            levelManager.resetGame();
        }
        timeSinceLastFire += Time.deltaTime;
        // If left shift, then 2.0, else 1.0.
        float multiplier = Input.GetKey("left shift") ? 1.2f : 1.0f;

        // First, apply movementransform.
        if (Input.GetKey("w"))
        {
            forwardSpeed += MOVEMENT_SPEED_INCREMENT * multiplier * Time.deltaTime;
        }
        else
        {
            noForward = true;
        }
        if (Input.GetKey("s"))
        {
            forwardSpeed -= MOVEMENT_SPEED_INCREMENT * multiplier * Time.deltaTime;
        }
        else
        {
            noBackward = true;
        }
        // Could be the wrong direction, we'll see.
        if (Input.GetKey("a"))
        {
            lateralSpeed -= MOVEMENT_SPEED_INCREMENT * multiplier * Time.deltaTime;
        }
        else
        {
            noLeft = true;
        }
        if (Input.GetKey("d"))
        {
            lateralSpeed += MOVEMENT_SPEED_INCREMENT * multiplier * Time.deltaTime;
        }
        else
        {
            noRight = true;
        }

        // Next, apply decay to give the sense of physics without the baggage.
        multiplier = 0.5f;
        if (noForward && noBackward)
        {
            if (forwardSpeed > 0)
            {
                forwardSpeed -= MOVEMENT_SPEED_INCREMENT * multiplier * Time.deltaTime;
                Mathf.Clamp(forwardSpeed, 0, MOVEMENT_SPEED_CAP);
            }
            else if (forwardSpeed < 0)
            {
                forwardSpeed += MOVEMENT_SPEED_INCREMENT * multiplier * Time.deltaTime;
                Mathf.Clamp(forwardSpeed, -MOVEMENT_SPEED_CAP, 0);
            }
        }

        if (noLeft && noRight)
        {
            if (lateralSpeed > 0)
            {
                lateralSpeed -= MOVEMENT_SPEED_INCREMENT * multiplier * Time.deltaTime;
                Mathf.Clamp(lateralSpeed, 0, MOVEMENT_SPEED_CAP);
            }
            else if (lateralSpeed < 0)
            {
                lateralSpeed += MOVEMENT_SPEED_INCREMENT * multiplier * Time.deltaTime;
                Mathf.Clamp(lateralSpeed, -MOVEMENT_SPEED_CAP, 0);
            }
        }

        // Restrict maximum values;
        Mathf.Clamp(forwardSpeed, -MOVEMENT_SPEED_CAP, MOVEMENT_SPEED_CAP);
        Mathf.Clamp(lateralSpeed, -MOVEMENT_SPEED_CAP, MOVEMENT_SPEED_CAP);

        // Camera Movement:
        playerTransform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

        // Apply to transform instead of as physics.
        Vector3 translation = new Vector3(lateralSpeed, 0, forwardSpeed);
        controller.SimpleMove(playerTransform.TransformDirection(translation));

        if (Input.GetMouseButton(0) && textManager.livesRemaining() > 0)
        {
            if (timeSinceLastFire >= delayToFire)
            {
                GameObject pb = Instantiate(Resources.Load("Dart") as GameObject);
                pb.transform.position = gameObject.transform.position;//match the palyer position
                pb.transform.rotation = gameObject.transform.rotation;//match the player rotation
                pb.transform.position += gameObject.transform.forward;//spawn 1 unit in front of the player
                pb.transform.position += gameObject.transform.up * 5;//spawn 5 units above the floor
                pb.GetComponent<dartController>().numCollisions = numDartCollisions;
                timeSinceLastFire = 0;
            }
        }

        // Buy upgrades
        if (Input.GetMouseButtonDown(1)) {
            if (textManager.getMoney() >= textManager.getCurrentCost()) {
                textManager.buyUpgrade();
                delayToFire /= 1.25f;
                ++numDartCollisions;
            }
        }
    }

    void FixedUpdate()
    {

    }
}