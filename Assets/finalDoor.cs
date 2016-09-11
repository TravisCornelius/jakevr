using UnityEngine;
using System.Collections;

public class finalDoor : MonoBehaviour {
    
    AudioSource source;
    bool triggered = false;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (ControlReactor_Code.sliderSuccess && !triggered)
        {
            triggered = true;
            transform.Rotate(0, 90, 0);
            source.Play();
        }
        
    }
}
