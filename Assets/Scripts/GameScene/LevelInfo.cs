using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private GameProcess gameProcess;

    [SerializeField] private Text txtHealth;
    [SerializeField] private Text txtScore;

    private RecordScore recordScore = new RecordScore();

    private int healthPoints;
    private int HealthPoints
    {
        get
        {
            return healthPoints;
        }

        set
        {
            if (value > 100)
                healthPoints = 100;
            else if (value < 0)
                healthPoints = 0;
            else
                healthPoints = value;
        }
    }
    public int Score { get; private set; }

    public void SetStartInfo()
    {
        HealthPoints = 100;
        Score = 0;

        txtHealth.text = HealthPoints.ToString();
        txtScore.text = Score.ToString();
    }

    public void SetStartInfoADS()
    {
        HealthPoints = 50;

        txtHealth.text = HealthPoints.ToString();
    }

    private void ChangeHealthPoints(int healthHamster)
    {
        if (HealthPoints == 100)
        {
            if (healthHamster > 0)
                ChangeScore(healthHamster);
        }

        HealthPoints += healthHamster;

        if (HealthPoints == 0)
        {
            recordScore.SaveScore(Score);
            gameProcess.GameOver(Score);   
        }

        txtHealth.text = HealthPoints.ToString();
    }

    private void ChangeScore(int scoreHamster)
    {
        Score += scoreHamster;
        txtScore.text = Score.ToString();
    }

    private void OnEnable()
    {
        Broadcast.ChangeHealthPoints += ChangeHealthPoints;
        Broadcast.ChangeScore += ChangeScore;
    }

    private void OnDisable()
    {
        Broadcast.ChangeHealthPoints -= ChangeHealthPoints;
        Broadcast.ChangeScore -= ChangeScore;
    }
}
