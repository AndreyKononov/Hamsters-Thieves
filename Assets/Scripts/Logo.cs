using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public Image logo;

    private float speed = 1f;

    private void Start()
    {
        StartCoroutine(ShowLogo());
    }

    public IEnumerator ShowLogo()
    {
        yield return new WaitForSeconds(1f);

        while (logo.color.a < 1)
        {
            Color color = logo.color;
            color.a += Time.deltaTime * speed;

            logo.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(HideLogo());
    }

    public IEnumerator HideLogo()
    {
        while (logo.color.a > 0)
        {
            Color color = logo.color;
            color.a -= Time.deltaTime * speed;

            logo.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(1);
    }
}
