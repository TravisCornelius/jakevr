using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class playCollisionSound : MonoBehaviour {

    /*
     * 
     * Make sure the last AudioSource in the list is empty if you don't want to
     * override sounds.
     * 
     */

    AudioSource[] sources;
    AudioSource lastSource;
    public AudioClip heavyForceClip;
    public AudioClip mediumForceClip;
    public AudioClip lightForceClip;

    // Use this for initialization
    void Start () {
        sources = GetComponents<AudioSource>();
        lastSource = sources[sources.Length-1];

    }
	
    void OnCollisionEnter(Collision collision)
    {
        float force = collision.relativeVelocity.magnitude;
        if (force > 2 && force <= 5)
        {
            lastSource.clip = lightForceClip;
            lastSource.Play();
        } else if (force > 5 && force <= 10)
        {
            lastSource.clip = mediumForceClip;
            lastSource.Play();
        } else if (force > 10)
        {
            lastSource.clip = heavyForceClip;
            lastSource.Play();
        }


    }
}
