using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerStartGame : MonoBehaviour
{
    private Coroutine coroutineTimer;
    [SerializeField] private Text txtTimer;
    [SerializeField] private SpawnerHamsters spawnerHamsters;

    private void Start()
    {
        //StartTimer();
    }

    public void StartTimer()
    {
        if (coroutineTimer != null)
        {
            StopCoroutine(coroutineTimer);
            ResetTimer();
        }

        coroutineTimer = StartCoroutine(CoroutineStartTimer());

    }

    public IEnumerator CoroutineStartTimer()
    {
        txtTimer.text = "";

        int countSecond = 3;

        while(countSecond != 0)
        {
            yield return new WaitForSeconds(1);
            txtTimer.text = countSecond.ToString();

            countSecond--;
        }

        yield return new WaitForSeconds(1);

        txtTimer.text = "Start!";

        yield return new WaitForSeconds(1f);

        txtTimer.text = "";
    }

    private void ResetTimer()
    {
        //Сброс таймера.
    }
}
