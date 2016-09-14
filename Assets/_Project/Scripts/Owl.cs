using UnityEngine;
using System.Collections;

public class Owl : MonoBehaviour {
    bool move = false;
    // Use this for initialization
    Animator animator;
    public GameObject head;

    enum clips
    {
        glidePrey,
        glideNormal,
        flyNormal,
        goToFlyBranch,
        flyPrey,
        hitTheFloor,
        goToFlyFloor,
        hop,
        deathFloor,
        falling,
        landingFloor,
        walk,
        idleFloor1,
        idleFloor2,
        idleFloor3,
        idleBranch1,
        idleBranch2,
        idleBranch3,
        landingBranch,
        inAirDeathGoToFall
    }
    bool[] animationTriggers = new bool[] { true,true,true,true,true,true};
    bool flyAround = false;
    bool flyClose = false;
    AudioSource source;
    public AudioClip liftOffAudioClip;

    IEnumerator AnimationDelay()
    {

        yield return new WaitForSeconds(15);
        flyAround = true;

    }
    IEnumerator AnimationDelay2()
    {
        
        yield return new WaitForSeconds(17);
        flyClose = true;

    }

    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (animationTriggers[0])
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.93f, 1.725f, 1.663f), 15f * Time.deltaTime);
        }
        
        if (animationTriggers[0] && Vector3.Distance(transform.position, new Vector3(1.93f, 1.725f, 1.663f)) < .01f)
        {
            animator.CrossFade(clips.landingFloor.ToString(), .5f);
            animationTriggers[0] = false;
            StartCoroutine(AnimationDelay());
            
        }

       
        if(flyAround)
        {
            if (!OwlLegs.isLegGrabbed)
            {
                if (animationTriggers[1])
            {
                animationTriggers[1] = false;
                animator.CrossFade(clips.flyNormal.ToString(), .0f);
            }
            var q = transform.rotation;
            transform.Rotate(Vector3.up * 1/20 * Time.deltaTime);
            transform.RotateAround(head.transform.position, Vector3.up, 20 * Time.deltaTime);
            if (transform.position.y < 1.5f)
            {
                transform.Translate(Vector3.up  * Time.deltaTime);
            }
            if (animationTriggers[2])
            {
                animationTriggers[2] = false;
                StartCoroutine(AnimationDelay2());
            }
            if (flyClose)
            {
            
                if (Vector3.Distance(transform.position, head.transform.position) > .5f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, head.transform.position, Time.deltaTime);
                }
            }
                
           }
           if (OwlLegs.isLegGrabbed)
            {
                if (animationTriggers[3])
                {
                    animationTriggers[3] = false;
                    source.Stop();
                    source.clip = liftOffAudioClip;
                    source.Play();
                }
                //transform.Rotate(Vector3.up * 1 / 20 * Time.deltaTime);
                //transform.RotateAround(new Vector3(0,0,0), Vector3.up, 20 * Time.deltaTime);
                if (transform.position.y - 0 < 50)
                {
                    transform.Translate(Vector3.up * 7* Time.deltaTime);
                }
                if (Vector3.Distance(new Vector3(0,0,0), transform.position) <100)
                {
                   // transform.LookAt(new Vector3(0,0,0));
                   // transform.Rotate(0, 180, 0);
                  //  transform.Translate(Vector3.forward * 10 *Time.deltaTime);
                }
            }
           
        }
        
    }
}
