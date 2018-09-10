using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class AsteroidMovement : MonoBehaviour
	{
		public Vector2 dir;
		public float speed;

		Rigidbody2D rb;

		void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		void FixedUpdate()
		{
			rb.MovePosition(rb.position + (dir.normalized * (speed * Time.deltaTime)));
		}
	}
}