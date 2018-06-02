using UnityEngine;
using System.Collections;

public class SkyScript : MonoBehaviour {

	// script ottenuto dal tutorial al https://www.youtube.com/watch?v=h5GFoI38DOg

	private Material skyMat;
	private Skybox mySkyBox;
	private Light mainLight;


	public Transform stars;

	//qua sotto funzioni per settare graficamente il cielo
	public Gradient nightDayColour;

	public float maxIntensity = 3f;
	public float minIntensity = 0f;

	[Tooltip("per settare il punto dove il sole non ha più effetto sul mondo")]
	public float minPoint = -0.2f;

	public float minAmbientPoint = -0.2f;

	public float maxAmbient = 1f;
	public float minAmbient = 0f;

	public Gradient nightDayFogColour;
	public AnimationCurve fogDensityCurve;
	public float fogScale = 1f;

	public float dayAtmosphereThickness = 0.4f;
	public float nightAtmosphereThickness = 0.87f;

	public Vector3 dayRotateSpeed;
	public Vector3 nightRotateSpeed;

	public float timeScale= 1f;





	// Use this for initialization
	void Start () {
		skyMat = RenderSettings.skybox;
		mainLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		//si determina quanto impiega un giorno
		float tRange = 1 - minPoint;

		//prodotto scalare o dot product qua sotto.
		//si trova il rapporto scalare tra il vettore orizzontale della luce e il vettore verticale del mondo,
		//poi si sottrae il punto minimo di luce da noi arbitrariamente determinato e si divide per tRange
		//Il risultato risulta in due valori 1 e -1 che stabiliscono il punto più alto del sole e quello più basso.

		float dot = Mathf.Clamp01 ((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minAmbientPoint) / tRange);


		//si stabilisce l'intensità della luce
		float i = ((maxIntensity - minIntensity) * dot) + minIntensity;
		//e la si setta
		RenderSettings.ambientIntensity = i;


		mainLight.color = nightDayColour.Evaluate(dot);
		RenderSettings.ambientLight = mainLight.color;

		RenderSettings.fogColor = nightDayFogColour.Evaluate(dot);
		RenderSettings.fogDensity = fogDensityCurve.Evaluate(dot) * fogScale;

		i = ((dayAtmosphereThickness - nightAtmosphereThickness) * dot) + nightAtmosphereThickness;
		skyMat.SetFloat("_AtmosphereThickness", i);

		if (dot > 0 ) {
			transform.Rotate (dayRotateSpeed * Time.deltaTime * timeScale);

		} else {
			transform.Rotate (nightRotateSpeed * Time.deltaTime * timeScale);
		}

		stars.transform.rotation = transform.rotation;



	}

	public void playerHasRespawned () {
		transform.Rotate(Random.Range(1,359),0,0);
	}
}
