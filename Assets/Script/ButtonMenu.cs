using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour
{
    public bool isFullScreen = false;
    public int intSfx;
    public Toggle toggleFullScreen;
    public Toggle toggleSfxAudio;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Sfx"))
            intSfx = PlayerPrefs.GetInt("Sfx");
        else intSfx = 0;
        switch (intSfx)
        {
            case 1: { toggleSfxAudio.isOn = true;  intSfx = 1; } break;
            case 0: { toggleSfxAudio.isOn = false; intSfx = 0; } break;
        }
        PlayerPrefs.SetInt("Sfx", intSfx);
        if (Screen.fullScreen)
        {
            toggleFullScreen.isOn = true;
        }
    }
    public void NewGame8()
    {
        SceneManager.LoadScene("SnakeGame88");
    }

    public void Exit()
    {
        Application.Quit();
        PlayerPrefs.DeleteKey("");
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void SfxVolumeToggle()
    {
        if (intSfx == 1)    intSfx = 0;
        else                intSfx = 1;
        PlayerPrefs.SetInt("Sfx", intSfx);
        //PlayerPrefs.Save();
    }

}
