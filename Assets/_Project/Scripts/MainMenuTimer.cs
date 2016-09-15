using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]


public class MainMenuTimer : MonoBehaviour
{

    //TextMesh mesh;
    public bool startTimer = true;
    public int timeLimit = 120;

    private static float timer;
    private static float timeLeft;

    private GameObject canvas;
    private GameObject playground;
    public GameObject watch;
    private TextMesh watchMesh;

    AudioSource[] sources;
    AudioSource lastSource;

    public AudioClip welcome;
    public AudioClip chooseExperience;

    // Use this for initialization
    void Start()
    {
        //mesh = GetComponent<TextMesh>();
        canvas = GameObject.Find("Canvas");
        playground = GameObject.Find("Playground");
        //watch = GameObject.Find("WatchTime");
        watchMesh = watch.GetComponent<TextMesh>();

        sources = GetComponents<AudioSource>();
        lastSource = sources[sources.Length - 1];

    }

    // Update is called once per frame
    void Update()
    {
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

                if (watchMesh != null)
                {
                    watchMesh.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
                }

                if (timeLeft > 30)
                {
                    canvas.SetActive(false);
                    playground.SetActive(true);

                    lastSource.clip = welcome;
                    lastSource.Play();
                }
                else
                {
                    canvas.SetActive(true);
                    playground.SetActive(false);

                    lastSource.clip = chooseExperience;
                    lastSource.Play();
                }

            }
            else
            {
                //launch default scene
                SceneManager.LoadScene("HauntedHospital");
            }

        }

    }

    public void PauseTimer(bool pause)
    {
        startTimer = pause;
    }

}
