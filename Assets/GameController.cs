using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameStatus GameStatusEnum;

    private PocketCounterController pckCounter;
    private CollecterController clctCounter;
    private int _pocketindex = 1;

    private bool _pocketIndexIncreaseControl=false;

    private void Start()
    {
        pckCounter = GameObject.Find("Pocket" + _pocketindex).transform.Find("PocketCounter").GetComponent<PocketCounterController>();
        clctCounter = GameObject.Find("Collecter").GetComponent<CollecterController>();
        GameStatusEnum=GameStatus.START;
}

    private void Update()
    {
        Debug.Log("pocket index"+_pocketindex);

        switch (GameStatusEnum)
        {
            case GameStatus.START:             
                GameStatusEnum = GameStatus.STAY;
                break;
            case GameStatus.STAY:
                if (_pocketIndexIncreaseControl)
                {
                    _pocketIndexIncreaseControl = false;
                    _pocketindex++;
                    pckCounter = GameObject.Find("Pocket" + _pocketindex).transform.Find("PocketCounter").GetComponent<PocketCounterController>();
                }

                break;
            case GameStatus.COUNT:
                DisplayCollectedObject();
                CheckCount();
                break;
            case GameStatus.RISING:
                RisePlatform();
             
                break;
            case GameStatus.END:
                _pocketIndexIncreaseControl = true;
                GameStatusEnum = GameStatus.START;
                break;
            default:
                break;
        }
    }


    private void DisplayCollectedObject()
    {
        int targetCount = pckCounter.TargetCount;
        clctCounter.WhichPocket.transform.Find("Canvas").GetChild(0).GetComponent<Text>().text = pckCounter.ObjectCount + "/" + targetCount;
    }
    private void CheckCount()
    {
        if ((float)pckCounter.ObjectCount / pckCounter.TargetCount > 1)
        {
            StartCoroutine(ChangeEnumAfterASecond());
        }
    }

    private void RisePlatform()
    {
        Vector3 currPos = pckCounter.transform.parent.Find("Plane").transform.position;
        pckCounter.transform.parent.Find("Plane").transform.position
             = transform.MoveTovardsWithCheck(currPos, new Vector3(currPos.x, 0, currPos.z), 0.1f);

    }

    private IEnumerator ChangeEnumAfterASecond()
    {
        yield return new WaitForSeconds(1);
        GameStatusEnum = GameStatus.RISING;
    }
}

public enum GameStatus
{
    START, STAY, COUNT, RISING, END
}

