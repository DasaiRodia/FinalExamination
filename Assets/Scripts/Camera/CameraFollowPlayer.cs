using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private float maxPlayerOffset = 5f;
	private float playerOffset;
	private Vector3 playerLastPos, playerCurrentPos;
	private float cameraYPos, cameraZPos;

	void Start()
	{
		cameraYPos = transform.position.y;
		cameraZPos = transform.position.z;
	}

    void Update()
    {
		playerLastPos = playerCurrentPos;
		playerCurrentPos = player.transform.position;

		if (playerLastPos != playerCurrentPos)
		{
			if (Mathf.Abs(playerOffset) > maxPlayerOffset)
			{
				transform.position = new Vector3(player.transform.position.x + playerOffset, cameraYPos, cameraZPos);
			}

			playerOffset = transform.position.x - player.transform.position.x;
		}
		else
		{
			playerOffset = 0f;
		}
		
		print(playerOffset);
    }
}
