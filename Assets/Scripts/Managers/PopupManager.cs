 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;

    public GameObject bananaPopUpPrefab;
    public Transform bananaPopUpParent;
    public float spawnOffsetY = 0;

    private List<GameObject> bananaPopUptexts = new List<GameObject>();

    void Awake()
    {
        Instance = this;
        InstantiateBananaCountTxt();
    }

    void InstantiateBananaCountTxt()
    {
        int count = 10; //number of texts on the field - max count of texts, which can be active at the same time
        for(int i = 0; i < count; i++)
        {
            GameObject bananaText = Instantiate(bananaPopUpPrefab);
            bananaText.SetActive(false);
            bananaText.transform.SetParent(bananaPopUpParent);
            bananaPopUptexts.Add(bananaText);
        }
    }

    public void SetActiveBananaText(GameObject caller, int bananas)
    {
        for (int i = 0; i < bananaPopUptexts.Count; i++)
        {
            if(bananaPopUptexts[i].activeInHierarchy == false)
            {
                Vector3 viewportPoint = Camera.main.WorldToViewportPoint(caller.transform.position);  

                RectTransform bananaTexttransform = bananaPopUptexts[i].GetComponent<RectTransform>();

                bananaTexttransform.anchorMin = viewportPoint;
                bananaTexttransform.anchorMax = viewportPoint;
                bananaTexttransform.anchoredPosition = new Vector3(0, spawnOffsetY, 0);
                bananaTexttransform.localScale = Vector3.one;

                bananaPopUptexts[i].GetComponent<Text>().text = "+" + bananas;
                bananaPopUptexts[i].SetActive(true);
                i = bananaPopUptexts.Count;
            }
        }
    }

}
