using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class DestroySelf : MonoBehaviour
	{
		[SerializeField] GameObject prefab;
		bool destroyed;

		public void SelfDestroy()
		{
			if ( destroyed )
			{
				return;
			}

			if (prefab != null)
			{
				var go = Instantiate(prefab);
				go.transform.position = this.transform.position;
			}

			Destroy(this.gameObject);
			destroyed = true;
		}
	}
}