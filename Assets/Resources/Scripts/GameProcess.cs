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
        //test changes
        //test test
        //bla bla bla

        Time.timeScale = 2f;
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return StartCoroutine(timerStartGame.CoroutineStartTimer());

        yield return new WaitForSeconds(1);

        spawnerHamsters.StartGame();
    }

    public void GameOver(int score)
    {
        gameOverScreen.SetActive(true);
        txtScore.text = score.ToString();
        
        spawnerHamsters.StopGame();
        Time.timeScale = 0;
        //DestroyAllHamsters();
    }

    public void RestartGame()
    {
        StartCoroutine(StartGame());

        levelInfo.SetStartInfo();
        gameOverScreen.SetActive(false);
        Time.timeScale = 2f;
    }

    //private void DestroyAllHamsters()
    //{
    //    for (int i = 0; i < spawnerHamsters.listHamsters.Count; i++)
    //    {
    //        poolHamsters.DropUnit(spawnerHamsters.listHamsters[i]);
    //        poolPositions.DropUnit(spawnerHamsters.listHamsters[i].transform.position);
    //    }

    //    spawnerHamsters.listHamsters.Clear();

    //}
}
