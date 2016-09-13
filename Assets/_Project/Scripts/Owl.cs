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
	  

    IEnumerator AnimationDelay()
    {

        yield return new WaitForSeconds(18);
        flyAround = true;

    }
    IEnumerator AnimationDelay2()
    {
        
        yield return new WaitForSeconds(10);
        flyClose = true;

    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (animationTriggers[0])
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-0.11f, 0, 1.41f), 3f* Time.deltaTime);
        }
        
        if (animationTriggers[0] && transform.position.y < .5f)
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
                //transform.Rotate(Vector3.up * 1 / 20 * Time.deltaTime);
                //transform.RotateAround(new Vector3(0,0,0), Vector3.up, 20 * Time.deltaTime);
                if (transform.position.y - 0 < 200)
                {
                    transform.Translate(Vector3.up * 10 * Time.deltaTime);
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
