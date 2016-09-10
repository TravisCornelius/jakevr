using UnityEngine;
using System.Collections;


public class watch : MonoBehaviour {

    TextMesh mesh;          
	// Use this for initialization
	void Start () {
        mesh = GetComponent<TextMesh>();
                
	}
	
	// Update is called once per frame
	void Update () {
        float min = Mathf.Floor(SceneController.timer / 60);
        float seconds = Mathf.Floor(SceneController.timer - min * 60);
        mesh.text = "0" + min + ":" + seconds;
	}
}
