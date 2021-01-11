using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Food : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("SnakeHead"))
		{
			Destroy(gameObject);
			other.GetComponent<SnakeMovment>().AddTail();
			other.GetComponent<SnakeMovment>().SaveRecord();
		}
	}

}
