using UnityEngine;
using System.Collections;

public class finalDoor : MonoBehaviour {
    
    AudioSource source;
    // Use this for initialization
    void Start()
    { 
    }
	
	// Update is called once per frame
	void Update () {
        if (ControlReactor_Code.sliderSuccess)
        {
            transform.Rotate(0, 90, 0);
            source.Play();
        }
        
    }
}
