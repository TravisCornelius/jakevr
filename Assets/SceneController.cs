using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
    Light[] lights;       
	// Use this for initialization
	void Start () {
        lights = GetComponentsInChildren<Light>();
        foreach (Light l in lights)
        {
            l.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
