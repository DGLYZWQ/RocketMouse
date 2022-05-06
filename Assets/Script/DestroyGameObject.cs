using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {
	private float distince;
	private GameObject mouse;
	private void Awake()
    {
		mouse = GameObject.FindGameObjectWithTag("Player");
    }
	// Use this for initialization
	void Start() {
		distince = Camera.main.orthographicSize * 2.0f * Camera.main.aspect;
	}
		//Destroy(gameObject, 15.0f);
	
	
	// Update is called once per frame
	void Update() {
    float removeX = mouse.
          transform.position.x - distince;
    if (gameObject.tag == "room")
    {
        //如果右侧x<removeX,可以del(预期值14.4)
        float roomWidth = gameObject.
            transform.Find("floor").localScale.x;
        float roomEndx = transform.position.x
            + 0.5f * roomWidth;
        if (roomEndx < removeX)
        {
            Destroy(gameObject);
        }
    }
    else{
        //x坐标小于移除点
        if (transform.position.x < removeX)
        {
            Destroy(gameObject);
        }
    }
    }	
}
