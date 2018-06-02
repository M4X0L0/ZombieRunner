using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	private Camera eyes;
	private float defaultFOV = 60f;
	private Player player;
	private TorchScript torch;


	private Heli heli;
	private Radio radio;

	public float zoomFOV = 30f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player>();
		eyes = GetComponent<Camera>();
		torch = GameObject.FindObjectOfType<TorchScript>();


		heli = GameObject.FindObjectOfType<Heli>();
		radio = GameObject.FindObjectOfType<Radio>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Zoom")) {
			eyes.fieldOfView = zoomFOV;
		  } else {
			eyes.fieldOfView = defaultFOV;
	  	}

	  	if (Input.GetButtonDown("CallHeli") && !heli.inBound) {
	  		radio.callHeli();
	  		heli.inBound = true;
	  	}

		if (Input.GetKeyDown(KeyCode.R)) {
			player.Respawn();


		}

		if (Input.GetKeyDown(KeyCode.X)) {
			radio.wHappened();


		}

		if (Input.GetButtonDown("Torcia")) {
			torch.torchOnOff();
		}

		if (Input.GetButtonDown("Interagisci") && heli.playerIsNearHeli)
		{
			//l'elicottero vola via e il giocatore viene salvato
			Debug.Log("il giocatore è salvo");
		}



	}









}
