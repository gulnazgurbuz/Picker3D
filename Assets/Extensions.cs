﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Extensions
{
    //public delegate void TransControl();
    //public static event TransControl TransControlEvent;
    public static Vector3 MoveTovardsWithCheck(this Transform MoveTovardsWEvent, Vector3 currentPos, Vector3 targetPos, float movingVelocity)
    {
        if (currentPos.y==targetPos.y)
        {
            GameController.GameStatusEnum = GameStatus.END;
        }
       return Vector3.MoveTowards(currentPos, targetPos, movingVelocity);
    }
}
