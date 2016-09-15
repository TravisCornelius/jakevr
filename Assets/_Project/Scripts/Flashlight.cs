using UnityEngine;
using System.Collections;
using VRTK;
[RequireComponent(typeof(AudioSource))]

public class Flashlight : VRTK_InteractableObject {

    Light[] lights;

    AudioSource[] sources;
    AudioSource lastSource;

    public AudioClip turnOnOff;
    public AudioClip heavyForceClip;
    public AudioClip mediumForceClip;
    public AudioClip lightForceClip;

    public GameObject rightHand;
    private Transform t;

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        Debug.Log("Start Using");

        lastSource.clip = turnOnOff;
        lastSource.Play();

        /*foreach (Light light in lights)
        {
            light.enabled = true;
        }*/
    }

    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);

        lastSource.clip = turnOnOff;
        lastSource.Play();

        /*foreach (Light light in lights)
        {
            light.enabled = false;
        }*/
    }

    protected override void Start()
    {
        base.Start();
        sources = GetComponents<AudioSource>();
        lastSource = sources[sources.Length - 1];
        lights = GetComponentsInChildren<Light>();
        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        t = GetComponent<Transform>();
        t.position = rightHand.transform.position;



    }

    protected override void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        float force = collision.relativeVelocity.magnitude;
        if (force > 2 && force <= 5)
        {
            lastSource.clip = lightForceClip;
            lastSource.Play();
        }
        else if (force > 5 && force <= 10)
        {
            lastSource.clip = mediumForceClip;
            lastSource.Play();
        }
        else if (force > 10)
        {
            lastSource.clip = heavyForceClip;
            lastSource.Play();
        }


    }
}
