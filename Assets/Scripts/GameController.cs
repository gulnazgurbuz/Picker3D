using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameStatus GameStatusEnum;

    [SerializeField] private Text _buttonText;
    private Transform _pocketParent;

    private PocketCounterController _pckCounter;
    private CollecterController _clctControl;

    private int _pocketindex = 1;
    private bool _pocketIndexIncreaseControl = false;

    private void Start()
    {
        _pocketParent = GameObject.Find("Pockets").transform;
        _pckCounter = GameObject.Find("Pocket" + _pocketindex).transform.Find("PocketCounter").GetComponent<PocketCounterController>();
        _clctControl = GameObject.Find("Collecter").GetComponent<CollecterController>();
        GameStatusEnum = GameStatus.START;
    }

    private void Update()
    {
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
                    _pckCounter = GameObject.Find("Pocket" + _pocketindex).transform.Find("PocketCounter").GetComponent<PocketCounterController>();
                }
                break;

            case GameStatus.COUNT:
                DisplayCollectedObject();
                StartCoroutine(CheckCount());
                break;

            case GameStatus.RISING:
                RisePlatform();
                break;

            case GameStatus.ENDPOCKET:
                if (_pocketindex != _pocketParent.childCount)
                    _pocketIndexIncreaseControl = true;

                GameStatusEnum = GameStatus.START;
                break;

            case GameStatus.SUCCESS:
                _buttonText.text = "Next Level";
                _buttonText.transform.parent.gameObject.SetActive(true);
                Camera.main.transform.GetChild(0).gameObject.SetActive(true);
                break;

            case GameStatus.FAIL:
                _buttonText.text = "Try Again";
                _buttonText.transform.parent.gameObject.SetActive(true);
                break;
        }
    }

    private void DisplayCollectedObject()
    {
        int targetCount = _pckCounter.TargetCount;
        _clctControl.WhichPocket.transform.Find("Canvas").GetChild(0).GetComponent<Text>().text = _pckCounter.ObjectCount + "/" + targetCount;
    }

    public void ButtonClicked()
    {
        if (GameStatusEnum == GameStatus.SUCCESS)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RisePlatform()
    {
        Vector3 currPos = _pckCounter.transform.parent.Find("Plane").transform.position;
        _pckCounter.transform.parent.Find("Plane").transform.Move(new Vector3(currPos.x, 0, currPos.z),0.1f).OnComplete(()=> 
        {
            GameStatusEnum = GameStatus.ENDPOCKET;
        });
    }

    private IEnumerator CheckCount()
    {
        yield return new WaitForSeconds(1);
        if ((float)_pckCounter.ObjectCount / _pckCounter.TargetCount > 1)
           GameStatusEnum = GameStatus.RISING;
        else
            GameStatusEnum = GameStatus.FAIL;
    }
}

public enum GameStatus
{
    START, STAY, COUNT, RISING, ENDPOCKET, SUCCESS, FAIL
}

