using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    void Awake()
    {
        Instance = this;
    }
    
    public void SaveBananaAmount(int value)
    {
        PlayerPrefs.SetInt("BananasAmount", value);
    }

    public void SaveBananaPerSec(int value)
    {
        PlayerPrefs.SetInt("BananasPer", value);
    }

    public void SaveMinionsAmount(int value)
    {
        PlayerPrefs.SetInt("MinionsAmount", value);
    }

    public void SaveMinionsTypes(string value)
    {
        PlayerPrefs.SetString("MinionsTypes", value);
    }

    public int GetBananaAmount()
    {
        if(PlayerPrefs.HasKey("BananasAmount"))
            return PlayerPrefs.GetInt("BananasAmount");
        else
            return 0;
    }

    public int GetBananaPerSec()
    {
        if(PlayerPrefs.HasKey("BananasPer"))
            return PlayerPrefs.GetInt("BananasPer");
        else
            return RemoteSettingsHelper.Instance.GetStartModifier();
    }

    public int GetMinionsAmount()
    {
        if(PlayerPrefs.HasKey("MinionsAmount"))
            return PlayerPrefs.GetInt("MinionsAmount");
        else
            return 0;
    }

    public string GetMinionsTypes()
    {
        if(PlayerPrefs.HasKey("MinionsTypes"))
            return PlayerPrefs.GetString("MinionsTypes");
        else
            return null;
    }

}
