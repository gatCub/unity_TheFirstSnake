using UnityEngine;
using System.Collections;

public class DeadLight : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("SnakeHead"))
		{
			Destroy(gameObject);
		}
	}

}