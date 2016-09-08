//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class FootstepManager : MonoBehaviour 
{
	[Header ("Footsteps System")]
	public List<GroundType> GroundTypes = new List<GroundType>();
	public FirstPersonController FPC;
	public string currentground;
	public bool CanRun;

	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		if (hit.transform.tag == "Concrete") {
			setGroundType (GroundTypes [2]);
		} else if (hit.transform.tag == "Dirt") {
			setGroundType (GroundTypes [1]);
		} else if (hit.transform.tag == "Wood") {
			setGroundType (GroundTypes [0]);
		}
	}

	public void setGroundType(GroundType ground)
	{
		if(currentground != ground.name)
		{
			//we need to change m_footstepsounds from private to public in FPC first
			FPC.m_FootstepSounds = ground.footstepsounds;
			FPC.m_WalkSpeed = ground.walkSpeed;
			FPC.m_RunSpeed = ground.runSpeed;
			currentground = ground.name;
			FPC.m_CanRun = ground.canRunHere;
			CanRun = ground.canRunHere;
		}
	}
}

[System.Serializable]
public class GroundType
{
	public string name;
	//you need at least 2 footstepsounds!
	public AudioClip[] footstepsounds;
	//here you can also add for example the jump and land sound
	public float walkSpeed = 5;
	public float runSpeed = 10;
	public bool canRunHere;
}