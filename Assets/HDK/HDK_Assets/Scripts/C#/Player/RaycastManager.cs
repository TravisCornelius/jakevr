//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

namespace UnityStandardAssets.Characters.FirstPerson
{
public class RaycastManager : MonoBehaviour {

	[Header ("Crosshairs")]
	public GameObject normal_Crosshair;
	public GameObject interact_Crosshair;
	
	[Header ("Raycast")]
	RaycastHit hit;
	public float distance = 2.0f;
	public LayerMask layerMaskInteract;
	
	[Header ("Tags")]
	string KeyTag = "Key";
	string FlashlightTag = "Flashlight";
	string FlashlightBatteryTag = "FlashlightBattery";
	string DoorTag = "Door";
	string PaperTag = "Paper";
	string TelecameraTag = "Telecamera";
	string LampTag = "Lamp";
	string ExamineTag = "Examine";

	[Header ("SFX")]
	public AudioClip[] KeyPickup;
	public AudioClip[] GeneralPickup;
	public AudioClip[] PaperPickup;
	public AudioClip[] ExaminedReveal;
	public AudioClip CantPickup;
	public float pickupVolume;
	public float revealVolume;
	
	[Header ("Tags Booleans")]
	bool OnTagKey;
	bool OnTagFlashlight;
	bool OnTagFlashlightBattery;
	bool OnTagDoor;
	bool OnTagPaper;
	bool OnTagTelecamera;
	bool OnTagLamp;
	bool OnTagExamine;

	[Header ("Other")]
	GameObject Player;					//Player GameObject
	GameObject targetDoor;				//The target door/drawer...
	bool hasFlashlight;					//Do we have the flashlight?
	GameObject doorRaycasted;			//The Door/Drawer... raycasted
	GameObject targetPaperNote;			//The target paper note
	GameObject raycasted_obj;			//The item raycasted
	GameObject RaycastedLamp;			//The raycasted functional lamp
	GameObject RaycastedExamineObj;		//The raycasted examinable item
	bool ExaminingObject;				//Are we examining an item
	GameObject ExamineObjectInfoGUI;	//The Examine Object Info GUI
	bool ShowExaminingInfoGui;			//Do we need to show the Examine Object Info GUI
	public float RevealWait;			//The time we need to wait for the item to be revealed after the examination
	GameObject InteractObjectInfoGUI;	//The Interact Object Infos GUI
	GameObject ItemNameText;			//The text that shows us the name of the item
	bool FadeInteractInfoGUI;			//Do we need to fade the Interact Info GUI?

	void Start()
	{
		Player = GameObject.Find("Player");
		ExaminingObject = false;
		ExamineObjectInfoGUI = GameObject.Find ("ExamineObjectInfos");
		InteractObjectInfoGUI = GameObject.Find ("InteractInfo");
		ItemNameText = GameObject.Find ("ItemName");
	}	

	IEnumerator RevealExamined()
	{
		yield return new WaitForSeconds (RevealWait);
			if (ExaminingObject) {
				ItemNameText.GetComponent<Text> ().text = RaycastedExamineObj.GetComponent<InteractObject> ().ItemName;
				RaycastedExamineObj.GetComponent<InteractObject> ().Examined = true;
				this.GetComponent<AudioSource> ().clip = ExaminedReveal [Random.Range (0, ExaminedReveal.Length)];
				this.GetComponent<AudioSource> ().volume = revealVolume;
				this.GetComponent<AudioSource> ().Play ();
				FadeInteractInfoGUI = true;
			}
	}

