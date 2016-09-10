using UnityEngine;
using System.Collections;
using VRTK;

public class HandController : VRTK_InteractableObject
{

    private Animator animator;
    SteamVR_Controller.Device device;
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        animator.SetBool("isGrabbing", Input.GetKey(KeyCode.F));
        Debug.Log(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger));
    }

    public override void StartUsing(GameObject currentUsingObject)
    {
        base.StartUsing(currentUsingObject);
        animator.SetBool("isGrabbing", true);
    }

    public override void StopUsing(GameObject previousUsingObject)
    {
        base.StopUsing(previousUsingObject);
        animator.SetBool("isGrabbing", false);
    }
}
