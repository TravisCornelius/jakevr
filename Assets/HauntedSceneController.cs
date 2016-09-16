using UnityEngine;
using System.Collections;

public class HauntedSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * .1f);
    }
}
