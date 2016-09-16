using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]


public class MainMenuTimer : MonoBehaviour
{

    //TextMesh mesh;
    public bool startTimer = true;
    public float timeLimit = 120;

    private static float timer;
    private static float timeLeft;

    private GameObject canvas;
    private GameObject playground;
    public GameObject watch;
    private TextMesh watchMesh;

    AudioSource source;

    public AudioClip welcome;
    private bool welcomeTrigger = true;
    public AudioClip chooseExperience;
    private bool chooseExperienceTrigger = true;

    // Use this for initialization
    void Start()
    {
        //mesh = GetComponent<TextMesh>();
        //canvas = GameObject.Find("Canvas");
        //playground = GameObject.Find("Playground");
        //watch = GameObject.Find("WatchTime");
        watchMesh = watch.GetComponent<TextMesh>();

        source = GetComponent<AudioSource>();

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

                if (welcomeTrigger)
                {
                    //canvas.SetActive(false);
                    //playground.SetActive(true);

                    source.clip = welcome;
                    source.Play();
                    welcomeTrigger = false;
                }
                else if ( timeLeft < 30 && chooseExperienceTrigger)
                {
                    
                        source.clip = chooseExperience;
                        source.Play();
                        chooseExperienceTrigger = false;
                    

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
