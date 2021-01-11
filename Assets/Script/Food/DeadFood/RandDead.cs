using UnityEngine;
using System;
using System.Collections;

public class RandDead : MonoBehaviour
{

	public Vector3 DeadPos;
	public Vector3 LightPos;
	public GameObject DeadPrefab;
	public GameObject LightPrefab;
	public GameObject LightDead;
	public GameObject DeadFood;
	SnakeMovment score = new SnakeMovment();
	RandFood rnd = new RandFood();
	public double Size = 12.95f;
	public void AddNewDead()
	{
		if (DeadFood && LightDead)
		{
			Destroy(DeadFood);
			Destroy(LightDead);
		}
			
		rnd.RandomPos(ref DeadPos);
		LightPos = new Vector3(DeadPos.x, DeadPos.y + 2.5f, DeadPos.z);
		LightDead = GameObject.Instantiate(LightPrefab, LightPos, Quaternion.identity) as GameObject;
		DeadFood = GameObject.Instantiate(DeadPrefab, DeadPos, Quaternion.identity) as GameObject;
	}

	void Start()
	{
		InvokeRepeating("AddNewDead", 1f, 5f);
	}

}