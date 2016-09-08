using UnityEngine;
using System.Collections;

public class grimAnimator : MonoBehaviour {

    public Locker locker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (locker.isOpened)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 4.5f);
        }
        
    }
}
