using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private Rigidbody rigidbody;
    private bool clicked;
    private bool isTurning;

    private float turningTime;
    private float maxTurningTime;
    
    private float deltaTime;
    private float velX;

    // Use this for initialization
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        maxTurningTime = 1.5f;
        // rigidbody.AddForce(new Vector3(-350, 0, 0));
        init();
    }

    public void init() {
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
        rigidbody.position = new Vector3(startXPos, startYPos, 9);
        rigidbody.velocity = new Vector3(startXPos > 0 ? -velX : velX, 0, 0);
        isTurning = false;
        clicked = false;
    }

    public bool isClicked() {
           return clicked;
    }

    // Update is called once per frame
    void Update()
    {
        /* float dt = Time.smoothDeltaTime;

       
        transform.Translate(Vector3.forward * dt * 4);
  
        */
        if (isTurning) {
            turningTime += Time.deltaTime;
            if (turningTime > maxTurningTime) {
                isTurning = false;
            }
        }

        if (!clicked)
        {
            if ((rigidbody.position.x < -30 || rigidbody.position.x > 30) && !isTurning)
            {
                isTurning = true;
                rigidbody.velocity = new Vector3(-rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
                turningTime = 0;
            }
        } else {
                /* if (rigidbody.position.y < 2) {
                        rigidbody.velocity = new Vector3(-velX, rigidbody.velocity.y, rigidbody.velocity.z);
                }*/
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
        /* if (col.tag == "palmTree")
        {
            Debug.Log("palmTree detected");
            rigidbody.velocity = Vector3.zero;
            transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
        }*/
    }

    public void workingMode(int birdNumber) {
            rigidbody.velocity = Vector3.zero;
            rigidbody.position = new Vector3(rigidbody.position.x, rigidbody.position.y + birdNumber * 3, rigidbody.position.z);
            transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }

    public void flyOutOfScreen() {
            float randomSide = Random.Range(0, 100);
            float finalVelX = randomSide < 50 ? -velX : velX;
            rigidbody.velocity = new Vector3(finalVelX, 0, 0);
    }
}
