using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterStandBig : Hamster
{
    public override void SetType()
    {
        typeHamster = TypeHamster.StandBig;
    }

    public override void DestroyOnTap()
    {
        if (isTap)
        {
            Broadcast.ChangeScore(10);
            base.DestroyOnTap();
            isTap = false;
        }
    }

    public override void DestroyWithoutTap()
    {
        if (isTap)
            Broadcast.ChangeHealthPoints(-10);
        base.DestroyWithoutTap();
    }
}
