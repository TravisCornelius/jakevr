//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;

public class MouseSounds : MonoBehaviour {

	//SCRIPT USED FOR MAIN MENU MOUSE CLICK-HOVER SOUNDS.
	[Header ("Mouse Sounds")]
	public AudioClip hover;
	public AudioClip click;
	public float volume_sounds;

	public void PlayHover()
	{
		GetComponent<AudioSource>().PlayOneShot(hover, volume_sounds);
	}

	public void PlayClick()
	{
		GetComponent<AudioSource>().PlayOneShot(click, volume_sounds);
	}
}
