using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class grimAnimator : MonoBehaviour {

    public Locker locker;
    AudioSource source;    
     

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
        if (locker.isOpened)
        {
            source.loop = true;
            if (!source.isPlaying)
            {
                source.Play();
            }
            
            transform.Translate(Vector3.back * Time.deltaTime * 4.5f);
        }
        
    }
}
