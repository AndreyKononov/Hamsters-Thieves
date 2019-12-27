using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHamsters : MonoBehaviour
{
    private float lifeTime = 5f;

    private PoolHamsters poolHamsters;
    private PoolPositions poolPosition;
    private LevelInfo levelInfo;

    private SelectHamster selectHamster;

    public List<GameObject> listHamsters;

    private Coroutine coroutineSwapner;

    private ComplexityGame complexityGame;

    private void Awake()
    {
        complexityGame = new ComplexityGame();

        listHamsters = new List<GameObject>();

        poolHamsters = GetComponent<PoolHamsters>();
        poolPosition = GetComponent<PoolPositions>();
        selectHamster = GetComponent<SelectHamster>();     
        levelInfo = GetComponent<LevelInfo>();
        levelInfo.SetStartInfo();
    }

    public void StartGame()
    {
        if (coroutineSwapner != null)
            StopCoroutine(coroutineSwapner);

        coroutineSwapner = StartCoroutine(LifeHamsters());
    }

    public void StopGame()
    {
        if (coroutineSwapner != null)
            StopCoroutine(coroutineSwapner);

        DestroyHamsters();
    }

    private IEnumerator LifeHamsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            SpawnHamsters();         
            yield return new WaitForSeconds(lifeTime);
            DropInPool();
        }
    }

    private void SpawnHamsters()
    {
        complexityGame.ChangeComplexity(levelInfo.Score);

        for (int i = 0; i <= Random.Range (0,complexityGame.MaxCounHamster); i++)
        {
            GameObject goHamster = poolHamsters.GetHamster();
            goHamster.transform.position = poolPosition.GetUnit();
            selectHamster.RandHamster(goHamster);
            goHamster.SetActive(true);
            listHamsters.Add(goHamster);
        }
    }

    public void DropInPool()
    {
        for (int i = 0; i < listHamsters.Count; i++)
        {
            poolHamsters.DropUnit(listHamsters[i]);
            poolPosition.DropUnit(listHamsters[i].transform.position);
        }
        
        listHamsters.Clear();
    }

    private void DestroyHamsters()
    {
        foreach (var hamster in listHamsters)
        {
            hamster?.GetComponent<Hamster>()?.DestroyHamster();
        }

        DropInPool();
    }
}