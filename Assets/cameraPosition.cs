using UnityEngine;
using System.Collections;

public class cameraPosition : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
	 target = GameObject.Find("TargetCameraPosition");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = target.transform.position;
	}
}
