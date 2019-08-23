using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteSettingsHelper : MonoBehaviour
{
    public static RemoteSettingsHelper Instance;

    private int startModifier;

    void Awake()
    {
        Instance = this;

        RemoteSettings.Updated += GetValuesFromRS;
        GetValuesFromRS();
    }

    private void GetValuesFromRS()
    {
        startModifier = RemoteSettings.GetInt("StartModifier", 10);
    }

    public int GetStartModifier()
    {
        return startModifier;
    }
}
