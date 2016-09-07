namespace VRTK
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using UnityEngine.SceneManagement;

    public class CountdownClock : MonoBehaviour
    {
        public bool displayFPS = true;
        public bool startTimer = true;
        public int timeLimit = 10;
        public int fontSize = 32;
        public Vector3 position = Vector3.zero;
        public Color goodColor = Color.green;
        public Color warnColor = Color.yellow;
        public Color badColor = Color.red;

        private const float updateInterval = 0.5f;
        private int framesCount;
        private float framesTime;
        private Text text;

        private static float timer;
        private static float timeLeft;


        private void Start()
        {
            text = GetComponent<Text>();
            text.fontSize = fontSize;
            text.transform.localPosition = position;
        }

        private void Update()
        {

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

                    if (text != null)
                    {
                        if (displayFPS)
                        {
                            text.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
                            text.color = goodColor;
                        }
                        else
                        {
                            text.text = "";
                        }
                    }
                }else
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
            SceneManager.LoadScene("1_main_menu");
        }
    }
}