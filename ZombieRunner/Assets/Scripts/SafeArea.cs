using UnityEngine;
using System.Collections;

public class SafeArea : MonoBehaviour {

	private Radio radio;
	private Player player;
	private Animator heliAnim;


	void Start () {
		player = GameObject.FindObjectOfType<Player>();
		radio = GameObject.FindObjectOfType<Radio>();
		heliAnim = GameObject.FindObjectOfType<Heli>().GetComponent<Animator>();
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.tag == "playerTag") {
			Debug.Log ("player entered Safe " +name);
			heliAnim.SetTrigger("flyTo"+name);
		}
	}

	//stabilire in che oggetto si entra
	//far partire l'animazione giusta


}
