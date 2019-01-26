using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private Rigidbody rigidbody;
    private bool clicked;
    private float deltaTime;
    private bool changeDir;

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
        rigidbody.position = new Vector3(startXPos, startYPos, 4);
        rigidbody.velocity = new Vector3(startXPos > 0 ? -10 : 10, rigidbody.velocity.y, rigidbody.velocity.z);
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
                rigidbody.velocity = new Vector3(-rigidbody.velocity.x, rigidbody.velocity.z, rigidbody.velocity.z);
            }
        }
        // Debug.Log(deltaTime);
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);

    }

    void OnMouseDown()
    {
            clicked = true;
            rigidbody.velocity = new Vector3(0, -30, 0);
    }
}
