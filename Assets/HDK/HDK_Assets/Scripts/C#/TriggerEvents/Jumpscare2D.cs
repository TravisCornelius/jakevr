//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class Jumpscare2D : MonoBehaviour {

	[Header ("Jumpscare 2D Settings")]
	public Sprite jumpScareSprite;							//The sprite of the jumpscare
	public Sprite nullSprite;								//A blank/null sprite to show when the jumpscare is off
	public Vector2 spritePosition;							//Position of the sprite
	public Vector2 spriteScale = new Vector3(1.0f, 1.0f);	//The scale of the sprite
	public Color spriteColor = Color.white;					//Color of the sprite
	public AudioClip jumpScareAudio;						//The Jumpscare sound
	public bool deactivateColliderAfterCollision;			//Do you want to disable the Jumpscare after playing it one time?	
	public float showFor;									//How much time you want Jumpscare to show
	bool active;											//Is the Jumpscare actived?
	private GameObject jumpScareObj;
	private Image jumpScareSpriteRenderer;


	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(deactivateColliderAfterCollision){
				gameObject.GetComponent<Collider>().enabled = false;
			}

			jumpScareObj = GameObject.Find("JumpScareUI");
			jumpScareSpriteRenderer = jumpScareObj.GetComponent<Image>();

			if (!active) {
				jumpScareObj.GetComponent<Transform> ().localPosition = new Vector3 (spritePosition.x, spritePosition.y, 0.3f);
				jumpScareObj.GetComponent<Transform> ().localScale = new Vector3 (spriteScale.x, spriteScale.y, 1.0f);
				jumpScareSpriteRenderer.sprite = jumpScareSprite;
				jumpScareSpriteRenderer.color = spriteColor;
				active = true;
				StartCoroutine("HideSprite");
				if(jumpScareAudio != null) {
					gameObject.GetComponent<AudioSource>().PlayOneShot(jumpScareAudio);
				}
			}
		}
	}

	IEnumerator HideSprite()
	{
		yield return new WaitForSeconds(showFor);
		active = false;
		jumpScareSpriteRenderer.sprite = nullSprite;
	}
}