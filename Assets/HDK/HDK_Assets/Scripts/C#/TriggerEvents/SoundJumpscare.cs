//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class SoundJumpscare : MonoBehaviour {

	[Header ("Sound Jumpscare Settings")]
	private AudioSource audio_source; 				//The audio source to play the jumpscare clip
	public AudioClip JumpscareSound;				//The jumpscare sound
	public float JumpscareVolume;					//The jumpscare sound volume
	public bool deactivateColliderAfterCollision;	//Do you want to disable the Jumpscare after playing it one time?	
	float audio_lenght;								//The lenght of the jumpscare sound
	bool active;									//Is the Jumpscare actived?

	void Start()
	{
		audio_lenght = JumpscareSound.length;
		audio_source = this.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Player") {

			if (deactivateColliderAfterCollision) {
				gameObject.GetComponent<Collider> ().enabled = false;
			}

			if (!active) {
				audio_source.PlayOneShot (JumpscareSound, JumpscareVolume);
				active = true;
				StartCoroutine (DisableActived ());
			}
		}
	}

	IEnumerator DisableActived()
	{
		yield return new WaitForSeconds (audio_lenght);
		active = false;
	}
}
