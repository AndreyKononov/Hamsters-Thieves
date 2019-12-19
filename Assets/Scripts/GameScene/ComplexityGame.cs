using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexityGame
{
    private readonly DataComlexityGame[] dataComlexityGame = new DataComlexityGame[]
    {
        new DataComlexityGame(0, 0, 3, 1f),
        new DataComlexityGame(10, 0, 3, 1.3f),
        new DataComlexityGame(20, 0, 3, 1.6f),
        new DataComlexityGame(30, 1, 3, 1.9f),
        new DataComlexityGame(40, 1, 3, 2.2f),
        new DataComlexityGame(50, 1, 4, 2.5f),
        new DataComlexityGame(60, 1, 4, 2.8f),
        new DataComlexityGame(70, 1, 4, 3.1f),
        new DataComlexityGame(80, 1, 4, 3.5f),
        new DataComlexityGame(90, 2, 4, 3.5f),
        new DataComlexityGame(100, 2, 5, 3.5f),
        new DataComlexityGame(120, 2, 5, 3.5f),
        new DataComlexityGame(150, 2, 5, 3.5f),
        new DataComlexityGame(200, 3, 5, 3.5f),
        new DataComlexityGame(250, 3, 5, 3.5f),
        new DataComlexityGame(300, 3, 5, 3.5f),
        new DataComlexityGame(400, 3, 6, 3.5f),
        new DataComlexityGame(500, 3, 6, 3.5f),
        new DataComlexityGame(550, 3, 6, 3.5f),
        new DataComlexityGame(600, 3, 6, 3.5f),
        new DataComlexityGame(650, 4, 6, 3.5f),
        new DataComlexityGame(700, 4, 6, 3.5f),
        new DataComlexityGame(800, 4, 6, 3.5f),
        new DataComlexityGame(1000, 4, 6, 3.5f),
        new DataComlexityGame(1500, 5, 6, 3.5f),
    };

    public int MaxCounHamster { get; private set; }

    public void ChangeComplexity(int score)
    {
        foreach (var data in dataComlexityGame)
        {
            if (data.CountScore >= score)
            {
                Time.timeScale = data.TimeScale;
                MaxCounHamster = data.MaxCountHamster;
                break;
            }
        }
    }
}

public struct DataComlexityGame
{
    public int CountScore { get; private set; }
    public int MinCountHamster { get; private set; }
    public int MaxCountHamster { get; private set; }
    public float TimeScale { get; private set; }

    public DataComlexityGame(int countScore, int minCountHamster, int maxCountHamster, float timeScale )
    {
        CountScore = countScore;
        MinCountHamster = minCountHamster;
        MaxCountHamster = maxCountHamster;
        TimeScale = timeScale;
    }
}
