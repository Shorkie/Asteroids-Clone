using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class OnDestroyInstantiatePrefab : MonoBehaviour
	{
		[SerializeField] GameObject prefab;

		void OnDestroy()
		{
			if (prefab != null)
			{
				Instantiate(prefab);
			}
		}
	}
}