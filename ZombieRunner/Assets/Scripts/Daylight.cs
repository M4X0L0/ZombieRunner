using UnityEngine;
using System.Collections;

public class Daylight : MonoBehaviour {

	
	public Material[] skyBox;
	public float timeScale = 60;
	public Material provaskybox;
	public int morningMin;
	public int morningMax;
	public float dayMin;
	public float dayMax;
	public float nightMin;
	public float nightMax;
	public float quaternionRotationInHours;

	public float TimeOfTheDay = 0f;



	private Material skyBoxMaterial;
	private Light lux;
	private Camera cam;
	private Transform trans;
	public float dayInHours;


	// Use this for initialization
	void Start () {

		
		cam = GameObject.FindObjectOfType<Player>().GetComponentInChildren<Camera>();
		trans = GetComponent<Transform>();
		lux = GetComponent<Light>();


	}
	
	// Update is called once per frame
	void Update () {

		TimeOfTheDay = (trans.rotation.eulerAngles.x / 360);
		if (TimeOfTheDay >= 1f) {
			TimeOfTheDay = 0f;
		}		

		RotateSun();	

	}

	void RotateSun () {

		quaternionRotationInHours = Mathf.Abs(trans.rotation.x) * 24f;

		trans.Rotate(Vector3.left * Time.deltaTime / 360 * timeScale); // si dividono i secondi per gli angoli e li si moltiplica per il timescale

		dayInHours = trans.rotation.eulerAngles.x / 24;

//		if (trans.rotation.eulerAngles.x < morningMax || trans.eulerAngles.x > morningMin){
//			RenderSettings.skybox = skyBox[0];
//		} else if (trans.rotation.eulerAngles.x < dayMax || trans.eulerAngles.x > dayMin){
//			RenderSettings.skybox = skyBox[1];
//		} else if ((trans.rotation.eulerAngles.x < nightMax || trans.eulerAngles.x > nightMin)){ 
//			RenderSettings.skybox = skyBox[2];
//		}
	}
}
