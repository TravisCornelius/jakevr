//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace UnityStandardAssets.Characters.FirstPerson
{
public class KeyManager : MonoBehaviour {

	[Header ("Key Management")]
	public bool HasKey;
	public bool HasKeyText;
	public int Keys;
	public Text KeyText;
	GameObject Player;
	Animation HandsAnimation;

	void Start ()
	{
		Player = GameObject.Find ("Player");
		HandsAnimation = GameObject.Find ("NoItems_ObjectTake").GetComponent<Animation> ();
	}

	void Update ()
	{	
		if (Keys > 0) {
			HasKey = true;
		} else 
		{
			HasKey = false;
		}

		if (HasKeyText) {
			KeyText.GetComponent<CanvasGroup> ().alpha += Time.deltaTime;
			StartCoroutine (ShowOffKeyText ());
		} else
		{
			KeyText.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
		}
	}

	public void AddKey()
	{
		HasKeyText = true;
		Keys += 1;

		if (Player.GetComponent<FlashlightManager> ().usingFlashlight) {
			Player.GetComponent<FlashlightManager> ().callPickupObject ();
		} else
		{
			HandsAnimation.Play ("TakeObject", PlayMode.StopAll);
		}
	}

	public void RemoveKey()
	{
		Keys -= 1;
	}

	IEnumerator ShowOffKeyText()
	{
		yield return new WaitForSeconds (3);
		HasKeyText = false;
	}
  }
}