using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLineController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collecter")
        {
            Debug.Log("DURR");
            GameController.GameStatusEnum = GameStatus.COUNT;
        }
        if (other.tag == "ToBeCollected")
        {
            Debug.Log("FORCEEE");
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 10f);
        }
    }
}
