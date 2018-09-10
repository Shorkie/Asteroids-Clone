using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Name
{
	public class PlayerMovement : MonoBehaviour
	{
		//Movement
		public int rotationSpeed = 500;
		public float playerSpeed = 0.5f;
		//Portalization
		Vector2 pPos;
		public float maxXPos = 3;
		public float maxYPos = 3;
		//Cooldown
		public float shootingCooldown = 1f;
		float cooldownTimer = 0f;
		bool canShoot = true;
		// Use this for initialization
		void Start ()
		{
			cooldownTimer = shootingCooldown;
		}

		// Update is called once per frame
		void Update ()
		{
			//Portal related
			pPos = transform.position;
			inputManager ();
			Portal ();
			Cooldown ();
		}

		void inputManager ()
		{
			if (Input.GetKey (KeyCode.UpArrow))
			{
				//Go forward
				transform.position += transform.up * Time.deltaTime * playerSpeed;
			}
			if (Input.GetKey (KeyCode.DownArrow))
			{
				//Go backwards
				transform.position -= transform.up * Time.deltaTime * playerSpeed;
			}
			if (Input.GetKey (KeyCode.LeftArrow))
			{
				//Rotate counter-clockwise
				this.transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.RightArrow))
			{
				//Rotate clockwise
				this.transform.Rotate (0, 0, -rotationSpeed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.Space))
			{
				if (canShoot == true)
				{
					var bs = GameObject.Find ("bulletSpawner").GetComponent<BulletSpawner> ();
					canShoot = false;
					bs.spawnBullet ();
				}

			}
			if (Input.GetKeyDown (KeyCode.R))
			{
				//Restart
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}

		void Cooldown ()
		{
			cooldownTimer -= Time.deltaTime;
			if (cooldownTimer <= 0f)
			{
				canShoot = true;
				cooldownTimer = shootingCooldown;
			}
		}

		void Portal ()
		{
			//Check for portalization
			if (pPos.x > maxXPos)
			{
				transform.position = new Vector2 (-maxXPos, this.transform.position.y);
			}
			if (pPos.x < -maxXPos)
			{
				transform.position = new Vector2 (maxXPos, this.transform.position.y);
			}
			if (pPos.y > maxYPos)
			{
				transform.position = new Vector2 (this.transform.position.x, -maxYPos);
			}
			if (pPos.y < -maxYPos)
			{
				transform.position = new Vector2 (this.transform.position.x, maxYPos);
			}

		}
	}
}