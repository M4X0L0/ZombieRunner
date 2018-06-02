using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private List<Transform> SpawnList;
	private Transform[] spawnPoints;
	private int selectSpawnPoint;
	private Vector3 selectedSpawnPoint;
	private SkyScript skyScript;

	// Use this for initialization

	void Start () {
		spawnPoints = GameObject.Find("Player Spawn Points").GetComponentsInChildren<Transform>();	//si trovano i transform dei spawnpoints e si inseriscono in un array
		skyScript = GameObject.FindObjectOfType<SkyScript>();
		Respawn();




	}



	public void Respawn () {										




		selectSpawnPoint = Random.Range(1,spawnPoints.Length);						// si sceglie a caso quale spawnpoint usare (parto dal numero 1, che allo 0 sta l'oggetto contenitore)
		skyScript.playerHasRespawned();



		this.transform.position = spawnPoints[selectSpawnPoint].position;				//il player viene spostato al spawnPoint selezionato


	


	}
	
	// Update is called once per frame
	void Update () {

		
	
	}
}
