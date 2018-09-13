using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class OnTriggerEnter2DAsteroidWithPlayer : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D other)
		{
			var player = other.GetComponent<PlayerMovement>();
			if ( player != null )
			{
				PlayerData.ModifyLives(-1);
			}
		}
	}
}