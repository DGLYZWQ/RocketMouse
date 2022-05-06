using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject Mouse;
    private mouse m;
    private void Start()
    {
        m = Mouse.GetComponent<mouse>();
    }
	public void ToggleChange(bool change)
    {
        Debug.Log(change);
        m.canRotate = change;
    }
    public void SliderChange(float speed)
    {
        Debug.Log(speed);
        m.rotaio = speed;
    }
}
