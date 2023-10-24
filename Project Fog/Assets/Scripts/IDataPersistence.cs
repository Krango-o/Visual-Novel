using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    abstract void LoadData(GameData gameData);
    public void SaveData(ref GameData gameData)
    {

    }
}
