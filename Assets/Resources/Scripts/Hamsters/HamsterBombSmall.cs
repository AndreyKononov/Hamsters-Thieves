using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterBombSmall : Hamster
{
    public override void SetType()
    {
        typeHamster = TypeHamster.BombSmall;
    }

    public override void DestroyOnTap()
    {
        if (isTap)
        {
            Broadcast.ChangeHealthPoints(-5);
            base.DestroyOnTap();
            isTap = false;
        }
    }
}
