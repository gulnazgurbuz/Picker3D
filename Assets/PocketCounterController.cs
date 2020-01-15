using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketCounterController : MonoBehaviour
{
    public int TargetCount;
    public int ObjectCount { get { return _objectCount; } }
    private int _objectCount = 0;

 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ToBeCollected")
        {
            _objectCount++;
        }
    }
}
