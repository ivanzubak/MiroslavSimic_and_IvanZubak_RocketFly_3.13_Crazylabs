using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControlls : MonoBehaviour
{

    private Touch touch;
    private float speedModifier;
    public GameObject Player;

    void Start()
    {
        speedModifier = 0.01f;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Player.transform.position = new Vector3(
                Player.transform.position.x + touch.deltaPosition.x * speedModifier,
                Player.transform.position.y + touch.deltaPosition.y * speedModifier,
                Player.transform.position.z );
            }
        }
    }
}