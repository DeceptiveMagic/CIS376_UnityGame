using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dartController : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.forward * 50, ForceMode.Impulse);
        Destroy(gameObject, 2);//Destroy the projectile after 2 seconds of lifetime
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
