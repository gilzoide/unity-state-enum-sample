using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class FlagHandler : MonoBehaviour
{
    [SerializeField] StateSO _stateSO;
    public UnityEvent<bool> OnFlagChanged;
    public UnityEvent OnFlagOn;
    public UnityEvent OnFlagOff;

    void Awake()
    {
        if (_stateSO == null) return;
        _stateSO.OnFlagChanged += HandleFlagChanged;
    }

    void OnDestroy()
    {
        if (_stateSO == null) return;
        _stateSO.OnFlagChanged -= HandleFlagChanged;
    }

    void HandleFlagChanged(bool flag)
    {
        OnFlagChanged?.Invoke(flag);
        if (flag)
        {
            OnFlagOn?.Invoke();
        }
        else
        {
            OnFlagOff?.Invoke();
        }
    }

    [Conditional("UNITY_EDITOR")]
    void OnValidate()
    {
        if (_stateSO == null) return;
        _stateSO.OnFlagChanged += HandleFlagChanged;
        HandleFlagChanged(_stateSO.Flag);
    }
}
