using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
	private float screenInWidthPoints;       //手机屏幕宽度
	public GameObject ExplainPoint;
	private float addX;                  //添加房间临界点
	public GameObject LastRoom;          //记录最后一个房间
	private GameObject LastObject;

	public GameObject[] AvailableRooms;    //需要生成的房间集合
	public GameObject[] AvailableObjects;  //所有道具
	//离最后一个道具的最小和最大距离
	public float mindistanceX = 5.0f;
	public float maxdistanceX = 10.0f;
	//最小和最大高度Y坐标
	public float minheight = -1.4f;
	public float maxheight = 1.4f;
	//旋转最小和最大角度
	public float rotateMinAngle = -45.0f;
	public float rotateMaxAngle = 45.0f;

	//private void Awake()
	//   {
	//	screenInWidthPoints = 2.0f * Camera.main.orthographicSize * Camera.main.aspect; 
	//	Debug.Log(screenInWidthPoints);
	//   }

	// Use this for initialization
	void Start() {
		//计算屏幕宽度=正交size*2*纵横比
		screenInWidthPoints = 2.0f * Camera.main.orthographicSize * Camera.main.aspect;
		//Mouse = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//计算添加房间的临界点
		addX = transform.position.x + screenInWidthPoints;
		//ExplainPoint.transform.position = new Vector3(
		//	Mouse.position.x + screenInWidthPoints,
		//	Mouse.position.y,
		//	0);
		//Debug.DrawLine(ExplainPoint.transform.position, Mouse.position,Color.red);
		//生成房间
		GenerateRooms();
		//不断生成道具
		GenerateObjects();
	}
	void GenerateRooms()
    {
		bool addRoom = true;
		//最后一个房间的宽度
		float lastRoomWidth = LastRoom.transform.Find("floor").localScale.x;
		//最后一个房间的右侧的x坐标
		float roomEndx = LastRoom.transform.position.x + 0.5f * lastRoomWidth;
		//float addX = Mouse.position.x + screenInWidthPoints;
		//float roomWidth = LastRoom.transform.Find("floor").localScale.x;
		//Debug.Log(roomWidth);
		//最后那个房间的右侧x
		//float endX = LastRoom.transform.position.x + 0.5f * roomWidth;
		if(roomEndx < addX)
        {
			addRoom = true;
        }
        else
        {
			addRoom = false;
        }
		if(addRoom)
        {
			//生成房间
			AddRooms(roomEndx);
        }
    }
	//生成新房间，要以最后一个房间的右边X坐标计算新房间的坐标
	private void AddRooms(float lastRoomEndX)
    {
		//随机生成一个序号
		int roomIndex = Random.Range(0, AvailableRooms.Length);
		//实例化一个房间
		GameObject newRoom = Instantiate(AvailableRooms[roomIndex]);
		//新房间宽度
		float newRoomWidth = newRoom.transform.Find("floor").localScale.x;
		//新房间的右侧X=最后一个房间右侧X+新房间宽度/2
		float newRoomX = lastRoomEndX + 0.5f * newRoomWidth;
		//设置新房间的坐标
		newRoom.transform.position = new Vector3(newRoomX, 0, 0);
		//重置LastRoom 新生成的房间变成最后一个房间
		LastRoom = newRoom;
		// newRoom.transform.rotation = Quaternion.identity;    新房间不旋转
		//Debug.Log("add room");
	}
	void GenerateObjects()
    {
		bool addObject = true;
		//界面上没有道具或道具在添加点左边了，需要添加道具了
		if (this.LastObject == null ||
			this.LastObject.transform.position.x < addX)
		{
			addObject = true;
		}
		//最后一个道具还没到添加的临界点
		else if (this.LastObject != null &&
				this.LastObject.transform.position.x > addX)
		{
			addObject = false;
		}
		if (addObject)
		{
			AddObjects();
		}
		//int rndObjectIndex = Random.Range(0, AvailableObjects.Length);
		//GameObject newObject = Instantiate(AvailableObjects[rndObjectIndex]);
		//float distance = Random.Range(mindistanceX, maxdistanceX);
		//float newObjectY = Random.Range(minheight, maxheight);
		//float rotate = Random.Range(rotateMinAngle, rotateMaxAngle);
		//float newObjectX = LastObject == null ? 0 : LastObject.transform.position.x + distance;
		//newObject.transform.position = new Vector3(newObjectX, newObjectY, 0);
		//newObject.transform.rotation = Quaternion.Euler(0, 0, rotate);
		//LastObject = newObject;
	}
	void AddObjects()
    {
		//从道具中随机抽个序号
		int index = UnityEngine.Random.Range(0,
			AvailableObjects.Length);
		//道具的x坐标（如果界面上还没有道具，则为0，有则得到最后一个道具的X坐标）
		float lastObjectX = LastObject == null ?
			0 : LastObject.transform.position.x;
		//新道具的x坐标=最后一个道具的x坐标+一个随机的水平距离
		float posX = lastObjectX +
			UnityEngine.Random.Range(
				mindistanceX,
				maxdistanceX);
		//新道具的y坐标=一个随机高度
		float posY = UnityEngine.
			Random.Range(minheight,
			maxheight);
		//新道具的角度=随机一个角度
		float rotate = UnityEngine.Random.Range(
			rotateMinAngle,
			rotateMaxAngle);
		//生成新道具
		GameObject newObj = Instantiate(AvailableObjects[index]);
		newObj.transform.position = new Vector3(posX, posY, 0);
		newObj.transform.rotation = Quaternion.Euler(0, 0, rotate);
		//重置最后的道具
		LastObject = newObj;
	}
}
