using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class AsteroidSpawner : MonoBehaviour
	{
		public Transform player;
		public Camera cam;
		public Transform newParent;
		public LayerMask layers;
		public GameObject[] prefabs;

		float camHeight;
		float camWidth;
		Vector2 margin;

		float spawnRate = 3f;
		float timer;

		void Start()
		{
			timer = spawnRate * .5f;
		}

		void Update()
		{
			timer += Time.deltaTime;
			if ( timer >= spawnRate )
			{
				timer = 0;
				spawnRate -= .05f;
				Spawn();
			}
			if ( spawnRate < .1f )
			{
				spawnRate = .1f;
			}
		}

		GameObject GetPrefab()
		{
			return prefabs[Random.Range(0, prefabs.Length-1)];
		}

		void Spawn()
		{
			if ( prefabs == null || prefabs.Length == 0  )
			{
				return;
			}

			var prefabIns = Instantiate(GetPrefab());
			prefabIns.transform.parent = newParent;

			camHeight = cam.orthographicSize;
 			camWidth = camHeight * cam.aspect;

			margin = prefabIns.GetComponent<SpriteRenderer>().size * prefabIns.transform.localScale;
			//Debug.Log("margin: " + margin.ToString());

			SetPosition(prefabIns);
			
			prefabIns.transform.position = new Vector3(prefabIns.transform.position.x, prefabIns.transform.position.y, 0);

			var asteroid = prefabIns.GetComponent<AsteroidMovement>();
			asteroid.dir = GetRandomDir(prefabIns.transform.position);
		}

		Vector2 GetRandomDir(Vector3 from)
		{
			return player.position - from;
		}

		void SetPosition(GameObject prefabIns)
		{
			int iterationsCounter = 0;
			bool isPositionFree = false;
			while ( isPositionFree == false )
			{
				isPositionFree = true;

				prefabIns.transform.localPosition = GetRandomPosition();
				var overlapedColliders = Physics2D.OverlapCircleAll(prefabIns.transform.localPosition, margin.x, layers);
				
				Debug.DrawLine(prefabIns.transform.position - Vector3.up * margin.x, prefabIns.transform.position + Vector3.up * margin.x, Color.red, 1);
				Debug.DrawLine(prefabIns.transform.position - Vector3.right * margin.x, prefabIns.transform.position + Vector3.right * margin.x, Color.red, 1);

				foreach (var coll in overlapedColliders)
				{
					if ( coll.gameObject == prefabIns )
					{
						continue;
					}
					isPositionFree = false;
					break;
				}

				iterationsCounter++;
				if ( iterationsCounter > 10 )
				{
					Debug.LogError("force break");
					break;
				}
			}
		}

		Vector3 GetRandomPosition()
		{
			Vector3 center = cam.transform.position;

			float xMax = camWidth + margin.x;
			float x = Random.Range( -xMax, xMax ) * 1.5f;
			x = Mathf.Clamp(x, -xMax, xMax);
			
			Debug.DrawLine( new Vector3(-xMax, -100000, 0), new Vector3(-xMax, 100000, 0), Color.magenta, 10 );
			Debug.DrawLine( new Vector3(xMax, -100000, 0), new Vector3(xMax, 100000, 0), Color.magenta, 10 );

			float yMax = camHeight + margin.y;
			float y = yMax;

			Debug.DrawLine( new Vector3(-100000, -yMax, 0), new Vector3(100000, -yMax, 0), Color.magenta, 10 );
			Debug.DrawLine( new Vector3(-100000, yMax, 0), new Vector3(100000, yMax, 0), Color.magenta, 10 );

			if ( x <= -xMax + margin.x || x >= xMax - margin.x )
			{
				y = Random.Range( -yMax, yMax );
			}
			else
			{
				y = GetRandomSign() * ( yMax );
			}

			return new Vector3(x, y);
		}

		int GetRandomSign()
		{
			int sign = Random.Range(0, 2);
			if (sign == 0)
			{
				sign = -1;
			}
			else
			{
				sign = 1;
			}
			//Debug.Log("sign: " + sign);
			return sign;
		}
	}
}