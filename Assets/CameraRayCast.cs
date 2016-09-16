using UnityEngine;
using System.Collections;

public class CameraRayCast : MonoBehaviour {

    RaycastHit hit;
    Ray ray;
    public static bool triggerAnimation = false;


    // Use this for initialization
    void Start () {
	    ray = new Ray(transform.position, Vector3.forward);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward * 5f);
	    if (Physics.Raycast(ray, out hit, 5f, 1 <<12))
        {
          
                Debug.Log(hit.transform.gameObject);
                      if (hit.collider.tag != "Untagged" && hit.collider.tag != "MainCamera")
            {
                Debug.Log(hit.collider.tag);
            }
            
            if (hit.collider.tag == "raycastHit")
            {
                Debug.Log("test");
                triggerAnimation = true;
            } else
            {
                triggerAnimation = false;
            }

        }
	}
}
