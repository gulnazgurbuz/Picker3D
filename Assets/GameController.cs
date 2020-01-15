using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameStatus GameStatusEnum;

    private PocketCounterController pckCounter;

    private void Start()
    {
        pckCounter = GameObject.Find("PocketCounter").GetComponent<PocketCounterController>();
    }

    private void Update()
    {
     Debug.Log( pckCounter.ObjectCount);
        switch (GameStatusEnum)
        {
            case GameStatus.START:
                GameStatusEnum = GameStatus.STAY;
                break;
            case GameStatus.STAY:
                break;
            case GameStatus.COUNT:
                CountCollectedObject();
                break;
            case GameStatus.END:
                break;
            default:
                break;
        }
    }

    private void CountCollectedObject()
    {

    }
}

public enum GameStatus
{
    START,STAY,COUNT,END
}