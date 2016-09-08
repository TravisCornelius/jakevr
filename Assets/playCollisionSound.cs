using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class playCollisionSound : MonoBehaviour {

    AudioSource source;
    public AudioClip heavyForceClip;
    public AudioClip mediumForceClip;
    public AudioClip lightForceClip;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();

	}
	
    void OnCollisionEnter(Collision collision)
    {
        float force = collision.relativeVelocity.magnitude;
        if (force > 2 && force <= 5)
        {
            source.clip = lightForceClip;
            source.Play();
        } else if (force > 5 && force <= 10)
        {
            source.clip = mediumForceClip;
            source.Play();
        } else if (force > 10)
        {
            source.clip = lightForceClip;
            source.Play();
        }


    }
}
