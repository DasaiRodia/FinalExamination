using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private float maxPlayerOffset = 5f, cameraSafeDistance = 0.1f;
	private float playerOffset;
	private float playerLastPosX, playerCurrentPosX, playerMovementSign;
	private float cameraYPos, cameraZPos;

	void Start()
	{
		cameraYPos = transform.position.y;
		cameraZPos = transform.position.z;
	}

    void Update()
    {
    	playerMovementSign = Mathf.Sign(playerCurrentPosX - playerLastPosX);

		playerLastPosX = playerCurrentPosX;
		playerCurrentPosX = player.transform.position.x;

		if (playerLastPosX != playerCurrentPosX)
		{
			if (Mathf.Abs(playerOffset) > maxPlayerOffset)
			{
				transform.position = new Vector3(player.transform.position.x + playerOffset, cameraYPos, cameraZPos);
			}

			playerOffset = transform.position.x - player.transform.position.x;
		}
		else
		{
			if (Mathf.Abs(playerOffset) > maxPlayerOffset)
			{
				transform.position += new Vector3(playerMovementSign * cameraSafeDistance, 0f, 0f);
			}

			playerOffset = 0f;
		}
    }
}
