using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderInput : MonoBehaviour
{
    public Slider slider;
    public Data data;

    private void Start()
    {
        slider.value = data.sens;
    }
    void Update()
    {
        Muwer.rid.sensitivity = slider.value;
        data.sens = slider.value;
    }
}
