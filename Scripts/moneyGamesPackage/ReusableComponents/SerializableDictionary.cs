using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<T1, T2> {
    [SerializeField]
    public List<T1> Keys = new();

    [SerializeField]
    public List<T2> Values = new();

    public T2 this[T1 key] {
        get => Get(key);
        set => Set(key, value);
    }

    public void Set(T1 key, T2 value) {
        if (!Keys.Contains(key)) {
            throw new KeyNotFoundException();
        }

        Values[Keys.IndexOf(key)] = value;
    }

    public T2 Get(T1 key) {
        if (!Keys.Contains(key)) {
            throw new KeyNotFoundException();
        }

        return Values[Keys.IndexOf(key)];
    }

    public T2 SafeGet(T1 key, T2 defaultValue) {
        return !Keys.Contains(key) ? defaultValue : Values[Keys.IndexOf(key)];
    }

    public void Add(T1 key, T2 value) {
        if (Keys.Contains(key)) {
            Debug.Log("Such key already exist!");
            return;
        }

        Keys.Add(key);
        Values.Add(value);
    }

    public void Remove(T1 key) {
        if (!Keys.Contains(key)) {
            throw new KeyNotFoundException();
        }

        Values.RemoveAt(Keys.IndexOf(key));
        Keys.Remove(key);
    }

    public bool ContainsKey(T1 key) => Keys.Contains(key);

    public int Count => Keys?.Count ?? 0;
}