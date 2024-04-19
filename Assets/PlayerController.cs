using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform t;
    Rigidbody rb;
    float timeSinceLastFire;
    void Start()
    {
        t = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()//always use FixedUpdate if you have any kind of physics application
    {
        timeSinceLastFire += Time.fixedDeltaTime;
        float velocity = rb.velocity.magnitude;
        Vector3 move = new Vector3(0,0,0);
        
        float multiplier = 1.0f;
        if (Input.GetKey("left shift")){
            multiplier = 2.0f;
        }
        if (Input.GetKey("w")){
            move = t.forward * multiplier * Time.fixedDeltaTime * 100.0f;
        }
        if (Input.GetKey("s")){
            move = -t.forward * multiplier * Time.fixedDeltaTime * 100.0f;
        }
        if (Input.GetKey("a")){
            t.Rotate(-transform.up);
        }
        if (Input.GetKey("d")){
            t.Rotate(transform.up);
        }
        
        if (velocity < 10.0f){
            Debug.Log(move);
            rb.AddForce(move, ForceMode.Impulse);
        }



        
        if (Input.GetKey("space")){
            if (timeSinceLastFire >= 0.5){
                GameObject pb = Instantiate(Resources.Load("Dart") as GameObject);
                pb.transform.position = gameObject.transform.position;//match the palyer position
                pb.transform.rotation = gameObject.transform.rotation;//match the player rotation
                pb.transform.position += gameObject.transform.forward;//spawn 1 unit in front of the player
                pb.transform.position += gameObject.transform.up * 5;//spawn 5 units above the floor
                timeSinceLastFire = 0;
            }
        }
    }
}