	void Update() {

			if (FadeInteractInfoGUI) {
				InteractObjectInfoGUI.GetComponent<CanvasGroup> ().alpha += Time.deltaTime;
				ItemNameText.GetComponent<CanvasGroup> ().alpha += Time.deltaTime*2;
			} else 
			{
				InteractObjectInfoGUI.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
				if (!ExaminingObject) {
					ItemNameText.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
				}
			}

		if (ShowExaminingInfoGui) {
			ExamineObjectInfoGUI.GetComponent<CanvasGroup> ().alpha += Time.deltaTime;
		} else 
		{
			ExamineObjectInfoGUI.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
		}

		Vector3 position = transform.parent.position;
		Vector3 direction = transform.TransformDirection(Vector3.forward);

			if (Physics.Raycast (position, direction, out hit, distance, layerMaskInteract.value)) {
				if (hit.transform.gameObject.GetComponent<InteractObject> ()) {
					raycasted_obj = hit.transform.gameObject;
					if (raycasted_obj.GetComponent<RaycastEmission> ()) 
					{
						raycasted_obj.GetComponent<RaycastEmission> ().rayed = true;
					}else if(!raycasted_obj.GetComponent<RaycastEmission>() && raycasted_obj.GetComponentInChildren<Light>() && !raycasted_obj.GetComponent<NoEmission>())
					{
						raycasted_obj.GetComponentInChildren<Light> ().enabled = true;
					}
					normal_Crosshair.SetActive (false);
					interact_Crosshair.SetActive (true);
					FadeInteractInfoGUI = true;
					if (raycasted_obj.GetComponent<InteractObject> ().Examined) {
						ItemNameText.GetComponent<Text> ().text = raycasted_obj.GetComponent<InteractObject> ().ItemName;
					} else 
					{
						ItemNameText.GetComponent<Text> ().text = null;
					}
				}
			}
			else
			{
				if (raycasted_obj != null) {
					if (raycasted_obj.GetComponent<RaycastEmission> ()) {
						raycasted_obj.GetComponent<RaycastEmission> ().rayed = false;
					} else if (!raycasted_obj.GetComponent<RaycastEmission> () && raycasted_obj.GetComponentInChildren<Light> () && !raycasted_obj.GetComponent<NoEmission>()) {
						raycasted_obj.GetComponentInChildren<Light> ().enabled = false;
					}
				}
				normal_Crosshair.SetActive (true);
				interact_Crosshair.SetActive (false);
				FadeInteractInfoGUI = false;
		}


		if (Physics.Raycast (position, direction, out hit, distance, layerMaskInteract.value)) {
			if (hit.transform.CompareTag (KeyTag) && hit.transform.GetComponent<Key> ()) {
					targetDoor = hit.transform.GetComponent<Key> ().targetDoor;
					OnTagKey = true;

				}
			else
			{
				OnTagKey = false;
			}
		} 
		else
		{
			OnTagKey = false;
		}

		if (Physics.Raycast (position, direction, out hit, distance, layerMaskInteract.value)) {
			if (hit.transform.CompareTag(FlashlightTag)){
				OnTagFlashlight = true;
			}
			else
			{
				OnTagFlashlight = false;
			}
		} 
		else
		{
			OnTagFlashlight = false;
		}

		if (Physics.Raycast (position, direction, out hit, distance, layerMaskInteract.value)) {
			if (hit.transform.CompareTag(FlashlightBatteryTag)){
				OnTagFlashlightBattery = true;
			}
			else
			{
				OnTagFlashlightBattery = false;
			}
		} 
		else
		{
			OnTagFlashlightBattery = false;
		}

		if (Physics.Raycast (position, direction, out hit, distance, layerMaskInteract.value)) {
			if (hit.transform.CompareTag(DoorTag)){
				OnTagDoor = true;
				doorRaycasted = hit.transform.gameObject;
			}
			else
			{
				OnTagDoor = false;
			}
		} 
		else
		{
			OnTagDoor = false;
		}

		if (Physics.Raycast (position, direction, out hit, distance, layerMaskInteract.value)) {
				if (hit.transform.CompareTag(PaperTag) && hit.transform.GetComponent<Note>()){
				targetPaperNote = hit.transform.GetComponent<Note> ().UI_Note;
				OnTagPaper = true;
			}
			else
			{
					OnTagPaper = false;
			}
		} 
		else
		{
				OnTagPaper = false;
		}

		if (Physics.Raycast (position, direction, out hit, distance, layerMaskInteract.value)) {
				if (hit.transform.CompareTag(TelecameraTag)){
					OnTagTelecamera = true;
				}
				else
				{
					OnTagTelecamera = false;
				}
			} 
			else
			{
				OnTagTelecamera = false;
		}

		if (Physics.Raycast (position, direction, out hit, distance, layerMaskInteract.value)) {
				if (hit.transform.CompareTag(LampTag) && hit.transform.GetComponent<Lamp>()){
				OnTagLamp = true;
				RaycastedLamp = hit.transform.gameObject;
			}
			else
			{
					OnTagLamp = false;
			}
		} 
		else
		{
				OnTagLamp = false;
		}

		if (Physics.Raycast (position, direction, out hit, distance, layerMaskInteract.value)) {
				if (hit.transform.CompareTag(ExamineTag) || hit.transform.GetComponent<InteractObject>()){
				OnTagExamine = true;
				RaycastedExamineObj = hit.transform.gameObject;
			}
			else
			{
				OnTagExamine = false;
			}
		} 
		else
		{
				OnTagExamine = false;
		}

		if (ExaminingObject) 
		{
				if (Input.GetKeyDown (KeyCode.Mouse1)) 
				{
					if (Player.GetComponent<CameraManager> ().usingCam) 
					{
						Player.GetComponent<CameraManager> ().CameraUI.GetComponent<CanvasGroup> ().alpha = 1;
						if (Player.GetComponent<CameraManager> ().broken) 
						{
							Player.GetComponent<CameraManager> ().camera_effect.enabled = true;
							Player.GetComponent<CameraManager> ().brokenGUI.GetComponent<CanvasGroup> ().alpha = 1;
						}
					}
					ExaminingObject = false;
					ShowExaminingInfoGui = false;
					Player.GetComponent<FirstPersonController> ().enabled = true;
					Player.GetComponentInChildren<ExamineRotation> ().enabled = false;
					Player.GetComponentInChildren<ExamineRotation> ().target = null;
					RaycastedExamineObj.GetComponent<InteractObject> ().ExaminableObject.SetActive (false);
					RaycastedExamineObj.SetActive (true);
					if (Player.GetComponent<CameraManager> ().usingCam && !Player.GetComponent<CameraManager>().broken) 
					{
						Player.GetComponentInChildren<ZoomCamera> ().canZoom = true;
					}
					Player.GetComponent<CameraManager> ().canUse = true;
					Player.GetComponentInChildren<BlurOptimized> ().enabled = false;
				}
		}


		if (OnTagExamine) 
		{
			if (Input.GetKeyDown (KeyCode.Mouse1))
			{
					if (!ExaminingObject) 
					{
						if (RaycastedExamineObj.GetComponent<InteractObject> ().ExaminableObject == null) {
							this.GetComponent<AudioSource> ().clip = CantPickup;
							this.GetComponent<AudioSource> ().volume = 1f;
							this.GetComponent<AudioSource> ().Play ();
						} else 
						{
							if (Player.GetComponent<CameraManager> ().usingCam) 
							{
								Player.GetComponent<CameraManager> ().CameraUI.GetComponent<CanvasGroup> ().alpha = 0;
								if (Player.GetComponent<CameraManager> ().broken) 
								{
									Player.GetComponent<CameraManager> ().brokenGUI.GetComponent<CanvasGroup> ().alpha = 0;
									Player.GetComponent<CameraManager> ().camera_effect.enabled = false;
								}
							}
							if (!RaycastedExamineObj.GetComponent<InteractObject> ().Examined) 
							{
								StartCoroutine (RevealExamined ());
							}
							ShowExaminingInfoGui = true;
							ExaminingObject = true;
							Cursor.visible = true;
							Cursor.lockState = CursorLockMode.None;
							Player.GetComponentInChildren<BlurOptimized> ().enabled = true;
							Player.GetComponent<FirstPersonController> ().enabled = false;
							Player.GetComponentInChildren<ExamineRotation> ().enabled = true;
							Player.GetComponentInChildren<ExamineRotation> ().target = RaycastedExamineObj.GetComponent<InteractObject>().ExaminableObject.transform;
							RaycastedExamineObj.GetComponent<InteractObject> ().ExaminableObject.SetActive (true);
							RaycastedExamineObj.SetActive (false);
							Player.GetComponentInChildren<ZoomCamera> ().canZoom = false;
							Player.GetComponent<CameraManager> ().canUse = false;
						}
					}
			}

			if (Input.GetKeyDown (KeyCode.Mouse0))
			{
					if (!RaycastedExamineObj.GetComponent<InteractObject> ().Interactable) 
					{
						this.GetComponent<AudioSource> ().clip = CantPickup;
						this.GetComponent<AudioSource> ().volume = 1f;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
		}


		if (OnTagPaper) {
				if (!ExaminingObject) {
					if (Input.GetKeyDown (KeyCode.Mouse0)) {
						if (targetPaperNote.GetComponent<CanvasGroup> ().alpha == 0) {
							Cursor.visible = true;
							Cursor.lockState = CursorLockMode.None;
							targetPaperNote.GetComponent<UIFade> ().TextIn = true;
							targetPaperNote.GetComponent<UIFade> ().TextOut = false;
							Player.GetComponent<FirstPersonController> ().enabled = false;
							this.GetComponent<AudioSource> ().clip = PaperPickup [Random.Range (0, PaperPickup.Length)];
							this.GetComponent<AudioSource> ().volume = pickupVolume;
							this.GetComponent<AudioSource> ().Play ();
						} else {
							targetPaperNote.GetComponent<UIFade> ().TextIn = false;
							targetPaperNote.GetComponent<UIFade> ().TextOut = true;
							Player.GetComponent<FirstPersonController> ().enabled = true;
							this.GetComponent<AudioSource> ().clip = PaperPickup [Random.Range (0, PaperPickup.Length)];
							this.GetComponent<AudioSource> ().volume = pickupVolume;
							this.GetComponent<AudioSource> ().Play ();
						}
					}
				}
		}

		if (OnTagDoor) {

				if (!ExaminingObject) {
					if (Input.GetKeyDown (KeyCode.Mouse0)) {
						if (doorRaycasted.GetComponentInParent<DynamicObject> ().Jammed) {
							doorRaycasted.GetComponentInParent<DynamicObject> ().SendMessageUpwards ("doorJammed");
						}
						if (doorRaycasted.GetComponentInParent<DynamicObject> ().Free) {
							doorRaycasted.GetComponentInParent<DynamicObject> ().SendMessageUpwards ("doorOpenClose");
						}
						if (doorRaycasted.GetComponentInParent<DynamicObject> ().Locked) {
							doorRaycasted.GetComponentInParent<DynamicObject> ().SendMessageUpwards ("doorLocked");
						}
						if (doorRaycasted.GetComponentInParent<DynamicObject> ().wasLocked) {
							doorRaycasted.GetComponentInParent<DynamicObject> ().SendMessageUpwards ("removeWasLocked");
						}
					}
				}
		}


		if (OnTagFlashlight) {

				if (!ExaminingObject) {

					if (Input.GetKeyDown (KeyCode.Mouse0)) {
						Player.GetComponent<FlashlightManager> ().SendMessage ("HasFlashlight");
						Destroy (hit.transform.gameObject);
						this.GetComponent<AudioSource> ().clip = GeneralPickup [Random.Range (0, GeneralPickup.Length)];
						this.GetComponent<AudioSource> ().volume = pickupVolume;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
		}

		if (OnTagLamp) {
				
				if (!ExaminingObject) {

					if (Input.GetKeyDown (KeyCode.Mouse0)) {
						if (RaycastedLamp.GetComponent<Lamp> ().isOn) {
							RaycastedLamp.SendMessage ("SwitchOff");
						} else {
							RaycastedLamp.SendMessage ("SwitchOn");
						}
					}
				}
		}

		if (OnTagFlashlightBattery) {

				if (!ExaminingObject) {
				
					if (Input.GetKeyDown (KeyCode.Mouse0)) {
						Player.GetComponent<FlashlightManager> ().SendMessage ("AddBattery");

						if (Player.GetComponent<FlashlightManager> ().five_battery == false) {						
							Destroy (hit.transform.gameObject);
							this.GetComponent<AudioSource> ().clip = GeneralPickup [Random.Range (0, GeneralPickup.Length)];
							this.GetComponent<AudioSource> ().volume = pickupVolume;
							this.GetComponent<AudioSource> ().Play ();
						}
					}
				}
		}			
		
		if (OnTagTelecamera) {

				if (!ExaminingObject) {

					if (Input.GetKeyDown (KeyCode.Mouse0)) {
						Player.GetComponent<CameraManager> ().HasCamera = true;
						Player.GetComponent<CameraManager> ().SendMessage ("Pickup");
						Player.GetComponent<CameraManager> ().SendMessage ("ShowPickedText");
						Destroy (hit.transform.gameObject);
						this.GetComponent<AudioSource> ().clip = GeneralPickup [Random.Range (0, GeneralPickup.Length)];
						this.GetComponent<AudioSource> ().volume = pickupVolume;
						this.GetComponent<AudioSource> ().Play ();
					}
				}
		}				

			if (OnTagKey) {

				if (!ExaminingObject) {

					if (Input.GetKeyDown (KeyCode.Mouse0)) {
						Player.GetComponent<KeyManager> ().SendMessage ("AddKey");
						Destroy (hit.transform.gameObject);
						this.GetComponent<AudioSource> ().clip = KeyPickup [Random.Range (0, KeyPickup.Length)];
						this.GetComponent<AudioSource> ().volume = pickupVolume;
						this.GetComponent<AudioSource> ().Play ();
						if (!targetDoor.GetComponentInParent<DynamicObject> ().Jammed) {
							targetDoor.GetComponentInParent<DynamicObject> ().SendMessageUpwards ("OpenDoor");
						}
					}
				}
			}
	 }
   }
 }