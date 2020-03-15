using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSwitchLanes : MonoBehaviour
{
	[SerializeField] private float laneWidth = 1.5f;
	[SerializeField] private int laneNumber = 1;
	[SerializeField] private int lanesCount = 3;
	private bool wasMovedLastFrame = false;
	private float initialPosY;

	void Start()
	{
		initialPosY = transform.position.y;
	}

    void Update()
    {
    	if(!wasMovedLastFrame)
    	{
	        if(Input.GetButton("LaneUp"))
	        {
    			if(laneNumber < lanesCount-1)
        		{	
        			wasMovedLastFrame = true;
	        		transform.DOMoveY(transform.position.y + laneWidth, 0.3f);
	        		laneNumber++;
        		}
	        }
	        
	        if(Input.GetButton("LaneDown"))
	        {
    			if(laneNumber > 0)
        		{
        			wasMovedLastFrame = true;
	        		transform.DOMoveY(transform.position.y - laneWidth, 0.3f);
	        		laneNumber--;
        		}
	        }
		}
		else if(Mathf.Approximately(Mathf.Abs(transform.position.y - initialPosY), laneWidth) || Mathf.Approximately(transform.position.y, initialPosY))
	    {
	       	wasMovedLastFrame = false;
	    }
    }
}
