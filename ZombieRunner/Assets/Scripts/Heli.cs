using UnityEngine;
using System.Collections;

public class Heli : MonoBehaviour {

	public bool playerIsNearHeli = false;
	public bool inBound = false;
//	private Rigidbody rb;


	// Use this for initialization
	void Start () {
//		rb = GetComponent<Rigidbody>();
	}

	public void Soccorso () {

//		rb.velocity = new Vector3 (0,0,20f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider coll) {

		if (coll.gameObject.tag == "playerTag") {
			Debug.Log ("player is near heli");
			playerIsNearHeli = true;
		}
	}

	void OnTriggerExit (Collider coll) {

		if (coll.gameObject.tag == "playerTag") {
			Debug.Log ("player far from heli");
			playerIsNearHeli = false;
		}
	}
}
