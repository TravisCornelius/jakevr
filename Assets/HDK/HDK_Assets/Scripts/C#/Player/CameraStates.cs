//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
public enum state { Idle, Walk, Run }

public class CameraStates : MonoBehaviour {

	[Header ("Camera Animations")]
	public state currentState = state.Idle;
	Animation Anim_Holder;
	FirstPersonController Player;

	void Start ()
	{
		Anim_Holder = GameObject.Find ("CamHolder").GetComponent<Animation> ();
		Player = GameObject.Find ("Player").GetComponent<FirstPersonController>();
	}

	void Update ()
	{
		if (currentState == state.Idle)
		{			
				Anim_Holder.CrossFade ("Camera_IdleBreath", 0.5f, PlayMode.StopAll);	
		}
		if (currentState == state.Walk)
		{			
				Anim_Holder.CrossFade ("Camera_Walk", 0.5f, PlayMode.StopAll);	
		}
		if (currentState == state.Run)
		{			
				Anim_Holder.CrossFade ("Camera_Run", 0.5f, PlayMode.StopAll);	
		}
		
		//THE THREE CASES:	ARE WE WALKING - RUNNING - IDLE
		if (Player.m_CharacterController.velocity.sqrMagnitude == 0)
		{
				currentState = state.Idle;
		}

		if (Player.isRunning && Player.m_CharacterController.velocity.sqrMagnitude > 0)
		{
				currentState = state.Run;
		}

		if (Player.isRunning && !Player.CanRun)
		{
			currentState = state.Walk;
		}
	
		if (!Player.isRunning && Player.m_CharacterController.velocity.sqrMagnitude > 0 )
		{
			currentState = state.Walk;
		}
	}
  }
}