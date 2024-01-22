﻿using UnityEngine;


namespace MiniJam150
{
	public enum PLAYER_STATUS
	{
		IDLE, MOVING, SINGING
	}
	
	public class PlayerAnimatorController : MonoBehaviour
	{
		[SerializeField] private Animator animator;
		[SerializeField] private PlayerGlobals playerGlobals;

		private PLAYER_STATUS playerStatus = PLAYER_STATUS.IDLE;


		private void Update()
		{
			if (playerGlobals.isMoving)
			{
				trySetStatus(PLAYER_STATUS.MOVING, "MOVING");
				return;
			}
			if (playerGlobals.isUnderSpotlight)
			{
				trySetStatus(PLAYER_STATUS.SINGING, "SING");
				return;
			}
			trySetStatus(PLAYER_STATUS.IDLE, "IDLE");
		}

		private void trySetStatus(PLAYER_STATUS status, string animatorVarName)
		{
			if (playerStatus != status)
			{
				playerStatus = status;
				animator.SetTrigger(animatorVarName);
			}
		}
	}
}