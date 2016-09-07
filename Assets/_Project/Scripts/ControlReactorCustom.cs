using UnityEngine;
using VRTK;

public class ControlReactorCustom : MonoBehaviour
{
    public TextMesh go;

    private void Start()
    {
        GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChange);
        HandleChange(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
    }

    private void HandleChange(float value, float normalizedValue)
    {
        go.text = value.ToString();
    }
}