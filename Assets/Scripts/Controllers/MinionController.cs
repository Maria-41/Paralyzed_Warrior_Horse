using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public float timeToIssueBanana;
    public int bananas;

    private float timer;

    void Update()
    {
        if (GameManager.Instance.gameStatus == GameManager.GameStatus.game)
        {
            timer += Time.deltaTime;
            if (timer >= timeToIssueBanana)
            {
                BananasManager.Instance.AddMinionBananas(bananas);
                PopupManager.Instance.SetActiveBananaText(this.gameObject, bananas);
                timer = 0;
            }
        }
    }
}
