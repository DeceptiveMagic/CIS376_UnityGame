using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MonkeyAIScript : MonoBehaviour
{
    SphereCollider sphereCollider;
    Transform monkeyTransform;
    float timer;
    const float THROW_DELAY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        monkeyTransform = gameObject.transform;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }

    private void SpawnDart()
    {
        GameObject pb = Instantiate(Resources.Load("Dart") as GameObject);
        pb.transform.position = monkeyTransform.position;//match the palyer position
        pb.transform.rotation = monkeyTransform.rotation;//match the player rotation
        pb.transform.position += monkeyTransform.forward;//spawn 1 unit in front of the player
        pb.transform.position += monkeyTransform.up * 5;//spawn 5 units above the floor
        pb.GetComponent<dartController>().numCollisions = 3;
    }

    private void OnTriggerStay(Collider otherObject)
    {
        GameObject otherGameObject = otherObject.gameObject;
        // This is on the physics timer and not the regular timer.
        if (timer >= THROW_DELAY)
        {
            if (otherGameObject.name.Contains("Balloon"))
            {
                timer = 0;
                UnityEngine.Vector3 vectorToBalloon = otherGameObject.transform.position - monkeyTransform.position;
                UnityEngine.Vector3 rotationVector = UnityEngine.Vector3.RotateTowards(monkeyTransform.forward, vectorToBalloon, (float)Math.PI * 2, 10000);
                rotationVector.y = 0;
                monkeyTransform.rotation = UnityEngine.Quaternion.LookRotation(rotationVector);
                SpawnDart();
            }
        }
    }
}
