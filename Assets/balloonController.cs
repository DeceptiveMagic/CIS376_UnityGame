using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonController : MonoBehaviour
{
    public enum BalloonColor
    {
        Pink,
        Yellow,
        Green,
        Blue,
        Red,
        Purple
    }
    public Transform[] points;
    public BalloonColor currentColor;
    int current = 0;
    float speed;
    int hp;
    Material red;
    Material blue;
    Material green;
    Material yellow;
    Material purple;
    Material pink;

    void Start()
    {
        red = Resources.Load("Red", typeof(Material)) as Material;
        blue = Resources.Load("Blue", typeof(Material)) as Material;
        green = Resources.Load("Green", typeof(Material)) as Material;
        yellow = Resources.Load("Yellow", typeof(Material)) as Material;
        purple = Resources.Load("Purple", typeof(Material)) as Material;
        pink = Resources.Load("Pink", typeof(Material)) as Material;

        switch(currentColor){
            case BalloonColor.Pink:
                hp = 5;
                speed = 20.0f;
                break;
            case BalloonColor.Yellow:
                hp = 4;
                speed = 17.5f;
                break;
            case BalloonColor.Green:
                hp = 3;
                speed = 15.0f;
                break;
            case BalloonColor.Blue:
                hp = 2;
                speed = 12.5f;
                break;
            default:
                hp = 1;
                speed = 10.0f;
                break;
        }
    }


    void Update()
    {
        if ((current >= 0 && current <= 14) && (transform.position != points[current].position)){
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



    void OnCollisionEnter(Collision collision){
        Debug.Log("Collided with " + collision.gameObject.name);
        if(collision.gameObject.name == "Dart(Clone)"){
            switch(currentColor){
                case BalloonColor.Pink:
                    gameObject.GetComponent<Renderer>().material = yellow;
                    currentColor = BalloonColor.Yellow;
                    hp = 4;
                    speed = 17.5f;
                    break;
                case BalloonColor.Yellow:
                    gameObject.GetComponent<Renderer>().material = green;
                    currentColor = BalloonColor.Green;
                    hp = 3;
                    speed = 15.0f;
                    break;
                case BalloonColor.Green:
                    gameObject.GetComponent<Renderer>().material = blue;
                    currentColor = BalloonColor.Blue;
                    hp = 2;
                    speed = 12.5f;
                    break;
                case BalloonColor.Blue:
                    gameObject.GetComponent<Renderer>().material = red;
                    currentColor = BalloonColor.Red;
                    hp = 1;
                    speed = 10.0f;
                    break;
                default:
                    Destroy(gameObject);
                    break;
            }
            //sk.increaseScore(1);
        }
    }
}

