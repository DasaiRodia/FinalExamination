using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Attack"))
        {
        	if(Physics.Raycast(transform.position, Vector3.right, 10f))
        	{
        		print("There is something in front of the object!");
        	}
        }
    }
}
