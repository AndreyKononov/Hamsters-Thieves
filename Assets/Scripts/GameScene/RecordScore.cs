using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordScore
{
    private string hamsterScore = "hamster_score";

    public void SaveScore(int score)
    {
        if (GetScore() < score)
            PlayerPrefs.SetInt(hamsterScore, score);
    }

    public int GetScore()
    {
        if (PlayerPrefs.HasKey(hamsterScore))
        {
            return PlayerPrefs.GetInt(hamsterScore);
        }

        return 0;
    }
}
