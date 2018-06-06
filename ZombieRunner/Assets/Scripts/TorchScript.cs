using UnityEngine;
using System.Collections;

public class TorchScript : MonoBehaviour {

	public bool isTorchOn = false;
	private Light torchLight;

	// Use this for initialization
	void Start () {
		torchLight = GetComponent<Light>();
		torchLight.enabled = false;
	}


	public void torchOnOff () {
		if (!isTorchOn) {
			torchLight.enabled = true;
			isTorchOn = true;
		} else if (isTorchOn) {
			torchLight.enabled = false;
			isTorchOn = false;
			}
		
	}
	



}
