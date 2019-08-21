using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour   //можно применить делегаты
{
    public static UIController Instance;
    public Text bananasAmountTxt;
    public Text bananasPerSecTxt;
    public Image playButton;
    public Text minionCostTxt;
    public Text minionAmountTxt;
    public Text modifierCostTxt;
    public Text modifierTxt;

    private Sprite playButtonSprite;
    private Sprite pauseButtonSprite;
    
    void Awake()
    {
        Instance = this;

        playButtonSprite = Resources.Load<Sprite>("UI/PlayButton");
        pauseButtonSprite = Resources.Load<Sprite>("UI/PauseButton");

    }

    void Start()
    {
        LoadDataToUI();

        UpdateMinionButtonTxt();
        UpdateModifierButtonTxt();
    }

    private void LoadDataToUI()
    {
        bananasAmountTxt.text = DataManager.Instance.GetBananaAmount().ToString();
        bananasPerSecTxt.text = DataManager.Instance.GetBananaPerSec().ToString();
    }

    public void UpdateBananasAmountText(string value){
        bananasAmountTxt.text = value;
    }

    public void UpdateBananasPerSecText(string value)
    {
        bananasPerSecTxt.text = value;
    }

    public void SetSpriteToPlayButton()
    {
        if(GameManager.Instance.gameStatus == GameManager.GameStatus.game)
        {
            playButton.sprite = playButtonSprite;
            GameManager.Instance.gameStatus = GameManager.GameStatus.pause;
        }
        else if(GameManager.Instance.gameStatus == GameManager.GameStatus.pause)
        {
            playButton.sprite = pauseButtonSprite; 
            GameManager.Instance.gameStatus = GameManager.GameStatus.game;      
        }
    }

    public void UpdateMinionButtonTxt()
    {
        minionCostTxt.text = MinionsManager.Instance.minionCost.ToString();
        minionAmountTxt.text = MinionsManager.Instance.MinionsAmount.ToString();
    }

    public void UpdateModifierButtonTxt()
    {
        modifierCostTxt.text = BananasManager.Instance.bananaModifierCost.ToString();
        modifierTxt.text = BananasManager.Instance.BananasPerSec.ToString();
    }
}
