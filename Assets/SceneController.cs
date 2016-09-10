using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
    Light[] lights;
    public static bool lightsOn = false;
    private bool lightsOnTrigger = true;
    public static float timer = 7 * 60 * 1000;
    public static bool gameOver = false;

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
 
            
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                gameOver = true;
            }
      
        if (lightsOnTrigger && lightsOn)
        {
            foreach (Light l in lights)
            {
                l.enabled = true;
                lightsOnTrigger = false;
            }
        } else if (!lightsOnTrigger && !lightsOn)
        {
            foreach (Light l in lights)
            {
                l.enabled = false;
                lightsOnTrigger = true;
            }
        }
	}
}
