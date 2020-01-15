using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLineController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collecter")
        {
            GameController.GameStatusEnum = GameStatus.COUNT;
        }
        if (other.tag == "ToBeCollected")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 10f);
        }
    }
}
