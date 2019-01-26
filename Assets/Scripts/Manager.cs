using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public GameObject birdPrefab;
	public int maxBirds;

	private List<GameObject> birds;

	private Vector3 tempBirdPos; 

	// Use this for initialization
	void Start () {
		birds = new List<GameObject>();
		for (int i = 0; i < maxBirds; i++) {
			GameObject birdGO = (GameObject) GameObject.Instantiate(birdPrefab);
			birds.Add(birdGO);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < birds.Count; i++) {
			GameObject bird = birds[i];
			if (bird.GetComponent<Bird>().isClicked()){
				tempBirdPos = bird.GetComponent<Transform>().position;
				// Renderer tempRenderer = bird.GetComponent<Renderer>();
				MeshRenderer meshRend = bird.GetComponentInChildren<MeshRenderer>();
				// Debug.Log("is Clicked");
				if (!meshRend.isVisible) {
					Debug.Log("out of screen");
					bird.GetComponent<Bird>().init();
				}
			}
			
		}
	}
}
