using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocalisedString
{
    public string Key;

    public LocalisedString(string key)
    {
        Key = key;
    }

    public string Value => LocalizationSystem.GetLocalisedValue(Key);

    public static implicit operator LocalisedString(string key)
    {
        return new LocalisedString(key);
    }
}
