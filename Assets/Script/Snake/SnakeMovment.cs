using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class SnakeMovment : MonoBehaviour 
{

	public float Speed;
	public float r;
	public float s;
	public int score;
	public bool pause; 
	public bool DeadThis; //
	public List<GameObject> tailObjects = new List<GameObject>();
	public GameObject TailPrefab;
	public GameObject ObjectActive;
	public GameObject PauseEsc; 
	public GameObject StopBody;
	public GameObject AminObject1;
	public GameObject AminObject2;
	public GameObject AminObject3;
	public GameObject AminObject4;
	public GameObject AminObject5;
	public Animation Anim1;
	public Animation Anim2;
	public Animation Anim3;
	public Animation Anim4;
	public Animation Anim5;
	public Text ScoreText;
	public Text RecordText;
	public AudioSource Audio;
	public AudioSource AudioEt;
	public Light lite;
	public Image imgON;  //
	public Image imgOFF; //

	void Start () 
	{
		Anim1 = AminObject1.GetComponent<Animation>();
		Anim2 = AminObject2.GetComponent<Animation>();
		Anim3 = AminObject3.GetComponent<Animation>();
		Anim4 = AminObject4.GetComponent<Animation>();
		Anim5 = AminObject5.GetComponent<Animation>();
		Speed = 10f;
		r = 180f;
		s = 0.6f;
		pause = false;
		DeadThis = false;
		tailObjects.Add(gameObject);
		if (!PlayerPrefs.HasKey("Record"))
			PlayerPrefs.SetInt("Record", 0);
		score = 1;
		ScoreText.text = score.ToString();
		RecordText.text = PlayerPrefs.GetInt("Record").ToString();
	}

	void Update () 
	{
		transform.Translate(Vector3.forward * Speed * Time.deltaTime);

		if((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
		{
			transform.Rotate(Vector3.up * r * Time.deltaTime);
		}
		if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
		{
			transform.Rotate(Vector3.up * -1 * r * Time.deltaTime);
		}
		if ((Input.GetKeyDown(KeyCode.Escape)) && (!DeadThis))
		{
			if (!pause)
			{
				GamePause();
				pause = !pause;
			}
			else
			{
				GameStart();
				pause = !pause;
			}
		}
	}

	public void AddTail()
	{
		score++;
		ScoreText.text = score.ToString();
		if (PlayerPrefs.GetInt("Sfx") == 1)
			AudioEt.Play();
		Vector3 newTailPos = tailObjects[tailObjects.Count-1].transform.position;
		newTailPos.z -= s;
		tailObjects.Add(GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject);
		TailPrefab.transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
	}

	public void Screan()
	{
		Anim5.Play("AppearanceDead");
		if (PlayerPrefs.GetInt("Sfx") == 1)
			Audio.Play();
		ObjectActive.SetActive(true);
		lite.enabled = false;
		for (int i = 1; i < tailObjects.Count; i++)
		{
			StopBody = tailObjects[i];
			StopBody.GetComponent<BodyMovment>().Speed = 0f;
		}
		DeadThis = true;
	}

	public void SnakeDamage()
	{
		score /= 2;
		ScoreText.text = score.ToString();
		if (score <= 0)
		{
			StopSnake();
			Screan();
		}
		else if (PlayerPrefs.GetInt("Sfx") == 1)
			AudioEt.Play();
	}

	public void SaveRecord()
	{
		if (score > PlayerPrefs.GetInt("Record"))
		{
			PlayerPrefs.SetInt("Record", score);
		}
	}

	public void StopSnake()
	{
		Speed = 0f;
		r = 0f;
	}

	public void GamePause()
	{
		PauseEsc.SetActive(true);
		Anim1.Play("Appearance1");
		Anim2.Play("Appearance2");
		Anim3.Play("Appearance3");
		Anim4.Play("Appearance4");
		Speed = 0f;
		r = 0f;
		for (int i = 1; i < tailObjects.Count; i++)
		{
			StopBody = tailObjects[i];
			StopBody.GetComponent<BodyMovment>().Speed = 0f;
		}
	}

	public void GameStart()
	{
		Anim4.Play("Appearance44");
		PauseEsc.SetActive(false);
		Speed = 10f;
		r = 180f;
		for (int i = 1; i < tailObjects.Count; i++)
		{
			StopBody = tailObjects[i];
			StopBody.GetComponent<BodyMovment>().Speed = 12.5f;
		}
	}

}
