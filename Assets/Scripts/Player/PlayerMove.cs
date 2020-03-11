using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 1f;
    private bool isMovingRight = false;
    private bool isMovingLeft = false;

    void Update()
    {
        if(Input.GetButton("GoRight"))
        {
            if(!isMovingLeft)
            {
                isMovingRight = true;
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

        if(Input.GetButton("GoLeft"))
        {
            if(!isMovingRight)
            {
                isMovingLeft = true;
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
        }

        if(!Input.GetButton("GoRight"))
        {
            isMovingRight = false;
        }

        if(!Input.GetButton("GoLeft"))
        {
            isMovingLeft = false;
        }
    }
}
