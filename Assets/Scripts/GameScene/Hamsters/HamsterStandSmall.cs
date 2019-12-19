using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterStandSmall : Hamster
{
    public override void SetType()
    {
        typeHamster = TypeHamster.StandSmall;
    }

    public override void DestroyOnTap()
    {
        if (isTap)
        {
            Broadcast.ChangeScore(5);
            base.DestroyOnTap();
            isTap = false;
        }
    }

    public override void DestroyWithoutTap()
    {
        if (isTap)
            Broadcast.ChangeHealthPoints(-5);
        base.DestroyWithoutTap();
    }
}
