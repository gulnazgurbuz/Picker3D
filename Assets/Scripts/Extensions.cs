using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Extensions
{
    //public delegate void TransControl();
    //public static event TransControl TransControlEvent;

    //public static Vector3 MoveTovardsWithCheck(this Transform MoveTovardsWEvent, Vector3 currentPos, Vector3 targetPos, float movingVelocity)
    //{
    //    if (currentPos.y==targetPos.y)
    //        GameController.GameStatusEnum = GameStatus.ENDPOCKET;
        
    //   return Vector3.MoveTowards(currentPos, targetPos, movingVelocity);
    //}
    public static Vector3 vec;
    public static Transform Move(this Transform main,Vector3 targetPos,float time)
    {
        vec = targetPos;
        main.position = Vector3.MoveTowards(main.position, targetPos, 0.1f);
        return main;
    }

    public static void OnComplete(this Transform main,Action t)
    {
        if (main.position== vec)
        {
            t.Invoke();
        }
    }



}
