using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Name
{
	public class PlayerMovement : MonoBehaviour
	{
		//Boost
		public GameObject boostGO;
		public bool boost = false;
		//Movement
		public int rotationSpeed = 500;
		public float playerSpeed = 0.5f;
		//Portalization
		Vector2 pPos;
		public float maxXPos = 3;
		public float maxYPos = 3;
		//Cooldown
		public float shootingCooldown = 1f;
		public float starCooldown = 2f;
		float cooldownTimer = 0f;
		float starTimer = 0f;
		bool canShoot = false;
		bool canStar = false;
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
			Boost ();
		}

		void inputManager ()
		{
			//Exit application
			if (Input.GetKeyDown (KeyCode.Escape))
			{
				Application.Quit ();
			}
			if (Input.GetKey (KeyCode.UpArrow))
			{
				//Go forward
				transform.position += transform.up * Time.deltaTime * playerSpeed;
				boost = true;
			}
			else
			{
				boost = false;
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
			//Shooting stuff
			//Single Bullet
			if (Input.GetKey (KeyCode.Space))
			{
				if (canShoot == true)
				{
					var bs = GameObject.Find ("bulletSpawner").GetComponent<BulletSpawner> ();
					canShoot = false;
					bs.spawnBullet ();
				}

			}
			//Star Attack
			if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))
			{
				if (canStar == true)
				{
					var bs = GameObject.Find ("bulletSpawner").GetComponent<BulletSpawner> ();
					canStar = false;
					bs.starAttack ();
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
			//Normal Attack CD
			cooldownTimer -= Time.deltaTime;
			if (cooldownTimer <= 0f && canShoot == false)
			{
				cooldownTimer = shootingCooldown;
				canShoot = true;
			}
			//Star Attack CD
			starTimer -= Time.deltaTime;
			if (starTimer <= 0f && canStar == false)
			{
				starTimer = starCooldown;
				canStar = true;
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

		void Boost ()
		{
			if (boost == true)
			{
				boostGO.SetActive (true);
			}
			else
			{
				boostGO.SetActive (false);
			}
		}
	}
}