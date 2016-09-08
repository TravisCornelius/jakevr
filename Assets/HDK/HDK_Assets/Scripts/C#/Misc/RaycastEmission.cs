//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;

public class RaycastEmission : MonoBehaviour {

	[Header ("Raycast Highlight")]
	public bool rayed;				//Do you raycasted the object?
	GameObject mesh;				//The mesh of the object
	public Material normal_mat;		//The normal material of the object	
	public Material raycasted_mat;	//The Highlighted material of the object

	void Start()
	{
		mesh = this.gameObject;
	}

	void Update () {
	
		if (rayed) 
		{
			mesh.GetComponent<MeshRenderer> ().material = raycasted_mat;
		} else 
		{
			mesh.GetComponent<MeshRenderer> ().material = normal_mat;
		}

	}
}
