using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class BulletSpawner : MonoBehaviour {
		public GameObject player;
		public GameObject bullet;
		Quaternion bulletRot;
		// Use this for initialization
		void Start () {
			player.GetComponent<Transform>();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void spawnBullet(){
			Instantiate(bullet, player.transform.position, player.transform.rotation);
		}
	}
}
