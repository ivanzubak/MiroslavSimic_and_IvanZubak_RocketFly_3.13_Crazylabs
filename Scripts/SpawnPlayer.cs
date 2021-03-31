using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject objToTP;
    public Transform tpLoc;


    public void TeleportPlayer()
    {
        transform.position = new Vector3(-15.38f, 1.93f, 62.1f);
    }
}

