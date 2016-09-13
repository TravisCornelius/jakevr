using UnityEngine;
using System.Collections;
using VRTK;

public class OwlLegs : VRTK_InteractableObject{

    public static bool isLegGrabbed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (IsGrabbed())
        {
            isLegGrabbed = true;
        } else
        {
            isLegGrabbed = false;
        }

    }
   
   
    
}
