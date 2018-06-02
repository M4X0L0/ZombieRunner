using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

	private Collider coll;
	private Radio radio;
	private Heli helicopter;

	public bool isAreaClear = true;
	public float timeToClearArea = 1f;
	public float timer = 0f;

	public GameObject landingArea;

	// Use this for initialization
	void Start () {
		coll = GetComponent<Collider>();
		helicopter = GameObject.FindObjectOfType<Heli>();
		radio = GameObject.FindObjectOfType<Radio>();
	}
	
	// Update is called once per frame
	void Update () {

		if (isAreaClear) {
			timer += Time.deltaTime;
			AreaCleared();
		}
	}

	void OnTriggerEnter (Collider coll) {

		Debug.Log("area non libera " + coll);
		isAreaClear = false;
		timer = 0f;

	}

	void AreaCleared () {

		if (timer >= timeToClearArea) {
			helicopter.Soccorso();
			radio.areaClear();
			isAreaClear = false;
			Invoke("spawnLandingArea", 3f);
		}
	}

	void OnTriggerExit (Collider coll) {
		


			isAreaClear = true;
		

	} 

	void spawnLandingArea () {
		Instantiate(landingArea, transform.position, transform.rotation);
		Debug.Log("instantiated landing area");

	}

		
	
}
