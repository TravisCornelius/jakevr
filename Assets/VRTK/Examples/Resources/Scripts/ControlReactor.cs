using UnityEngine;
using VRTK;

public class ControlReactor : MonoBehaviour
{
   public static bool lightsOn = false;

    private void Start()
    {
        GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChange);
        HandleChange(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
    }

    private void HandleChange(float value, float normalizedValue)
    {
        if (normalizedValue > 70)
        {
            lightsOn = true;
        } else
        {
            lightsOn = false;
        }
        
    }
}