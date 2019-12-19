using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterBombBig : Hamster
{
    public override void SetType()
    {
        typeHamster = TypeHamster.BombBig;
    }

    public override void DestroyOnTap()
    {
        if (isTap)
        {
            Broadcast.ChangeHealthPoints(-10);
            base.DestroyOnTap();
            isTap = false;
        }
    }
}
