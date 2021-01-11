using UnityEngine;
using System;
using System.Collections;

public class RandFood : MonoBehaviour 
{

	public double Size = 12.95f;
	public GameObject foodPrefab;
	public GameObject curFood;
	public GameObject LightFood;
	public GameObject LightPrefab;
	public Vector3 LightPos;
	public Vector3 curPos;
	public void AddNewFood()
	{
		RandomPos(ref curPos);
		LightPos = new Vector3(curPos.x, curPos.y + 2.5f, curPos.z);
		LightFood = GameObject.Instantiate(LightPrefab, LightPos, Quaternion.identity) as GameObject;
		curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.identity) as GameObject;
	}
	public ref Vector3 RandomPos(ref Vector3 vector3)
	{
		System.Random rand = new System.Random();
		double x = Math.Truncate((rand.NextDouble() * (Size * 2) - Size) / 1.85f); 
		double z = Math.Truncate((rand.NextDouble() * (Size * 2) - Size) / 1.85f); 
		if (x % 2 == 0)
			x = Math.Abs(x) - 1;
		if (z % 2 == 0)
			z = Math.Abs(z) - 1;
		vector3 = new Vector3(Convert.ToSingle(x * 1.85f), 0.5f, Convert.ToSingle(z * 1.85f));
		return ref vector3;
	}

	void Update()
	{
		if(!curFood)
		{
			AddNewFood();
		}
		else
		{
			return;
		}
	}
}
