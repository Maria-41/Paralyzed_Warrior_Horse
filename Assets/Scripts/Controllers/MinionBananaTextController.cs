using System.Collections;
using UnityEngine;

public class MinionBananaTextController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DisableObject());
    }

    void OnEnable()
    {
        StartCoroutine(DisableObject());
    }

   IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
