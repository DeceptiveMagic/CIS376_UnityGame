using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenBalloonController : MonoBehaviour
{
    public Transform[] points;
    int current;

//TODO change speed to not be public and set it to 15 before final, it is public for testing reasons
    public float speed;
    int hp = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != points[current].position){
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
        }
        else{
            current = (current + 1);
            if (current >= 15){
                //TODO decrement the lives counter by the amount of the remaining hp on the balloon
                //sk.decreaseLives(hp);
                Destroy(gameObject);
            }
        }
    }

//TODO: FIX ALL BALLOONS DYING IN ONE HIT, REGARDLESS OF hp
    void OnCollisionEnter(Collision collision){
        Debug.Log("Collided with " + collision.gameObject.name);
        if(collision.gameObject.name == "Dart(Clone)"){
            hp -= 1;
            //sk.increaseScore(1);
            if (hp <= 0){
                Destroy(gameObject);
            }
            if (hp == 1){
                //load red colour
                speed = 10.0f;
            }
            if (hp == 2){
                //load blue colour
                speed = 12.5f;
            }
        }
    }


}
