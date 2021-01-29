using UnityEngine;
using System;
using UnityEngine.Events;

[System.Serializable]
public abstract class TVar<T> : ScriptableObject
{
    [SerializeField]
    private T _value;

    public event Action<T> Observers;

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            NotifyObservers();
        }
    }

    public void NotifyObservers()
    {
        Debug.Log("Entro al NotifyObserver");
        Observers?.Invoke(_value);
    }
}