using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class BulletSpawner : MonoBehaviour {
		public GameObject player;
		public GameObject bullet;
		public int starAttackQuantity = 0;
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

		public void starAttack(){
			for(int i = 0; i < starAttackQuantity; i++)
			{
			//Bullet spawn rotation relative to player and quantity
			Instantiate(bullet, player.transform.position, transform.rotation *= Quaternion.Euler(0,0,360 / starAttackQuantity));
			}
		}
	}
}
