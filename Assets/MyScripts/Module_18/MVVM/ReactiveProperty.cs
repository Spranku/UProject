using System;
using UnityEngine;

public class ReactiveProperty<T>
{
    public event Action<T> OnValueChanged;

    private T NewValue;

    public T Value
    {
        get { return NewValue; }
        set 
        {
            NewValue = value;
            OnValueChanged?.Invoke(NewValue);
        }
    }

    public ReactiveProperty(T InitValue = default)
    {
        NewValue = InitValue;
    }
}
