//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
	
	[RequireComponent (typeof(AudioSource))]
    public class AnimatedJumpscare : MonoBehaviour {

	[Header ("Animated Jumpscare")]
        public GameObject ScareObject;					//The Creature/Monster GameObject
        public string ScareObjectAnim;					//The animation of the ScareObject
        public string JumscareAnim;						//The main Jumpscare animation, attached in the main GameObject
        public AudioClip ScareSound;					//The jumpscare sound effect
        public MotionBlur Sanity;						//Motion Blur image effect attached to the main camera
		public float Time;								//The jumpscare time
		public bool deactivateColliderAfterCollision;	//Do you want to disable the Jumpscare after playing it one time?
		bool active;									//Is the Jumpscare actived?

        void Start() {
            ScareObject.GetComponent<Animation>().Stop(ScareObjectAnim);            //stop looping (walk, run or any) animation on scare object
        }

        public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (!active) {
				active = true;
				ScareObject.GetComponent<Animation> ().Play (ScareObjectAnim);      	//play stopped scare object animation
				GetComponent<Animation> ().Play (JumscareAnim);      					//play jumpscare animation
				GetComponent<AudioSource> ().clip = ScareSound;                   	 	//set scare sound
				GetComponent<AudioSource> ().Play ();                              	  	//play scare sound
				if (Sanity) { 
					Sanity.enabled = true; 												//enable sanity
				}        						
				StartCoroutine (ScaredWait ());         								//wait for destroy and sanity
			}

			if(deactivateColliderAfterCollision){
				gameObject.GetComponent<Collider>().enabled = false;
			}

		  }
        }
        

       IEnumerator ScaredWait() {
		yield return new WaitForSeconds(Time);
     	if (Sanity) { 
			Sanity.enabled = false; 
		}
		active = false;
       }
  }