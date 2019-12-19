using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    protected Animator animHamster;

    private int repeatStand;
    private bool isDeath = true;
    protected bool isTap = true;

    protected TypeHamster typeHamster;

    private void Awake()
    {
        repeatStand = 3;
        animHamster = GetComponent<Animator>();

        SetType();

        animHamster.runtimeAnimatorController = Broadcast.SetRuntimeAnimator(typeHamster);
    }

    public virtual void DestroyWithoutTap()
    {
        DestroyHamster();
    }

    public void WaitStand()
    {
        if (repeatStand != 0)
        {
            animHamster.Play("Stand");
            repeatStand--;
        }
        else
        {
            isDeath = false;
            animHamster.Play("Diss");
        }
    }

    public virtual void DestroyOnTap()
    {
        SetSound();

        if (isDeath)
        {
            animHamster.Play("Death");
        }
    }

    public void DestroyHamster()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        animHamster.runtimeAnimatorController = null;
        Destroy(this);
    }

    public virtual void SetType()
    {
    }

    public void SetSound()
    {
        Broadcast.PlaySoundHamster(typeHamster);
    }
}
