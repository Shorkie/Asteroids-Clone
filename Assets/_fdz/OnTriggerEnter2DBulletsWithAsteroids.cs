using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class OnTriggerEnter2DBulletsWithAsteroids : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D other)
		{
			var asteroid = other.GetComponent<AsteroidMovement>();
			if ( asteroid != null )
			{
				PlayerData.ModifyScore(asteroid.ScorePoints);
				Destroy(asteroid.gameObject);
			}
		}
	}
}