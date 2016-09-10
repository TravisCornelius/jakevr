using UnityEngine;
using System.Collections;

public class lightGame : MonoBehaviour {

    Light l;
    ParticleSystem system;
    private bool lightTrigger = true;
	// Use this for initialization
	void Start () {
        l = GetComponent<Light>();
        l.enabled = false;
        system = GetComponent<ParticleSystem>();
        system.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	    if (SceneController.lightsOn && lightTrigger)
        {
            lightTrigger = false;
            l.enabled = true;
            system.Play();
        } else if (!SceneController.lightsOn && !lightTrigger)
        {
            lightTrigger = true;
            l.enabled = false;
            system.Stop();
        }
	}
}
