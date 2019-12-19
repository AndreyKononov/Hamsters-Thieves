using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text txtScore;
    [SerializeField] private GameObject goPanelSetting;

    private RecordScore recordScore;

    private void Awake()
    {
        recordScore = new RecordScore();

        txtScore.text = recordScore.GetScore().ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSetting()
    {
        goPanelSetting.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
