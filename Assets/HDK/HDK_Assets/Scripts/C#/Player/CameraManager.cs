//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace UnityStandardAssets.ImageEffects{
public class CameraManager : MonoBehaviour {

		[Header ("General Camera")]
		public GameObject CameraUI;
		GameObject mainCam;
		GameObject Player;
		GameObject CameraInfoGUI;
		ZoomCamera zoomScript;
		bool TakeCamera;
		public bool PutOutCamera;
		public AudioClip CameraOn;
		public AudioClip[] FoleySound;
		AudioSource audio_s;
		public GameObject anim;
		public float sounds_volume;
		public bool HasCamera;
		public bool usingCam;
		Text CameraPicked;
		public bool HasPickedText;
		public bool canUse;
		Animation NoItemsHands;

		[Header ("Broke Camera")]
		public bool Broke;
		public AudioClip broke_sound;
		public GameObject brokenGUI;
		public GlitchEffect camera_effect;
		public bool broken;

		void Start()
		{
			canUse = true;
			audio_s = GameObject.Find("SoundTelecamera").GetComponent<AudioSource> ();
			mainCam = GameObject.Find ("Camera");
			CameraPicked = GameObject.Find ("Camera_picked").GetComponent<Text>();
			Player = GameObject.Find("Player");
			CameraInfoGUI = GameObject.Find ("CameraInfos");
			zoomScript = mainCam.GetComponent<ZoomCamera> ();
			NoItemsHands = GameObject.Find ("NoItems_ObjectTake").GetComponent<Animation> ();
		}

		IEnumerator TakeCam()
		{
			anim.GetComponent<Animation> ().Play ("CamFoley", PlayMode.StopAll);
			audio_s.clip = FoleySound [Random.Range (0, FoleySound.Length)];
			audio_s.volume = sounds_volume;
			audio_s.Play ();
			yield return new WaitForSeconds (2.5f);
			audio_s.PlayOneShot (CameraOn, sounds_volume);
			zoomScript.enabled = true;
			CameraUI.SetActive (true);
			usingCam = true;
			mainCam.GetComponent<NoiseAndGrain> ().enabled = true;
			mainCam.GetComponent<VignetteAndChromaticAberration> ().intensity = 0.3f;
			mainCam.GetComponent<VignetteAndChromaticAberration> ().blur = 0.5f;
			mainCam.GetComponent<BloomOptimized> ().intensity = 0.3f;
			zoomScript.canZoom = true;
			if (broken)
			{
				brokenGUI.SetActive (true);
				mainCam.GetComponent<GlitchEffect> ().enabled = true;
				zoomScript.canZoom = false;
			}
		}

		IEnumerator PutDownCam()
		{			
			if (zoomScript.zoomed) {
				zoomScript.SendMessage ("CloseCamera");
			}
			zoomScript.canZoom = false;
			mainCam.GetComponent<Camera> ().fieldOfView = 60;
			anim.GetComponent<Animation> ().Play ("CamFoley", PlayMode.StopAll);
			audio_s.clip = FoleySound [Random.Range (0, FoleySound.Length)];
			audio_s.volume = sounds_volume;
			audio_s.Play ();
			yield return new WaitForSeconds (2.5f);
			usingCam = false;
			CameraUI.SetActive (false);
			mainCam.GetComponent<NoiseAndGrain> ().enabled = false;
			mainCam.GetComponent<VignetteAndChromaticAberration> ().intensity = 0.2f;
			mainCam.GetComponent<VignetteAndChromaticAberration> ().blur = 0.25f;
			mainCam.GetComponent<BloomOptimized> ().intensity = 0.15f;
			if (broken)
			{
				brokenGUI.SetActive (false);
				mainCam.GetComponent<GlitchEffect> ().enabled = false;
				zoomScript.enabled = false;
			}
		}

		public void Pickup()
		{
			if (Player.GetComponent<FlashlightManager> ().usingFlashlight)
			{
				Player.GetComponent<FlashlightManager> ().SendMessage ("callPickupObject");				
				
			} else if (!Player.GetComponent<FlashlightManager> ().usingFlashlight) 
			{
				NoItemsHands.Play ("TakeObject", PlayMode.StopAll);						
			}
		}

		IEnumerator ShowOffKeyText()
		{
			yield return new WaitForSeconds (3);
			HasPickedText = false;
		}

		public void ShowPickedText()
		{
			HasPickedText = true;
		}

		void Update () {

			if (HasPickedText) {
				CameraPicked.GetComponent<CanvasGroup> ().alpha += Time.deltaTime;
				CameraInfoGUI.GetComponent<CanvasGroup> ().alpha += Time.deltaTime;
				StartCoroutine (ShowOffKeyText ());
			} else
			{
				CameraPicked.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
				CameraInfoGUI.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
			}

			if (Broke) {
				broken = true;
				Broke = false;
				audio_s.PlayOneShot (broke_sound, sounds_volume);
				brokenGUI.SetActive (true);
				camera_effect.enabled = true;
				if (zoomScript.zoomed) 
				{
					zoomScript.SendMessage ("Broken");	
				}
			}

			if (TakeCamera) 
			{
				TakeCamera = false;
				StartCoroutine(TakeCam ());
			}

			if (PutOutCamera) 
			{
				PutOutCamera = false;
				StartCoroutine(PutDownCam());
			}

			if (HasCamera && canUse) 
			{
				if(Input.GetKey(KeyCode.C))
				{
					if (!usingCam && !anim.GetComponent<Animation> ().IsPlaying ("CamFoley"))
					{
						TakeCamera = true;
					}
					if (usingCam && !anim.GetComponent<Animation> ().IsPlaying ("CamFoley"))
					{
						PutOutCamera = true;
					}

				}	
			}
		}
  	}
}