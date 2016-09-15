using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using VRTK;

public class MenuController : MonoBehaviour
{
    private const int EXISTING_CANVAS_COUNT = 4;

    public void Button_Hospital_Horror()
    {
        //launch scene
        SceneManager.LoadScene("HauntedHospital");
        Debug.Log("Hospital Horror Button Clicked");
        
    }

    public void Button_Next_Room()
    {
        //SceneManager.LoadScene("SceneName");
        Debug.Log("Next Room Button Clicked");
    }


    public void Dropdown(int value)
    {
        Debug.Log("Dropdown option selected was ID " + value);
    }

}