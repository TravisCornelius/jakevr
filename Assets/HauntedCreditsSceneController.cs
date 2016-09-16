using UnityEngine;
using System.Collections;

public class HauntedCreditsSceneController : MonoBehaviour {

    
    GameObject[] credits;
    int totalCredits;
    
    int i = 0;

    IEnumerator LerpThat(float speed, GameObject obj)
    {
        float ratio = 0;
        while (ratio < 1)
        {
            ratio += Time.deltaTime * speed;
            Color col = obj.GetComponent<Renderer>().material.color;
            col.a = Mathf.Lerp( 0f, 1, ratio);
            obj.GetComponent<Renderer>().material.color = col;
            yield return null;
        }
        
         ratio = 0;
        while (ratio < 1)
        {
            ratio += Time.deltaTime * speed;
            Color col = obj.GetComponent<Renderer>().material.color;
            col.a = Mathf.Lerp(col.a, 0f, ratio);
            obj.GetComponent<Renderer>().material.color = col;
            yield return null;
        }
        i--;
        if (i >= 0)
        {
            StartCoroutine(LerpThat(.2f, credits[i]));
        }   
    }

    // Use this for initialization
    void Start () {
        credits = GameObject.FindGameObjectsWithTag("credit");
        totalCredits = credits.Length;
        
        foreach (GameObject c in credits)
        {
            Color col = c.GetComponent<Renderer>().material.color;
            col.a = 0f;
            c.GetComponent<Renderer>().material.color = col;
            
        }
        i = totalCredits-1;
        StartCoroutine(LerpThat(.2f,credits[i]));
	}	
}
