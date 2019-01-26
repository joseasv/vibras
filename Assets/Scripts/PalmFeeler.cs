using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmFeeler : MonoBehaviour {


	private int birdCount;
	private int maxBirdCount;
	public int maxLeaves;
	public int leavesCount;
	private float rotationY;
	public bool completed;

	private List<GameObject> birdsInPlace;

	private float time;
	// Use this for initialization
	void Start () {
		birdCount = 0;
		maxBirdCount = 2;
		birdsInPlace = new List<GameObject>();
		maxLeaves = Random.Range(3, 5);
		rotationY = 360 / maxLeaves;
		leavesCount= 0;
		completed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (birdCount > 0 && !completed){

			time += Time.deltaTime * birdCount;

			if (time > 10) {
				Debug.Log("10 seconds passed");
				Debug.Log("instantiate at rotation " + rotationY);
				birdCount = 0;
				leavesCount++;
				time = 0;
				freeBirds();

				if (leavesCount >= maxLeaves) {
					Debug.Log("finish palm");
					completed = true;
				}
			}
			
		}
	}

	public bool isCompleted() {
		return leavesCount >= maxLeaves;
	}

	private void freeBirds() {
		for (int i = 0; i < birdsInPlace.Count; i++) {
			GameObject bird = birdsInPlace[i];
			bird.GetComponent<Bird>().flyOutOfScreen();
		}

		birdsInPlace.Clear();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "bird" && birdCount < maxBirdCount) {
			Debug.Log("detected bird");
			birdCount++;
			birdsInPlace.Add(other.gameObject);
			other.gameObject.GetComponent<Bird>().workingMode(birdCount);
		}
	}
}
