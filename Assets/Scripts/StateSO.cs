using System;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateSO")]
public class StateSO : ScriptableObject
{
    public enum State
    {
        One,
        Two,
        Three,
    }

    [SerializeField] State _currentState;
    public State CurrentState
    {
        get => _currentState;
        set
        {
            _currentState = value;
            OnStateChanged?.Invoke(value);
        }
    }

    [SerializeField] bool _flag;
    public bool Flag
    {
        get => _flag;
        set
        {
            _flag = value;
            OnFlagChanged?.Invoke(value);
        }
    }

    public event Action<State> OnStateChanged;
    public event Action<bool> OnFlagChanged;

    public void SetStateFromInt(int i)
    {
        CurrentState = (State) i;
    }

    [Conditional("UNITY_EDITOR")]
    void OnValidate()
    {
        OnStateChanged?.Invoke(_currentState);
        OnFlagChanged?.Invoke(_flag);
    }
}
