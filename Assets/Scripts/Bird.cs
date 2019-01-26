using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private Rigidbody rigidbody;
    private bool clicked;
    private float deltaTime;
    private bool changeDir;

    private float velX;

    // Use this for initialization
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        // rigidbody.AddForce(new Vector3(-350, 0, 0));
        float randomSide = Random.Range(0, 100);
        float startXPos;
        if (randomSide < 50)
        {
            startXPos = -30;
        }
        else
        {
            startXPos = 30;
        }
        float startYPos = Random.Range(7, 12);
        velX = Random.Range(12, 20);
        rigidbody.position = new Vector3(startXPos, startYPos, rigidbody.position.z);
        rigidbody.velocity = new Vector3(startXPos > 0 ? -velX : velX, rigidbody.velocity.y, rigidbody.velocity.z);
        changeDir = false;
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        /* float dt = Time.smoothDeltaTime;

       
        transform.Translate(Vector3.forward * dt * 4);
  
        */

        if (!clicked)
        {
            if (rigidbody.position.x < -30 || rigidbody.position.x > 30)
            {
                rigidbody.velocity = new Vector3(-rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
            }
        }
        // Debug.Log(deltaTime);
        if (rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
        }


    }

    void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;
            rigidbody.velocity = new Vector3(0, -30, 0);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "palmTree")
        {
            Debug.Log("palmTree detected");
            rigidbody.velocity = Vector3.zero;
            transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
        }
    }
}
