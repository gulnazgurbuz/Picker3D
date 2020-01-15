using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecterController : MonoBehaviour
{
    private Vector3 _screenPoint;
    private Vector3 _offset;

    [HideInInspector] public Transform WhichPocket;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
            transform.position = new Vector3(Mathf.Clamp(curPosition.x, -5, 5), transform.position.y, transform.position.z);
        }
    }
    
    private void FixedUpdate()
    {
        if (GameController.GameStatusEnum == GameStatus.STAY)
            Movement();
    }

    private void Movement()
    {
        transform.Translate(0, 0, 0.1f);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z - 15);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="StopLine")
            WhichPocket = other.transform.parent;
        
        if (other.tag == "FinishFlag")
            GameController.GameStatusEnum = GameStatus.SUCCESS;
     
    }
}
