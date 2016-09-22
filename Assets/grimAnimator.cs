using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class grimAnimator : MonoBehaviour {

    public Locker locker;
    AudioSource source;
    private bool nextToDoor = false;
    Animator anim;
    Vector3 close;
    private bool animationTrigger = true;
    public static bool stopped = false;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        close = new Vector3(-0.15f, 0, .24f);
    }

    // Update is called once per frame
    void Update()
    {
        if (locker.isOpened && !nextToDoor)
        {
            source.loop = true;
            if (!source.isPlaying)
            {
                source.Play();
            }

            transform.Translate(Vector3.back * Time.deltaTime * 4.5f);

        }

        if ((close - transform.position).magnitude < .5f && animationTrigger)
        {
            stopped = true;
            anim.CrossFade("Scream", .5f);
            nextToDoor = true;
            animationTrigger = false;
        }

    }


}
