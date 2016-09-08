//Script written by Giovanni Cartella - giovanni.cartella@hotmail.com || www.giovannicartella.weebly.com
//You are allowed to use this only if you have "Horror Development Kit" license, so only if you bought it officially

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SimpleMenu : MonoBehaviour {

	public void Exit() {
		Application.Quit ();
	}

	public void Play(string levelToPlay) {
		SceneManager.LoadScene (levelToPlay, LoadSceneMode.Single);
	}
}
