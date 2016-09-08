//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	[Header ("Splash screen settings")]
    public float Time;
	public string levelToLoad;

	void Start () {
        StartCoroutine(StartSplash());	
	}

	IEnumerator StartSplash() {
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene(levelToLoad);	
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
