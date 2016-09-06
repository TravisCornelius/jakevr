using UnityEngine;
using System.Collections;
using VRTK;

public class LockerInteractor : VRTK_InteractableObject
{
    public override void StartUsing(GameObject usingObject)
    {
        char symbol = '1';
        base.StartUsing(usingObject);
        OnPrimaryAction();
        _targetLocker.SwitchOpened();
        _targetLocker.SetSymbol(primaryAction.symbol, primaryAction.symbolIndex);

        Debug.Log("startUsing");
        Debug.Log(_targetLocker);
        Debug.Log(_targetLocker._controlSequence);
        Debug.Log(_targetLocker._currentSequence);
    }

    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);
        
    }



    


    public enum ActionID {

        None,
        Lock,
        Unlock,
        Open,
        Close,
        SwitchOpenClose,
        SetSymbol,
        AddSymbol,
        RemoveLastSymbol,
        ClearAllSymbols,
        ReassignControlSequence

    }

    [System.Serializable]
    public class ActionParams {

        public ActionID id;
        public char symbol;
        public int symbolIndex;
        public bool useEnteredSequence;
        public string newSequence;
        public AudioClip sound;

    }

    public Locker targetLocker {
        get { return _targetLocker; }
    }

    [SerializeField]
    Locker _targetLocker;

    [SerializeField]
    bool prewarmAction;

    [SerializeField]
    protected ActionParams primaryAction;

    [SerializeField]
    protected ActionParams secondaryAction;

    protected bool IsSymbolValid(char symbol) {

        return !char.IsWhiteSpace(symbol);

    }

    protected void Use(ActionParams action, bool playSound = true) {
        Debug.Log(action);
        if (_targetLocker == null || action.id == ActionID.None) return;

        switch (action.id) {

            case ActionID.Unlock:

                _targetLocker.Unlock();

                break;

            case ActionID.Lock:

                _targetLocker.Lock();

                break;

            case ActionID.Open:

                _targetLocker.Open();

                break;

            case ActionID.Close:

                _targetLocker.Close();

                break;

            case ActionID.SwitchOpenClose:

                _targetLocker.SwitchOpened();

                break;

            case ActionID.SetSymbol:

                _targetLocker.SetSymbol(action.symbol, action.symbolIndex);

                break;
        
            case ActionID.AddSymbol:

                if (IsSymbolValid(action.symbol)) {

                    _targetLocker.AddSymbol(action.symbol);

                }

                break;

            case ActionID.ClearAllSymbols:

                _targetLocker.ClearCurrentSequence();

                break;

            case ActionID.ReassignControlSequence:

                if (action.useEnteredSequence) {

                    _targetLocker.LockWithEnteredSequence();

                }
                else {

                    _targetLocker.Lock(action.newSequence);

                }
                
                break;

            case ActionID.RemoveLastSymbol:

                _targetLocker.RemoveLastSymbol();

                break;
        
        }

        if (playSound) {

            targetLocker.PlaySound(action.sound);

        }

    }

    public void Use(bool isSecondary = false) {

        if (isSecondary) {

            OnSecondaryAction();
            Use(secondaryAction);

        }
        else {

            OnPrimaryAction();
            Use(primaryAction);

        }

    }

    protected virtual void OnPrimaryAction() { }

    protected virtual void OnSecondaryAction() { }

    protected virtual void Awake() {

        if (_targetLocker == null) {

            Locker lockerComp = gameObject.GetComponent<Locker>();

            if (lockerComp == null && transform.root != transform) {

                lockerComp = transform.root.GetComponent<Locker>();

            }

            if (lockerComp == null) {

                Debug.LogError("There is no Locker Component!");

            }

            _targetLocker = lockerComp;

        }

    }

    IEnumerator Start() {
        base.Start();
        _targetLocker.SetSymbol('1', 0);
        _targetLocker.SetSymbol('1', 1);
        _targetLocker.SetSymbol('1', 2);
        _targetLocker.SetSymbol('1', 3);
        yield return null;

        if (prewarmAction) {

            Use(primaryAction, false);

        }

    }

  

    protected override void Update()
    {
        //rotator.transform.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0f, 0f));
    }

}
