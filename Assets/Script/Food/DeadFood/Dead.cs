using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("SnakeHead"))
		{
			Destroy(gameObject);
			other.GetComponent<SnakeMovment>().SnakeDamage();
			other.GetComponent<SnakeMovment>().SaveRecord();
		}
	}

}