using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameStatus GameStatusEnum;

    private PocketCounterController pckCounter;
    private CollecterController clctCounter;

    private void Start()
    {
        pckCounter = GameObject.Find("PocketCounter").GetComponent<PocketCounterController>();
        clctCounter = GameObject.Find("Collecter").GetComponent<CollecterController>();
    }

    private void Update()
    {
      
        switch (GameStatusEnum)
        {
            case GameStatus.START:
                GameStatusEnum = GameStatus.STAY;
                break;
            case GameStatus.STAY:
                break;
            case GameStatus.COUNT:
                DisplayCollectedObject();
                CheckCount();
                break;
            case GameStatus.RISING:
                break;
            case GameStatus.END:
                break;
            default:
                break;
        }
    }


    private void DisplayCollectedObject()
    {
        int targetCount = pckCounter.TargetCount;
        clctCounter.WhichPocket.transform.Find("Canvas").GetChild(0).GetComponent<Text>().text = pckCounter.ObjectCount+ "/" +targetCount;
    }
    private void CheckCount()
    {
        if ((float)pckCounter.ObjectCount / pckCounter.TargetCount > 1)
        {
           GameStatusEnum = GameStatus.RISING;
        }
    }
}

public enum GameStatus
{
    START, STAY, COUNT,RISING, END
}