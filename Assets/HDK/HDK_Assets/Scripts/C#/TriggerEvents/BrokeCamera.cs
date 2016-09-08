//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.ImageEffects
{
public class BrokeCamera : MonoBehaviour {

	private GameObject Player;

	void Start () {
		Player = GameObject.Find ("Player");
	}

	void OnTriggerEnter(Collider col)
		{
			if (col.tag == "Player" && !Player.GetComponent<CameraManager>().broken && Player.GetComponent<CameraManager>().usingCam)  
		{
				Player.GetComponent<CameraManager> ().Broke = true;
		}
	}
  }
}