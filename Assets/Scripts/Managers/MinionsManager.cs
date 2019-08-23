using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsManager : MonoBehaviour
{
    public static MinionsManager Instance;
    public GameObject[] minionsPrefabs;
    public Transform minionsZone;
    public float minionOffsetX = 0;
    public float minionOffsetY = 0;
    public int minionCost = 10;


    private int minionsAmount = 0;
    private float startOffset;
    private float startXCoordinate;
    private Vector2 startPosition;
    private int minionsRow = 0;
    private int maxMinionsAmount = 26;  //'cause more than 30 minions are not displayed on the playing field correctly
    private List<int> minions = new List<int>();

    public int MinionsAmount { get => minionsAmount;}

    void Awake()
    {
        Instance = this;

        startOffset = minionOffsetX;

        startPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0));
        startXCoordinate = startPosition.x - minionOffsetX;

        SpawnSavedMinions();
    }

    public void BuyMinion()
    {   
        if(minionsAmount >= maxMinionsAmount)
            {
                Debug.Log("You bought the all minions");
                return;
            }
        if(!BananasManager.Instance.BuyItem(minionCost))
        {
            Debug.Log("Not enough money");
            return;
        }
        else
        {
            minionsAmount ++;
            SpawnMinion();
            UIController.Instance.UpdateMinionButtonTxt();
        }
    }

    private void SpawnMinion()
    {
        int idx = Random.Range(0, 2); // to choose the one of two minion's sprites     

        

        InstantiateMinion(idx);
        
        SaveMinions();
    }

    private void InstantiateMinion(int idx, int rowIdx = 0)
    {
        minions.Add(idx);


        if(startPosition.x - minionOffsetX < -startXCoordinate)
        {
            if(minionsRow %2 == 0)
                minionOffsetX = startOffset + 0.3f;
            else
            {
                minionOffsetX = startOffset;
            }
            minionOffsetY -= 0.5f;
            minionsRow++;
        }
        GameObject minion = Instantiate(minionsPrefabs[idx], new Vector2(startPosition.x - minionOffsetX, minionOffsetY), Quaternion.identity);
        minion.transform.SetParent(minionsZone);
        minion.GetComponent<SpriteRenderer>().sortingOrder = minionsAmount;

        if(startPosition.x - minionOffsetX >= -startXCoordinate)
        { 
            minionOffsetX += startOffset;
        }

    }

    private void SpawnSavedMinions()
    {
        if(DataManager.Instance.GetMinionsTypes() == null)
            return;

        string[] savedMinions = DataManager.Instance.GetMinionsTypes().Split(',');
        int type = 0;

        startPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0));
        startXCoordinate = startPosition.x - minionOffsetX;

        for(int i = 0; i < savedMinions.Length; i++)
        {
            int.TryParse(savedMinions[i], out type);
            
            minionsAmount ++;

            InstantiateMinion(type);
        }

    }

    private void SaveMinions()
    {
        string minionsTypes = "";
        for (int i = 0; i < minions.Count; i++)
        {
            if(i < minions.Count-1)
                minionsTypes += (minions[i].ToString() + ",");
            else
                minionsTypes += minions[i].ToString();
        }
        DataManager.Instance.SaveMinionsTypes(minionsTypes);
    }
}
