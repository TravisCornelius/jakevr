using UnityEngine;
using System.Collections;

public class barscript : MonoBehaviour {
    private AudioSource source;
    private bool isTrue = true;
    GameObject[] bars;

	void Start () {
        source = GetComponent<AudioSource>();
        bars = GetComponents<GameObject>();
	}
	
	
	void Update () {
        //  if (grimAnimator.stopped && isTrue)
       //    {
            foreach (GameObject bar in bars) {
                 bar.transform.position = Vector3.MoveTowards(bar.transform.position, new Vector3(bar.transform.position.x, 2, bar.transform.position.z), 10f * Time.deltaTime);
            }
            isTrue = false;
            source.Play();
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,2,transform.position.z), 10f * Time.deltaTime);
     //   }
	}
}
