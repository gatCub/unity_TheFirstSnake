using UnityEngine;
using System.Collections;
using System;

public class BodyMovment : MonoBehaviour {

	public float Speed;
	public Vector3 tailTarget;
	public int indx;
	public GameObject tailTargetObj;
	public SnakeMovment mainSnake;
	AudioSource AuDead;
	void Start()
	{
		mainSnake = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovment>();
		Speed = mainSnake.Speed + 2.5f;
		tailTargetObj = mainSnake.tailObjects[mainSnake.tailObjects.Count - 2];
		indx = mainSnake.tailObjects.IndexOf(gameObject);
	}
	void Update () 
	{
		tailTarget = tailTargetObj.transform.position;
		transform.LookAt(tailTarget);
		transform.position = Vector3.Lerp(transform.position,tailTarget,Time.deltaTime*Speed);
	}

	void OnTriggerEnter(Collider other)
	{
		
		if(other.CompareTag("SnakeHead"))
		{
			if(indx > 10)
			{
				other.GetComponent<SnakeMovment>().StopSnake();
				other.GetComponent<SnakeMovment>().Screan();
			}
		}

	}

}
