using UnityEngine;
using System.Collections;

public class girlAnimator : MonoBehaviour {

    AudioSource source;
    private bool nextToDoor = false;
    Animator anim;
    Vector3 close;
    private bool animationTrigger = true;
    private bool hasBeenTriggered = false;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        close = new Vector3(2.47f, 0, -0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlReactor_Code.sliderSuccess /*&& CameraRayCast.triggerAnimation*/)
        {
            hasBeenTriggered = true;
        }

             if ( ControlReactor_Code.sliderSuccess )
        {
            source.loop = true;
            if (!source.isPlaying)
            {
                source.Play();
            }
            
        }

        if (hasBeenTriggered)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 3f);
        }

        if ((close - transform.position).magnitude < .5f && animationTrigger)
        {
          //  anim.CrossFade("Scream", .5f);
            nextToDoor = true;
            animationTrigger = false;
        }

    }
}
