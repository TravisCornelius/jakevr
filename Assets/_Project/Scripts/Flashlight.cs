using UnityEngine;
using System.Collections;
using VRTK;

public class Flashlight : VRTK_InteractableObject {

    public bool isOn = false;

    Light[] lights;
    
    
    GameObject flashlight;

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        Debug.Log("Start Using");
        foreach (Light light in lights)
        {
            light.enabled = true;
        }
    }

    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }

    protected override void Start()
    {
        base.Start();
        lights = GetComponentsInChildren<Light>();
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
        
        
    }

    protected override void Update()
    {
        //rotator.transform.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0f, 0f));
    }
}
