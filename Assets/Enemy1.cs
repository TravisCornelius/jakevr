using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour
{
    public GameObject player;

    private Animator animator;
    private AudioSource source;
    private bool isDead = false;
    private Rigidbody body;

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



    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody>();
        animator.CrossFade(clips.flyNormal.ToString(), .5f);
    }
    IEnumerator DestroyEnemy()
    {

        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5f * Time.deltaTime);
        }

        if (transform.position.y < .2f)
        {
            animator.CrossFade(clips.deathFloor.ToString(), .5f);
            DestroyEnemy();
        }

    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collision with: " + col.gameObject.tag);
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            isDead = true;
            animator.CrossFade(clips.inAirDeathGoToFall.ToString(), .5f);
            body.useGravity = true;
            

        }
    }
}