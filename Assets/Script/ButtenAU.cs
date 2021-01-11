using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtenAU : MonoBehaviour
{
    public AudioSource audioS;

    /*private void Start()
    {
        if (PlayerPrefs.HasKey("Sfx"))
            PlayerPrefs.SetInt("Sfx", 0);
    }*/

    public void CkickSound()
    {
        if (PlayerPrefs.GetInt("Sfx") == 1)
        {
            audioS.Play();
        }
        else return;
    }
}
