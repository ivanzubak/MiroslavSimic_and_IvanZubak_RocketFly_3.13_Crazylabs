﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraRotate : MonoBehaviour
{
    // Assign in the inspector
    public GameObject objectToRotate;
    public Slider slider;

    private float previousValue;

    void Awake()
    {
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);
        this.previousValue = this.slider.value;
    }

    public void OnSliderChanged(float value)
    {
        float delta = value - this.previousValue;
        this.objectToRotate.transform.Rotate(Vector3.up * delta * 360);

        this.previousValue = value;
    }
}
