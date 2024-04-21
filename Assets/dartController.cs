using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dartController : MonoBehaviour
{
    Rigidbody rb;
    public int numCollisions;
    const int SPEED = 75;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.forward * 75, ForceMode.Impulse);
        Destroy(gameObject, 2);//Destroy the projectile after 2 seconds of lifetime
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        //https://forum.unity.com/threads/finding-object-by-name-if-part-of-a-name-string-something.413795/
        //TODO: Delete the dart if it collides with any balloon object
        //There is not String.contains() or String.startsWith() functions implemented
        //The link listed above mentions something about tags, but I couldn't implement them myself
        //As of now, only the balloons named with their colours are able to destroy the dart
        if (collision.gameObject.name.Contains("RedBalloon") || collision.gameObject.name.Contains("BlueBalloon") ||
         collision.gameObject.name.Contains("GreenBalloon") || collision.gameObject.name.Contains("YellowBalloon") ||
          collision.gameObject.name.Contains("PinkBalloon") || collision.gameObject.name.Contains("PurpleBalloon"))
        {
            //destroy the dart if it hits a balloon
            if (--numCollisions <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
