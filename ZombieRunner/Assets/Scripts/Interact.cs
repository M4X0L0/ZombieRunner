using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	private PlayerInput playerInput;

	// Use this for initialization
	void Start () {

		playerInput = FindObjectOfType<PlayerInput>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider coll) {
		playerInput.InteractWithObject(gameObject);
	}
}
