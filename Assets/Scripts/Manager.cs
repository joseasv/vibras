using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject birdPrefab;
    public int maxBirds;

    private bool gameCompleted;

    public GameObject palmTreesGO;

    private List<GameObject> birds;
    private List<GameObject> palmTrees;

    private Vector3 tempBirdPos;

	private Vector3 camTargetPos;

	public Camera mainCamera;
	private Vector3 camInitPos;

    // Use this for initialization
    void Start()
    {
		camInitPos = mainCamera.GetComponent<Transform>().position;
		camTargetPos = new Vector3(camInitPos.x, camInitPos.y, -20);
        gameCompleted = false;

        birds = new List<GameObject>();
        for (int i = 0; i < maxBirds; i++)
        {
            GameObject birdGO = (GameObject)GameObject.Instantiate(birdPrefab);
            birds.Add(birdGO);
        }

        palmTrees = new List<GameObject>();
        for (int i = 0; i < palmTreesGO.transform.childCount; i++)
        {
            GameObject palmTree = palmTreesGO.transform.GetChild(i).gameObject;
            palmTrees.Add(palmTree);
        }

        Debug.Log("palmtree count " + palmTrees.Count + " and " + palmTreesGO.transform.childCount);

    }

    // Update is called once per frame
    void Update()
    {

        if (!gameCompleted)
        {
            // Checking birds for reuse
            for (int i = 0; i < birds.Count; i++)
            {
                GameObject bird = birds[i];
                if (bird.GetComponent<Bird>().isClicked())
                {
                    tempBirdPos = bird.GetComponent<Transform>().position;
                    // Renderer tempRenderer = bird.GetComponent<Renderer>();
                    MeshRenderer meshRend = bird.GetComponentInChildren<MeshRenderer>();
                    // Debug.Log("is Clicked");
                    if (!meshRend.isVisible)
                    {
                        Debug.Log("out of screen");
                        bird.GetComponent<Bird>().init();
                    }
                }
            }

            // Checking palm trees for game completion
            int completedCount = 0;
            for (int i = 0; i < palmTrees.Count; i++)
            {
                GameObject palmTree = palmTrees[i];
                if (palmTree.GetComponent<PalmFeeler>().isCompleted())
                {
                    completedCount++;
                }
            }

            if (completedCount == palmTrees.Count)
            {
                Debug.Log("game completed");
				gameCompleted = true;
				
            }
        } else {
			// this.camera.position
			// Debug.Log("moving camera");
		
			// mainCamera.GetComponent<Transform>().position = Vector3.Lerp(camInitPos, camTargetPos, 100);
			StartCoroutine(moveCamera());
		}

    }

	private IEnumerator moveCamera() {
		float startTime = Time.time;

		float journeyLength = Vector3.Distance(camInitPos, camTargetPos);

		while(mainCamera.GetComponent<Transform>().position != camTargetPos) {
			// Distance moved = time * speed.
			float distCovered = (Time.time - startTime) * 5;

			// Fraction of journey completed = current distance divided by total distance.
			float fracJourney = distCovered / journeyLength;

			// Set our position as a fraction of the distance between the markers.
			mainCamera.GetComponent<Transform>().position = Vector3.Lerp(camInitPos, camTargetPos, fracJourney);
			
			yield return null;
		}

		Debug.Log("end cam movement");

	}
	
}
