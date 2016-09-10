using UnityEngine;
using System.Collections;
using VRTK;

public class HandController : MonoBehaviour
{

    private Animator animator;
    SteamVR_Controller.Device device;
    VRTK_ControllerEvents controllerEvents;

     void Update () {
        
        animator.SetBool("isGrabbing", controllerEvents.triggerTouched);
       
    }

    
    void Start()
    {
        controllerEvents = GetComponentInParent<VRTK_ControllerEvents>();
        animator = GetComponent<Animator>();

    }

  
}
