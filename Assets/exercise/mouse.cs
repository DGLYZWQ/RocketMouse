using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour {
	public float RotateSpeed = 2.0f;
	public bool canRotate = true;
	public float rotaio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.canRotate)
        {
			transform.Rotate(new Vector3(0, 0,this.rotaio * RotateSpeed * Time.deltaTime));
		}
		
	}
}
