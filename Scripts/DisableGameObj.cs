using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObj : MonoBehaviour
{

    public GameObject DisableObjectthis;

    void Update()
    {
        StartCoroutine(DisableObject());

    }

    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(3.0f);

        DisableObjectthis.SetActive(false);

    }
}
