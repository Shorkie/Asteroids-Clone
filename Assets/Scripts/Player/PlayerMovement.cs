using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Name
{
	public class PlayerMovement : MonoBehaviour
	{
		//Turbo
		public int turboRot = 600;
		public float turboSpeed = 3f;
		bool turbo = false;
		//Boost
		public GameObject boostGO;
		bool boost = false;
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
			//Turbo related
			inputManager ();
			Portal ();
			Cooldown ();
			Boost ();
			Turbo();
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
				//Turbo mode
				if(Input.GetKey(KeyCode.LeftShift))
				{
					turbo = true;
				}
				else
				{
					turbo = false;
				}
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
			if (Input.GetKeyDown (KeyCode.Space))
			{
				if (canShoot == true)
				{
					var bs = GameObject.Find ("bulletSpawner").GetComponent<BulletSpawner> ();
					canShoot = false;
					var b = GameObject.Find("shootSound").GetComponent<AudioSource>();
					b.Play();
					bs.spawnBullet ();
				}

			}
			//Star Attack
			if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl) || Input.GetKey(KeyCode.Z))
			{
				if (canStar == true)
				{
					var bs = GameObject.Find ("bulletSpawner").GetComponent<BulletSpawner> ();
					var b = GameObject.Find("starSound").GetComponent<AudioSource>();
					b.Play();
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

		void Turbo ()
		{
			// var t = boostGO.GetComponentInChildren<SpriteRenderer>();
			// if (turbo == true)
			// {
			// 	//Change color to C64 'Red'
			// 	t.color = new Color32(136,57,50,255);
			// 	rotationSpeed = turboRot;
			// 	playerSpeed = turboSpeed;
			// }
			// else
			// {
			// 	//CHANGE IT
			// 	rotationSpeed = 500;
			// 	playerSpeed = 1.5f;
			// 	//Whiteboi
			// 	t.color = Color.white;
			// }
		}
	}
}