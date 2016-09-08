//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour {

	[Header ("Inventory")]
	GameObject InventoryObject;
	GameObject ItemInfo;
	public bool open;
	bool fadeIn;
	bool fadeOut;

	[Header ("Items")]
	public bool hasFlashlight;
	public bool hasBatteries;
	public bool hasCamera;
	public bool hasKey;
	public float n_Batteries;
	public int n_Keys;

	[Header ("UI")]
	Text q_flashlight;
	Text q_batteries;
	Text q_cam;
	Text q_keys;
	public GameObject flashlight;
	public GameObject flashlight_batteries;
	public GameObject cam;
	public GameObject keys;

	GameObject Player;

	void Start()
	{
		open = false;
		InventoryObject = GameObject.Find ("Inventory");
		ItemInfo = GameObject.Find ("ItemsInfo");
		q_flashlight = GameObject.Find ("QuantityFlashlight").GetComponent<Text>();
		q_batteries = GameObject.Find ("QuantityBatteries").GetComponent<Text>();
		q_cam = GameObject.Find ("QuantityCam").GetComponent<Text>();
		q_keys = GameObject.Find ("QuantityKey").GetComponent<Text>();
		Player = GameObject.Find("Player");
	}

	void Update()
	{
		if (fadeIn) 
		{
			InventoryObject.GetComponent<CanvasGroup> ().alpha += Time.deltaTime*2;
			ItemInfo.GetComponent<CanvasGroup> ().alpha += Time.deltaTime*2;
		}

		if (fadeOut) 
		{
			InventoryObject.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime*2;
			ItemInfo.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime*2;
		}

		if (Input.GetKeyDown (KeyCode.I)) 
		{
				if (open) 
				{
					fadeOut = true;
					fadeIn = false;
					Player.GetComponent<FirstPersonController> ().enabled = true;
					open = false;
				}

				else if (!open) 
				{
					fadeOut = false;
					fadeIn = true;
					Player.GetComponent<FirstPersonController> ().enabled = false;
					open = true;
					Cursor.visible = true;
					Cursor.lockState = CursorLockMode.None;
				}
		}

		n_Batteries = Player.GetComponent<FlashlightManager> ().battery_quantity;
		n_Keys = Player.GetComponent<KeyManager> ().Keys;

		if (n_Batteries > 0) {
			hasBatteries = true;
			flashlight_batteries.GetComponent<Button> ().interactable = true;
			flashlight_batteries.GetComponent<UIFade> ().TextIn = true;
			flashlight_batteries.GetComponent<UIFade> ().TextOut = false;
			q_batteries.text = n_Batteries + " / 5";
		} else 
		{
			hasBatteries = false;
			q_batteries.text = "N / A";
			flashlight_batteries.GetComponent<Button> ().interactable = false;
			flashlight_batteries.GetComponent<UIFade> ().TextIn = false;
			flashlight_batteries.GetComponent<UIFade> ().TextOut = true;
		}

		if (Player.GetComponent<FlashlightManager> ().hasFlashlight) {
			hasFlashlight = true;
			flashlight.GetComponent<Button> ().interactable = true;
			flashlight.GetComponent<UIFade> ().TextIn = true;
			flashlight.GetComponent<UIFade> ().TextOut = false;
			q_flashlight.text = "1 / 1";
		} else 
		{
			hasFlashlight = false;
			q_flashlight.text = "N / A";
			flashlight.GetComponent<Button> ().interactable = false;
			flashlight.GetComponent<UIFade> ().TextIn = false;
			flashlight.GetComponent<UIFade> ().TextOut = true;
		}

		if (Player.GetComponent<CameraManager>().HasCamera) {
			hasCamera = true;
			cam.GetComponent<Button> ().interactable = true;
			cam.GetComponent<UIFade> ().TextIn = true;
			cam.GetComponent<UIFade> ().TextOut = false;
			q_cam.text = "1 / 1";
		} else 
		{
			hasCamera = false;
			q_cam.text = "N / A";
			cam.GetComponent<Button> ().interactable = false;
			cam.GetComponent<UIFade> ().TextIn = false;
			cam.GetComponent<UIFade> ().TextOut = true;
		}

		if (n_Keys > 0) {
			hasKey = true;
			keys.GetComponent<Button> ().interactable = true;
			keys.GetComponent<UIFade> ().TextIn = true;
			keys.GetComponent<UIFade> ().TextOut = false;
			q_keys.text = n_Keys.ToString("F0");
		} else 
		{
			hasKey = false;
			q_keys.text = "N / A";
			keys.GetComponent<Button> ().interactable = false;
			keys.GetComponent<UIFade> ().TextIn = false;
			keys.GetComponent<UIFade> ().TextOut = true;
		}
	}

	public void FadeInPanel(GameObject panel)
	{
		panel.GetComponent<UIFade> ().TextIn = true;
		panel.GetComponent<UIFade> ().TextOut = false;
		StartCoroutine (ShowOffPanel (panel));
	}

	public void FadeOutPanel(GameObject panel)
	{
		panel.GetComponent<UIFade> ().TextIn = false;
		panel.GetComponent<UIFade> ().TextOut = true;
	}

	IEnumerator ShowOffPanel(GameObject item_panel)
	{
		yield return new WaitForSeconds (3f);
		FadeOutPanel (item_panel);
	}
}