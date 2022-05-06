using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour {

    public void ButtonTest()
    {
        Debug.Log("Button Pressed");
    }
    public void SetToggle(bool toggleChecked)
    {
        Debug.Log(toggleChecked);
    }
    public void SetSlider(float sliderValue)
    {
        Debug.Log(sliderValue);
    }
}
