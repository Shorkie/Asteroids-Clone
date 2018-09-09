using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class BulletBehaviour : MonoBehaviour {
		public float bulletSpeed = 1;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
		//Move
		transform.position += transform.up * Time.deltaTime * bulletSpeed;
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			
		}

		//Destroying it when not being rendered
		void OnBecameInvisible()
		{
			Destroy(gameObject);
		}
	}
}
