using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broadcast
{
    public delegate void CallBack<T>(T arg1);
    public delegate RuntimeAnimatorController SetCallBack<T>(T arg1);

    public static CallBack<int> ChangeHealthPoints = delegate { };
    public static CallBack<int> ChangeScore = delegate { };

    public static CallBack<TypeHamster> PlaySoundHamster = delegate { };

    public static SetCallBack<TypeHamster> SetRuntimeAnimator;
}
