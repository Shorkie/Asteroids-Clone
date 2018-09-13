using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class AsteroidMiniSpawner : MonoBehaviour
	{
		[SerializeField] GameObject[] prefabs;

		void Start()
		{
			foreach (var p in prefabs)
			{
				var go = Instantiate(p);
				var asteroid = go.GetComponent<AsteroidMovement>();
				var randomAngleZ = Random.Range(0, 360);
				var angle = Quaternion.Euler(0, 0, randomAngleZ);
				asteroid.dir = angle * Vector3.right;
				go.transform.position = this.transform.position;
			}
			Destroy(this);
		}
	}
}