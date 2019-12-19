using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterHealBig : Hamster
{
    public override void SetType()
    {
        typeHamster = TypeHamster.HealBig;
    }

    public override void DestroyOnTap()
    {
        if (isTap)
        {
            Broadcast.ChangeHealthPoints(10);
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
