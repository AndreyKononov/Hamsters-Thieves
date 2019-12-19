using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllersPreLoad : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController animationControllBombBig;
    [SerializeField] private RuntimeAnimatorController animationControllBombSmall;
    [SerializeField] private RuntimeAnimatorController animationControllHealBig;
    [SerializeField] private RuntimeAnimatorController animationControllHealSmall;
    [SerializeField] private RuntimeAnimatorController animationControllStandBig;
    [SerializeField] private RuntimeAnimatorController animationControllStandSmall;

    public RuntimeAnimatorController SetRuntimeAnimator(TypeHamster typeHamster)
    {
        switch (typeHamster)
        {
            case TypeHamster.StandSmall:
                return animationControllStandSmall;
            case TypeHamster.StandBig:
                return animationControllStandBig;
            case TypeHamster.BombSmall:
                return animationControllBombSmall;
            case TypeHamster.BombBig:
                return animationControllBombBig;
            case TypeHamster.HealSmall:
                return animationControllHealSmall;
            case TypeHamster.HealBig:
                return animationControllHealBig;
        }

        return null;
    }

    private void OnEnable()
    {
        Broadcast.SetRuntimeAnimator += SetRuntimeAnimator;
    }

    private void OnDisable()
    {
        Broadcast.SetRuntimeAnimator -= SetRuntimeAnimator;
    }
}
