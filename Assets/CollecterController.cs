using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecterController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private void Start()
    {

    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(Mathf.Clamp(curPosition.x, -5, 5), transform.position.y, transform.position.z);
        }
    }


    private void FixedUpdate()
    {
        if (GameController.GameStatusEnum == GameStatus.STAY)
        {
            Movement();
        }


    }

    private void Movement()
    {
        transform.Translate(0, 0, 0.5f);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z - 15);
    }
    
}
