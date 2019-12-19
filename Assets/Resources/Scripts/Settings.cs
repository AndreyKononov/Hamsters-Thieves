using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject supportPanel;

    [Space(10)]
    [Header("Components Music")]
    [SerializeField] private Image imgMusic;
    [SerializeField] private Sprite musicSpriteOn;
    [SerializeField] private Sprite musicSpriteOff;

    [Space(10)]
    [Header("Components Sound")]
    [SerializeField] private Image imgSound;
    [SerializeField] private Sprite soundSpriteOn;
    [SerializeField] private Sprite soundSpriteOff;

    [Space(10)]
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioSource audioSourceSound;
    [SerializeField] private GameObject hamsterSound;

    private string nameKeySettingMusic = "hamster_music";
    private string nameKeySettingSound = "hamster_sound";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(nameKeySettingMusic))
            PlayerPrefs.SetInt(nameKeySettingMusic, 1);

        if (!PlayerPrefs.HasKey(nameKeySettingSound))
            PlayerPrefs.SetInt(nameKeySettingSound, 1);

        ChangeSettingMusic();
        ChangeIconSound();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickButton()
    {
        audioSourceSound.Play();
    }

    public void OpenSetting()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    public void OpenSupportWindows()
    {
        supportPanel.SetActive(true);
    }

    public void CloseSupportWindows()
    {
        supportPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ClickButtonSettingMusic()
    {
        if (PlayerPrefs.GetInt(nameKeySettingMusic) == 1)
        {
            PlayerPrefs.SetInt(nameKeySettingMusic, 0);
        }
        else
        {
            PlayerPrefs.SetInt(nameKeySettingMusic, 1);
        }

        ChangeSettingMusic();
    }

    public void ClickButtonSettingSound()
    {
        if (PlayerPrefs.GetInt(nameKeySettingSound) == 1)
        {
            PlayerPrefs.SetInt(nameKeySettingSound, 0);
        }
        else
        {
            PlayerPrefs.SetInt(nameKeySettingSound, 1);
        }

        ChangeIconSound();
    }

    private void ChangeSettingMusic()
    {
        if (PlayerPrefs.GetInt(nameKeySettingMusic) == 1)
        {
            imgMusic.sprite = musicSpriteOn;
            audioSourceMusic.enabled = true;
        }
        else
        {
            imgMusic.sprite = musicSpriteOff;
            audioSourceMusic.enabled = false;
        }
    }

    private void ChangeIconSound()
    {
        if (PlayerPrefs.GetInt(nameKeySettingSound) == 1)
        {
            imgSound.sprite = soundSpriteOn;
            audioSourceSound.enabled = true;
        }
        else
        {
            imgSound.sprite = soundSpriteOff;
            audioSourceSound.enabled = false;
        }
    }

}
