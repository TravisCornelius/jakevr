using UnityEngine;
using System.Collections;

public class barscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
            
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (grimAnimator.stopped)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,0), 1f * Time.deltaTime);
        }
	}
}
