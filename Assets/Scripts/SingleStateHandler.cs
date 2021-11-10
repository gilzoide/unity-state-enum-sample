using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class SingleStateHandler : MonoBehaviour
{
    [SerializeField] StateSO _stateSO;
    public StateSO.State StateToHandle;
    public UnityEvent OnStateEntered;
    public UnityEvent OnStateExited;

    StateSO.State _previousState;

    void Awake()
    {
        if (_stateSO == null) return;
        _stateSO.OnStateChanged += HandleStateChanged;
        _previousState = _stateSO.CurrentState;
    }

    void OnDestroy()
    {
        if (_stateSO == null) return;
        _stateSO.OnStateChanged -= HandleStateChanged;
    }

    void HandleStateChanged(StateSO.State state)
    {
        if (state == StateToHandle)
        {
            OnStateEntered.Invoke();
        }
        else if (_previousState == StateToHandle)
        {
            OnStateExited.Invoke();
        }
        _previousState = state;
    }

    [Conditional("UNITY_EDITOR")]
    void OnValidate()
    {
        if (_stateSO == null) return;
        _stateSO.OnStateChanged += HandleStateChanged;
        HandleStateChanged(_stateSO.CurrentState);
    }
}
