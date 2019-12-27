using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapHamsterController : MonoBehaviour
{
    public bool IsPaused { get; set; }

    private void Update()
    {
        if (IsPaused)
            return;

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);

            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Hamster>()?.DestroyOnTap();
            }
        }
#endif

#if UNITY_ANDROID
        Touch[] myTouches = Input.touches;

        foreach(var touch in myTouches)
        {
            if (touch.phase != TouchPhase.Began) continue;

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.up);

            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Hamster>()?.DestroyOnTap();
            }
        }
#endif
    }
}
