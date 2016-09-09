using UnityEngine;
using System.Collections;

public class lightGame : MonoBehaviour {

    Light l;
    ParticleSystem system;
	// Use this for initialization
	void Start () {
        l = GetComponent<Light>();
        l.enabled = false;
        system = GetComponent<ParticleSystem>();
        system.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	    if (SceneController.lightsOn)
        {
            l.enabled = true;
            system.Play();
        }
	}
}
