using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameStatus gameStatus;

    public enum GameStatus
    {
        game,
        pause
    }

    void Awake()
    {
        Instance = this;
        gameStatus = GameStatus.game;
    }

    void Update()
    {
        
    }

}
