using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class MovingBackground : MonoBehaviour {	
		Vector2 initialPos;
		//Keeping this as an INT for now
		public int backgroundSpeed = 1;
		public GameObject player;
		// Use this for initialization
		void Start () {
			initialPos = new Vector2(this.transform.position.x, this.transform.position.y);
		}
		
		// Update is called once per frame
		void Update (){
		var p = player.GetComponent<PlayerMovement>();
			this.transform.position = -p.transform.position * backgroundSpeed;
		}
	}
}
