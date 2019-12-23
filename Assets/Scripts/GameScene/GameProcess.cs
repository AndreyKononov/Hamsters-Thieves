using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour
{
    [SerializeField] private TimerStartGame timerStartGame;
    [SerializeField] private SpawnerHamsters spawnerHamsters;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text txtScore;
    [SerializeField] private LevelInfo levelInfo;

    private PoolHamsters poolHamsters;
    private PoolPositions poolPositions;

    private void Awake()
    {
        poolHamsters = GetComponent<PoolHamsters>();
        poolPositions = GetComponent<PoolPositions>();
    }

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return StartCoroutine(timerStartGame.CoroutineStartTimer());

        yield return new WaitForSeconds(1);

        spawnerHamsters.StartGame();
    }

    public void GameOver( int score )
    {
        gameOverScreen.SetActive(true);
        txtScore.text = score.ToString();

        spawnerHamsters.StopGame();
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        StartCoroutine(StartGame());

        levelInfo.SetStartInfo();
        gameOverScreen.SetActive(false);
    }

    public void ContinueGameAD()
    {
        StartCoroutine(StartGame());

        levelInfo.SetStartInfoADS();
        gameOverScreen.SetActive(false);
    }
}
