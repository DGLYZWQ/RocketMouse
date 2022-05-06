using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexScroll : MonoBehaviour {

	public Renderer ParalaxBefore;
	public Renderer ParalaxBack;
	public float BeforeScrollSpeed = 0.1f;
	public float BackScrollSpeed = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float BeforeScroll = BeforeScrollSpeed * Time.timeSinceLevelLoad;
		float BackScroll = BackScrollSpeed * Time.timeSinceLevelLoad;
		ParalaxBefore.material.mainTextureOffset = new Vector2(BeforeScroll, 0);
		ParalaxBack.material.mainTextureOffset = new Vector2(BackScroll, 0);
	}
}
