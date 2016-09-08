//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace UnityStandardAssets.Characters.FirstPerson
{
public class FlashlightManager : MonoBehaviour {

	[Header ("Booleans")]						//THESE BOOLEANS WILL BECAME TRUE WHILE THE ANIMATION WITH THE NAME OF THE BOOL IS PLAYING.
		public bool IsWalk;
		public bool IsRun;
		public bool IsIdle;
		public bool IsDraw;
		public bool IsPutDown;
		public bool IsOpenDoor;
		public bool IsTakeObject;

	[Header ("Animations")]						//THESE STRINGS REPRESENT THE NAME OF THE ANIMATIONS CLIPS OF THE FLASHLIGHT
		public GameObject ArmsAnims;
		public string WalkName;
		public string RunName;
		public string IdleName;
		public string DrawName;
		public string PutDownName;
		public string OpenDoorName;
		public string PickupObjectName;

	[Header ("Flashlight Options")]				//THESE ARE GENERIC FLASHLIGHT OPTIONS.
		public float health;
		public float MaxHealth;
		public float battery_quantity;
		public Light lightSource;
		public AudioClip DrawSound;
		public AudioClip PutDownSound;
		public AudioClip ChangeBattery;
		public AudioClip NoBattery;
		public float volumeSound;
		AudioSource audio_source;
		float DrawLenght;
		float UnDrawLenght;
		float OpenDoorLenght;
		float TakeObjectLenght;
		public bool hasFlashlight;
		public bool usingFlashlight;
		public float speed;
		float duration = 0.2f;
		float baseIntensity;
		float alpha;
		public bool FlickeringMode;
		public bool one_battery;
		public bool two_battery;
		public bool three_battery;
		public bool four_battery;
		public bool five_battery;
		GameObject Player;
		GameObject NoItems_ObjectTake;
		bool WasNotCharge;

	[Header ("UI")]
		GameObject FlashlightUI;
		GameObject BatteryQuantity;
		GameObject InteractText;
		bool FadeUI;
		bool FadeInfoUI_Flashlight;
		bool FadeInfoUI_Battery;
		GameObject FlashlightInfoGUI;
		GameObject BatteryInfoGUI;	
		GameObject BatteryIcon;

	[Header("Battery UI")]
		Image _20percent;
		Image _40percent;
		Image _60percent;
		Image _80percent;
		Image _100percent;


	void Start ()
	{
		audio_source = this.GetComponent<AudioSource> ();	
		DrawLenght = ArmsAnims.GetComponent<Animation> ().GetClip (DrawName).length;
		UnDrawLenght = ArmsAnims.GetComponent<Animation> ().GetClip (PutDownName).length;
		TakeObjectLenght = ArmsAnims.GetComponent<Animation> ().GetClip (PickupObjectName).length;
		OpenDoorLenght = ArmsAnims.GetComponent<Animation> ().GetClip (OpenDoorName).length;
		baseIntensity = lightSource.intensity;
		Player = GameObject.Find("Player");
		NoItems_ObjectTake = GameObject.Find ("NoItems_ObjectTake");
		BatteryIcon = GameObject.Find ("BatteryIcon");
		FlashlightInfoGUI = GameObject.Find ("FlashlightInfos");
		BatteryInfoGUI = GameObject.Find ("BatteryInfos");
		FlashlightUI = GameObject.Find ("FlashlightUI");
		BatteryQuantity = GameObject.Find ("BatteryQuantity");
		InteractText = GameObject.Find ("Flashlight_text");
		_20percent = GameObject.Find ("20%").GetComponent<Image> ();
		_40percent = GameObject.Find ("40%").GetComponent<Image> ();
		_60percent = GameObject.Find ("60%").GetComponent<Image> ();
		_80percent = GameObject.Find ("80%").GetComponent<Image> ();
		_100percent = GameObject.Find ("100%").GetComponent<Image> ();
	}

	public void HasFlashlight()
	{
	InteractText.GetComponent<Text>().text = "FLASHLIGHT PICKED";
	FadeUI = true;
	FadeInfoUI_Flashlight = true;
	StartCoroutine (FadeOutText ());
	hasFlashlight = true;
	StartCoroutine(Draw ());
	if (usingFlashlight) {
			StartCoroutine (Pickup ());
	} else
	{
			NoItems_ObjectTake.GetComponent<Animation> ().Play ("TakeObject", PlayMode.StopAll);
	}
	}

	public void callOpenDoor()
	{
		StartCoroutine (OpenDoor ());
	}

	public void callPickupObject()
	{
		StartCoroutine (Pickup ());
	}

	IEnumerator OpenDoor()
	{
		IsOpenDoor = true;	
		yield return new WaitForSeconds (OpenDoorLenght - 0.85f);
		IsOpenDoor = false;
	}

	IEnumerator Pickup()
	{
		IsTakeObject = true;	
		yield return new WaitForSeconds (TakeObjectLenght  - 0.95f);
		IsTakeObject = false;
	}

	IEnumerator Draw()
	{
		IsDraw = true;
		ShowArms ();
		audio_source.PlayOneShot (DrawSound, volumeSound);		
		yield return new WaitForSeconds (DrawLenght - 0.35f);
		IsDraw = false;
		lightSource.enabled = true;
		if (FlickeringMode) {
			lightSource.gameObject.GetComponent<LightFlickerPulse> ().enabled = true;
		} else 
		{
			lightSource.gameObject.GetComponent<LightFlickerPulse> ().enabled = false;
		}
	}

	IEnumerator Putdown()
	{
		IsPutDown = true;
		StartCoroutine (CompletePutDown ());
		yield return new WaitForSeconds (1);
		lightSource.enabled = false;
		audio_source.PlayOneShot (PutDownSound, volumeSound);
		if (FlickeringMode) {
			lightSource.gameObject.GetComponent<LightFlickerPulse> ().enabled = false;
		}
	}
	
	IEnumerator CompletePutDown()
	{
		yield return new WaitForSeconds (UnDrawLenght);
		IsPutDown = false;
		ShowOffArms ();
	}

	void ShowArms()
	{
		ArmsAnims.SetActive (true);
	}

	void ShowOffArms()
	{
		ArmsAnims.SetActive (false);
	}

	IEnumerator FadeOutText()
	{
		yield return new WaitForSeconds (3);
		FadeUI = false;
		FadeInfoUI_Flashlight = false;
		FadeInfoUI_Battery = false;
	}

	public void AddBattery()
	{
			if (battery_quantity < 5) {
				battery_quantity += 1;
				InteractText.GetComponent<Text>().text = "BATTERY PICKED";
				FadeUI = true;
				FadeInfoUI_Battery = true;
				StartCoroutine (FadeOutText ());
				if (usingFlashlight) {
					StartCoroutine (Pickup ());
				} else {
					NoItems_ObjectTake.GetComponent<Animation> ().Play ("TakeObject", PlayMode.StopAll);
				}
			} else 
			{
				InteractText.GetComponent<Text>().text = "CAN'T TAKE OTHERS BATTERIES";
				FadeUI = true;
				StartCoroutine (FadeOutText ());
			}
	}			


	void Update () {


			if (FadeUI) 
			{
				InteractText.GetComponent<CanvasGroup> ().alpha += Time.deltaTime;			
			}
			else
			{
				InteractText.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
			}

			if (FadeInfoUI_Flashlight) 
			{
				FlashlightInfoGUI.GetComponent<CanvasGroup> ().alpha += Time.deltaTime;
			}
			else 
			{
				FlashlightInfoGUI.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
			}

			if (FadeInfoUI_Battery) 
			{
				BatteryInfoGUI.GetComponent<CanvasGroup> ().alpha += Time.deltaTime;
			}
			else 
			{
				BatteryInfoGUI.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
			}


			if (health == 0) 
			{
				_20percent.enabled = false;
				_40percent.enabled = false;
				_60percent.enabled = false;
				_80percent.enabled = false;
				_100percent.enabled = false;
			}
			else if (health <= 20) 		
			{
				_20percent.enabled = true;
				_40percent.enabled = false;
				_60percent.enabled = false;
				_80percent.enabled = false;
				_100percent.enabled = false;
			}
			else if (health <= 40 && health > 20) 		
			{
				_20percent.enabled = true;
				_40percent.enabled = true;
				_60percent.enabled = false;
				_80percent.enabled = false;
				_100percent.enabled = false;
			}
			else if (health <= 60 && health > 40) 		
			{
				_20percent.enabled = true;
				_40percent.enabled = true;
				_60percent.enabled = true;
				_80percent.enabled = false;
				_100percent.enabled = false;
			}
			else if (health <= 80 && health > 60) 		
			{
				_20percent.enabled = true;
				_40percent.enabled = true;
				_60percent.enabled = true;
				_80percent.enabled = true;
				_100percent.enabled = false;
			}
			else if (health <= 100 && health > 80) 		
			{
				_20percent.enabled = true;
				_40percent.enabled = true;
				_60percent.enabled = true;
				_80percent.enabled = true;
				_100percent.enabled = true;
			}

			if (battery_quantity == 1) 
			{
				one_battery = true;
				two_battery = false;
				three_battery = false;
				four_battery = false;
				five_battery = false;
			}
			if (battery_quantity == 2) 
			{
				one_battery = false;
				two_battery = true;
				three_battery = false;
				four_battery = false;
				five_battery = false;
			}
			if (battery_quantity == 3) 
			{
				one_battery = false;
				two_battery = false;
				three_battery = true;
				four_battery = false;
				five_battery = false;
			}
			if (battery_quantity == 4) 
			{
				one_battery = false;
				two_battery = false;
				three_battery = false;
				four_battery = true;
				five_battery = false;
			}
			if (battery_quantity == 5) 
			{
				one_battery = false;
				two_battery = false;
				three_battery = false;
				four_battery = false;
				five_battery = true;
			}

			if (!hasFlashlight) 
			{
				if(Input.GetKeyDown(KeyCode.F))
				{
					InteractText.GetComponent<Text> ().text = "YOU DON'T HAVE FLASHLIGHT";
					FadeUI = true;
					StartCoroutine (FadeOutText ());	
				}
			}

			if (usingFlashlight) 
			{
				if (FlickeringMode) 
				{
					if (health <= 25f) {
						lightSource.gameObject.GetComponent<LightFlickerPulse> ().enabled = false;
					} else 
					{
						lightSource.gameObject.GetComponent<LightFlickerPulse> ().enabled = true;
					}
				}
			}

			if (hasFlashlight)
			{
				FlashlightUI.GetComponent<UIFade> ().TextIn = true;
				FlashlightUI.GetComponent<UIFade> ().TextOut = false;
			}
			else 
			{
				FlashlightUI.GetComponent<UIFade> ().TextIn = false;
				FlashlightUI.GetComponent<UIFade> ().TextOut = true;
			}

			if (hasFlashlight) 
			{
				if (usingFlashlight) 
				{
					if (Input.GetKeyDown (KeyCode.Q)) 
					{
						if (battery_quantity > 0) {
							WasNotCharge = true;
						} else 
						{
							WasNotCharge = false;
						}
					}
				}
			}

			if (hasFlashlight) {
				if (usingFlashlight) {
					if (battery_quantity >= 1 && health <= 80) {
						if (Input.GetKeyDown (KeyCode.Q)) {
							battery_quantity -= 1;
							audio_source.PlayOneShot (ChangeBattery, volumeSound);
							health += 20f;
						}
					}
					if (battery_quantity == 0  && !WasNotCharge) {
						if (Input.GetKeyDown (KeyCode.Q)) {
							InteractText.GetComponent<Text> ().text = "YOU DON'T HAVE ANY BATTERY";
							FadeUI = true;
							StartCoroutine (FadeOutText ());
							audio_source.PlayOneShot (NoBattery, volumeSound);
						}
					}
				}
			}

			BatteryQuantity.GetComponent<Text>().text = battery_quantity + " / 5";

			if (lightSource.isActiveAndEnabled) {
				if (health > 0.0f) {
					health -= Time.deltaTime * speed;
				}
			}

			if(health < MaxHealth/4 && lightSource.enabled){ 
				float phi = Time.time / duration * 2 * Mathf.PI;
				float amplitude = Mathf.Cos( phi ) * (float)0.5 + baseIntensity;
				lightSource.GetComponent<Light>().intensity = amplitude + Random.Range(0.1f, 1.0f) ;
			}
			lightSource.GetComponent<Light>().color = new Color(alpha/MaxHealth, alpha/MaxHealth, alpha/MaxHealth, alpha/MaxHealth);
			alpha = health;  


			if (ArmsAnims.activeSelf)
			{
				usingFlashlight = true;
			}
			else
			{
				usingFlashlight = false;	
			}

			if (health < 20) {
				BatteryIcon.GetComponent<Image> ().color = Color.red;
			} else if (health >= 20) 
			{
				BatteryIcon.GetComponent<Image> ().color = Color.white;
			}


			if (health <= 0) 
			{
			health = 0;			
			}else if(health >= MaxHealth)
			{
				health  = MaxHealth;
			}

			if (battery_quantity >= 5) 
			{
				battery_quantity = 5;
			}
			if (battery_quantity <= 0) 
			{
				battery_quantity = 0;
			}

			if (hasFlashlight)
			{
				if (!IsDraw && !IsPutDown)
				{
					if (Input.GetKeyDown (KeyCode.F))
					{
						if (usingFlashlight) {
							StartCoroutine(Putdown());
						} else
						{
							StartCoroutine(Draw ());
						}
					}
				}
			}


		if(Player.GetComponent<FirstPersonController>().m_CharacterController.velocity.sqrMagnitude > 0)
		{
			IsWalk = true;
			IsIdle = false;
			IsRun = false;
			}else if (Player.GetComponent<FirstPersonController>().m_CharacterController.velocity.sqrMagnitude == 0)
		{
			IsWalk = false;
			IsRun = false;
			IsIdle = true;
		}

		if (Player.GetComponent<FirstPersonController> ().isRunning) {
			IsWalk = false;
			IsRun = true;
		} else 
		{
			IsRun = false;
		}

		if (Player.GetComponent<FirstPersonController> ().isRunning && !Player.GetComponent<FirstPersonController> ().CanRun)
		{
			IsWalk = true;
			IsRun = false;
			IsIdle = false;
		}

		if (IsWalk)
		{
			ArmsAnims.GetComponent<Animation> ().CrossFade (WalkName, 0.3f, PlayMode.StopAll);
			ArmsAnims.GetComponent<Animation> ().wrapMode = WrapMode.Loop;
		}
		if (IsRun) {
			ArmsAnims.GetComponent<Animation> ().CrossFade (RunName, 0.3f, PlayMode.StopAll);
			ArmsAnims.GetComponent<Animation> ().wrapMode = WrapMode.Loop;
		}
		if (IsIdle)
		{
			ArmsAnims.GetComponent<Animation> ().CrossFade (IdleName, 0.3f, PlayMode.StopAll);
			ArmsAnims.GetComponent<Animation> ().wrapMode = WrapMode.Loop;
		}
		if (IsDraw)
		{
			ArmsAnims.GetComponent<Animation> ().Play (DrawName, PlayMode.StopAll);
		}
		if (IsPutDown)
		{
			ArmsAnims.GetComponent<Animation> ().Play (PutDownName, PlayMode.StopAll);
		}
		if (IsTakeObject) 
		{
			
			ArmsAnims.GetComponent<Animation> ().Play (PickupObjectName, PlayMode.StopAll);
		}
		if (IsOpenDoor) 
		{
			ArmsAnims.GetComponent<Animation> ().Play (OpenDoorName, PlayMode.StopAll);
		}
		}
	}
}