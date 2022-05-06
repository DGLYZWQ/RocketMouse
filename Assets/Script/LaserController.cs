using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {
	public Sprite LaserOn;
	public Sprite LaserOff;

	private SpriteRenderer ren;
	private bool IsLaserOn = true;

	public float MyTimer = 1.0f;
	private float Switch_Timer = 0;
	private BoxCollider2D coli;
	// Use this for initialization
	void Start () {
		ren = GetComponent<SpriteRenderer>();
		coli = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Switch_Timer += Time.deltaTime;
		if(Switch_Timer>MyTimer)
        {
			IsLaserOn = !IsLaserOn;  //自动求反
			Switch_Timer = 0;
        }
		if(ren)
        {
			ren.sprite = IsLaserOn ? LaserOn : LaserOff;
        }
		if(coli)
        {
			coli.enabled = IsLaserOn;
        }
	}
}
