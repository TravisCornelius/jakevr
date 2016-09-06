using UnityEngine;
using System.Collections;

public sealed class ClickCodeRollInteractor : LockerClickInteractor {

    [SerializeField]
    string valuesString = "1, 2, 3, 4, 5, 6, 7";

    [SerializeField, Range(1f, 70f)]
    float rotationSpeed = 10f;

    [SerializeField]
    Vector3 rotationAxis = Vector3.forward;

    char[] values;
    float rotationStep;
    Quaternion targetRot;
    GameObject obj;

    void UpdateTargetSymbol() {

        float ang = Vector3.Dot(targetRot.eulerAngles, rotationAxis);

        if (ang < 0f) {

            ang += 360f;

        }

        if (ang > 360f) {

            ang -= 360f;

        }

        int i = Mathf.RoundToInt(ang / rotationStep) % values.Length;

        primaryAction.symbol = values[i];
        secondaryAction.symbol = values[i];
        Debug.Log("Symbol from updatetargetsymbol: " + values[i]);
        Debug.Log("name: " + this.name);
        
        if (this.name == "lock_01_a")
        {
            primaryAction.symbolIndex = 0;
        } else if (this.name == "lock_01_b")
        {
            primaryAction.symbolIndex = 1;
        } else if (this.name == "lock_01_c")
        {
            primaryAction.symbolIndex = 2;
        } else if (this.name == "lock_01_d")
        {
            primaryAction.symbolIndex = 3;
        }
        

    }

    void Rotate(float dir) {

        if (rotationStep == 0f || dir == 0f) return;

        dir = Mathf.Sign(dir);
        targetRot *= Quaternion.Euler(rotationAxis * rotationStep * dir);
        UpdateTargetSymbol();

    }

    protected override void OnPrimaryAction() {

        Rotate(1f);

    }

    protected override void OnSecondaryAction() {

        Rotate(-1f);

    }

    protected override void Awake() {

        base.Awake();

        string[] splString = valuesString.Replace(" ", string.Empty).Split(',');
        values = new char[splString.Length];
        

        for (int i = 0; i < values.Length; i++) {

            values[i] = splString[i][0];

        }
        isUsable = true;
        highlightOnTouch = true;
        touchHighlightColor = Color.cyan;
        rotationStep = values.Length > 0 ? 360f / values.Length : 0f;
        targetRot = transform.localRotation;
        rotationAxis.Normalize();

        UpdateTargetSymbol();
        obj = GetComponent<GameObject>();
       
    }

    void Update() {

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, rotationSpeed * Time.deltaTime);

    }

}
