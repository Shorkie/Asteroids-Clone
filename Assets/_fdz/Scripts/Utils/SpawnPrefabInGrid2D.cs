using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class SpawnPrefabInGrid2D : MonoBehaviour
	{
		public GameObject prefab;
		public Vector2 gridSize;
		public Vector2 tileSize;
		public Transform prefabInsParent;
		public UnityEngine.Events.UnityEvent onFinishedSpawning;

		void Start()
		{
			for (int x = 0; x < gridSize.x; x++)
			{
				for (int y = 0; y < gridSize.y; y++)
				{
					var go = Instantiate(prefab);
					go.transform.parent = prefabInsParent;
					go.transform.localPosition = (tileSize * new Vector2(x, y));
				}
			}

			if (onFinishedSpawning != null)
			{
				onFinishedSpawning.Invoke();
			}

			Destroy(this);
		}

		//void OnDrawGizmosSelected()
		void OnDrawGizmos()
		{
			Gizmos.color = Color.magenta;

			for (int x = 0; x < gridSize.x; x++)
			{
				for (int y = 0; y < gridSize.y; y++)
				{
					var pos = prefabInsParent.position;
					pos += (Vector3)(tileSize * new Vector2(x, y));
					Gizmos.DrawWireCube(pos, tileSize);
				}
			}
		}
	}
}