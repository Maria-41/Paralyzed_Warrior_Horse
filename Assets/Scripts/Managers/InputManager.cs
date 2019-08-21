using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {

    }

    public void OnDetectClick()
    {
        if (GameManager.Instance.gameStatus == GameManager.GameStatus.game)
        {
            BananasManager.Instance.AddBananas();
            UIController.Instance.UpdateBananasAmountText(BananasManager.Instance.BananasAmount.ToString());
            PlayerController.Instance.RotatePlayer();
        }
    }

    public void OnBuyMinionClick()
    {
        MinionsManager.Instance.BuyMinion();
    }

    public void OnBuyImproClick()
    {
        BananasManager.Instance.AddBananasPerSec();
        UIController.Instance.UpdateBananasPerSecText(BananasManager.Instance.BananasPerSec.ToString());
    }

    public void OnPlayPauseButtonClick()
    {
        UIController.Instance.SetSpriteToPlayButton();
    }

}

