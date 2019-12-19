using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    public bool IsPaused { get; set; }

    private void Update()
    {
        if (IsPaused)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);

            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Hamster>()?.DestroyOnTap();
            }
        }
    }
}
