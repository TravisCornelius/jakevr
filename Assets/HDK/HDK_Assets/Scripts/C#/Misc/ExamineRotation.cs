//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExamineRotation : MonoBehaviour {

	[Header ("Examine Object Rotation")]
	public Transform target;
	public float speed;
	private float rootx;
   	private float rooty;

    void Update()
    {
		if (Input.GetMouseButton(0))
            {
                rooty += Input.GetAxis("Mouse Y") * speed;
                rootx += Input.GetAxis("Mouse X") * speed;
                rooty = Mathf.Clamp(rooty, -360, 360);
            }
      
   		target.eulerAngles = new Vector3(rooty, -rootx, 0);

    }
}