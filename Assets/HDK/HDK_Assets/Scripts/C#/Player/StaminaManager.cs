//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
public class StaminaManager : MonoBehaviour 
{

	[Header ("Stamina Settings")]
	public float speedDecrease;
	public float speedIncrease;
	public float stamina;
	GameObject BarRect;
	FirstPersonController Player;

	void Start()
	{
		BarRect = GameObject.Find ("_Stamina");
		Player = GameObject.Find ("Player").GetComponent<FirstPersonController>();
	}

	void Update () 
	{
		BarRect.transform.localScale = new Vector3 (stamina, 1 , 1);

		if (Player.isRunning && Player.m_CanRun) {
			stamina -= Time.deltaTime * speedDecrease;
		} else 
		{
			stamina += Time.deltaTime * speedIncrease;
		}

		if (stamina <= 0) 
		{
			stamina = 0;
			Player.GetComponent<FirstPersonController> ().m_CanRun = false;
		}

		if (stamina >= 20 && GetComponent<FootstepManager>().CanRun) 
		{
			Player.m_CanRun = true;
		}

		if (stamina >= 100) 
		{
			stamina = 100;
		}

		if (Player.isRunning) {
			BarRect.GetComponentInParent<CanvasGroup> ().alpha += Time.deltaTime;
		} else 
		{
			BarRect.GetComponentInParent<CanvasGroup> ().alpha -= Time.deltaTime/3;
		}
	}
}
}