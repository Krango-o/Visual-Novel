using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject
{
    public int slot;
    public string date;
    public string sceneName;
    public int line;
    public Dictionary<string, string> choices;
}
