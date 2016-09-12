using UnityEngine;
using System.Collections;

public class Owl : MonoBehaviour {
    bool move = false;
	// Use this for initialization
	void Start () {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        move = true; 
    }

    // Update is called once per frame
    void Update () {
        if (move)
        {
            //transform.Translate(Vector3.up *5* Time.deltaTime, Space.World);
        }
        
    }
}
