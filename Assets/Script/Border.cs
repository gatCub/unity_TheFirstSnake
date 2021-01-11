using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Border : MonoBehaviour
{
	public AudioSource AuDead;
	public GameObject ObjectActive;
	public Light lite;
	public AudioSource Audio;

	void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("SnakeHead"))
		{
			other.GetComponent<SnakeMovment>().StopSnake();
			other.GetComponent<SnakeMovment>().Screan();
		}

	}

	public void Restart()
	{
		SceneManager.LoadScene("SnakeGame88");
	}

	public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}
}
