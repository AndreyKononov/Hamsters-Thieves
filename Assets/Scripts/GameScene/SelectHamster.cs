using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHamster : MonoBehaviour
{
    public void RandHamster(GameObject goHamster)
    {
        int randHamster = Random.Range(0, 6);

        switch (randHamster)
        {
            case 0:
                SetType(TypeHamster.StandSmall, goHamster);
                break;
            case 1:
                SetType(TypeHamster.StandBig, goHamster);
                break;
            case 2:
                SetType(TypeHamster.BombSmall, goHamster);
                break;
            case 3:
                SetType(TypeHamster.BombBig, goHamster);
                break;
            case 4:
                SetType(TypeHamster.HealSmall, goHamster);
                break;
            case 5:
                SetType(TypeHamster.HealBig, goHamster);
                break;
        }
    }

    private void SetType(TypeHamster typeHamster, GameObject goHamster)
    {
        switch (typeHamster)
        {
            case TypeHamster.StandSmall:
                goHamster.AddComponent<HamsterStandSmall>();
                break;
            case TypeHamster.StandBig:
                goHamster.AddComponent<HamsterStandBig>();
                break;
            case TypeHamster.BombSmall:
                goHamster.AddComponent<HamsterBombSmall>();
                break;
            case TypeHamster.BombBig:
                goHamster.AddComponent<HamsterBombBig>();
                break;
            case TypeHamster.HealSmall:
                goHamster.AddComponent<HamsterHealSmall>();
                break;
            case TypeHamster.HealBig:
                goHamster.AddComponent<HamsterHealBig>();
                break;
        }
    }
}
