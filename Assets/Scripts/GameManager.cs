using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject birdPrefab;

	private List<GameObject> birds;

	// Use this for initialization
	void Start () {
		birds = new List<GameObject>();
		for (int i = 0; i < 3; i++) {
			GameObject birdGO = (GameObject) GameObject.Instantiate(birdPrefab);
			birds.Add(birdGO);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
