using UnityEngine;
using VRTK;

public class ButtonStopTimer : MonoBehaviour
{

    private void Start()
    {
        GetComponent<VRTK_Button>().events.OnPush.AddListener(handlePush);
    }

    private void handlePush()
    {
        Debug.Log("Pushed");

        //CountdownClock clock = new CountdownClock();
        //clock.PauseTimer();
        
    }
}