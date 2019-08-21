using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananasManager : MonoBehaviour
{
    public static BananasManager Instance;

    public int bananaModifierCost;

    private int bananasAmount = 0;
    private int bananaModifier = 10;

    public int BananasAmount { get => bananasAmount;}
    public int BananasPerSec { get => bananaModifier;}

    void Awake()
    {
        Instance = this;
        LoadData();
    }
    
    private void LoadData()
    {
        bananasAmount = DataManager.Instance.GetBananaAmount();
        bananaModifier = DataManager.Instance.GetBananaPerSec();
    }

    public void AddBananas()
    {
        bananasAmount += bananaModifier;

        DataManager.Instance.SaveBananaAmount(bananasAmount);
    }

    public void AddMinionBananas(int value)
    {
        bananasAmount += value;
        UIController.Instance.UpdateBananasAmountText(bananasAmount.ToString());

        DataManager.Instance.SaveBananaAmount(bananasAmount);        
    }

    public void AddBananasPerSec()
    {
        if(!BuyItem(bananaModifierCost))
        {
            Debug.Log("Not enough money");
            return;
        }
        else
        {
            bananaModifier = (int)(1.1f * bananaModifier);
            DataManager.Instance.SaveBananaPerSec(bananaModifier);
            UIController.Instance.UpdateModifierButtonTxt();
        }
    }

    public bool BuyItem(int cost)
    {
        if(bananasAmount >= cost)
        {
            bananasAmount -= cost;
            UIController.Instance.UpdateBananasAmountText(bananasAmount.ToString());
            return true;
        }
        else
        {
            return false;
        }
    }
}
