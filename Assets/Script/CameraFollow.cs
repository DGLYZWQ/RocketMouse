using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private Transform Mouse;
	private float distX;
	// Use this for initialization
	void Start () {
		Mouse = GameObject.FindGameObjectWithTag("Player").transform;
		if (Mouse)
		{
			distX = transform.position.x - Mouse.position.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void LateUpdate()
    {
		if (Mouse)
		{
			transform.position = new Vector3(
				Mouse.position.x + distX,
				transform.position.y,
				transform.position.z);
		}
    }
}
