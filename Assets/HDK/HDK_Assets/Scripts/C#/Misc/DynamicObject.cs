//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace UnityStandardAssets.Characters.FirstPerson
{
public class DynamicObject : MonoBehaviour { 
	
	[Header ("Object Type")]
	//You must not select both these two bool!
	public bool isDoor; //If is a door select this bool, if isn't a door select the below boolean called "Other"
	public bool Other;	//If isn't a door just select this bool! This will make the InfoText more generic!
	
	[Header ("Main Settings")]
	public GameObject doorChild; 	//The door body child of the door prefab.
	public GameObject audioChild; 	//The prefab's audio source GameObject, from which the sounds are played.	
	public AudioClip openSound; 	//The door opening sound effect (3D sound.)
	public AudioClip closeSound; 	//The door closing sound effect (3D sound.)	
	private bool doorOpen = false; 	//Bool used to check the state of the door, if it's open or not.
	GameObject DoorInfoGUI;
	GameObject Player;

	[Header ("Security")]
	public bool Jammed;
	public bool Locked;
	public bool Free;
	public AudioClip LockedSound;
	bool clicked;
	public bool wasLocked;

	void Start()
	{
		DoorInfoGUI = GameObject.Find ("DoorInfo");
		Player = GameObject.Find ("Player");
	}
	
	public void OpenDoor()
	{
		Free = true;
		Locked = false;
		wasLocked = true;
	}
	
	public void removeWasLocked()
	{
		wasLocked = false;
		Player.GetComponent<KeyManager> ().RemoveKey ();
	}

	public void doorOpenClose() {

	if (doorChild.GetComponent<Animation>().isPlaying == false) 
		{
			if (doorOpen == false) 
				{
				if (Player.GetComponent<FlashlightManager> ().usingFlashlight) 
				{
					Player.GetComponent<FlashlightManager> ().callOpenDoor ();
				} else
				{
					GameObject.Find ("NoItems_DoorOpen").GetComponent<Animation> ().Play ("OpenDoor", PlayMode.StopAll);
				}
				doorChild.GetComponent<Animation>().Play("Open");
				audioChild.GetComponent<AudioSource>().clip = openSound;
				audioChild.GetComponent<AudioSource>().Play();
				doorOpen = true;
				}
				else
				{
				if (Player.GetComponent<FlashlightManager> ().usingFlashlight) {
					Player.GetComponent<FlashlightManager> ().callOpenDoor ();
				} else
				{
					GameObject.Find ("NoItems_DoorOpen").GetComponent<Animation> ().Play ("OpenDoor", PlayMode.StopAll);
				}
				doorChild.GetComponent<Animation>().Play("Close");
				audioChild.GetComponent<AudioSource>().clip = closeSound;
				audioChild.GetComponent<AudioSource>().Play();
				doorOpen = false;
			}
		}
	}

	IEnumerator FadeOutInfo()
	{
		yield return new WaitForSeconds (2);
		DoorInfoGUI.GetComponent<UIFade> ().TextIn = false;
		DoorInfoGUI.GetComponent<UIFade> ().TextOut = true;
	}

	public void doorLocked()
	{
		audioChild.GetComponent<AudioSource>().clip = LockedSound;
		audioChild.GetComponent<AudioSource>().Play();
		if (isDoor) 
		{
		DoorInfoGUI.GetComponent<Text> ().text = "YOU NEED THE KEY TO OPEN THIS DOOR";
		}
		if(Other)
		{
			DoorInfoGUI.GetComponent<Text> ().text = "YOU NEED THE KEY TO OPEN THIS";
		}
		DoorInfoGUI.GetComponent<UIFade> ().TextIn = true;
		DoorInfoGUI.GetComponent<UIFade> ().TextOut = false;
		StartCoroutine (FadeOutInfo ());
	}

	public void doorJammed()
	{
		audioChild.GetComponent<AudioSource>().clip = LockedSound;
		audioChild.GetComponent<AudioSource>().Play();
		if (isDoor)
		{
			DoorInfoGUI.GetComponent<Text> ().text = "THIS DOOR IS JAMMED";
		} 
		if (Other)
		{
			DoorInfoGUI.GetComponent<Text> ().text = "THIS IS JAMMED";
		} 
		DoorInfoGUI.GetComponent<UIFade> ().TextIn = true;
		DoorInfoGUI.GetComponent<UIFade> ().TextOut = false;
		StartCoroutine (FadeOutInfo ());
	}
  }
}