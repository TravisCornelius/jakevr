using UnityEngine;
using System.Collections;


public class watch : MonoBehaviour {

    TextMesh mesh;
    public bool startTimer = true;
    public int timeLimit = 7;

    private static float timer;
    private static float timeLeft;

    // Use this for initialization
    void Start () {
        mesh = GetComponent<TextMesh>();
                
	}
	
	// Update is called once per frame
	void Update () {
        //float min = Mathf.Floor(SceneController.timer / 60);
        //float seconds = Mathf.Floor(SceneController.timer - min * 60);
        //mesh.text = "0" + min + ":" + seconds;

        if (startTimer == true)
        {
            timer += Time.deltaTime;
            timeLeft = timeLimit - timer;

            if (timeLeft > 0)
            {
                int minutes = Mathf.FloorToInt(timeLeft / 60F);
                int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
                float fraction = timeLeft * 1000;
                float milliseconds = fraction % 1000;

                if (mesh != null)
                {
                    mesh.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
                }
            }
            else
            {
                GameOver();
            }

        }

    }

    public void PauseTimer(bool pause)
    {
        startTimer = pause;
    }

    public void GameOver()
    {
        mesh.text = "So Close!";
    }
}
