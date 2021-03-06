﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Name
{
	public class PlayerData : MonoBehaviour
	{
		static PlayerData ins;
		static int score = 0;
		static int lives = 3;

		public static bool isInvencible { get; protected set; }

		public static void ModifyScore(int value)
		{
			score += value;
			ins.UIScore.text = score.ToString();
		}

		public static void ModifyLives(int value, bool resetPlayerPos = true )
		{
			if ( isInvencible )
			{
				return;
			}

			if ( value < 0 )
			{
				isInvencible = true;
				ins.playerInvencibility.enabled = true;
				ins.audioSource.Play();
				ScreenShake.DoIt(.5f, .2f);
			}

			lives += value;
			ins.UILives.text = lives.ToString();

			if (resetPlayerPos)
			{
				ins.playerTrans.position = Vector3.zero;
			}
		}

		static void ResetScene()
		{
			score = 0;
			SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
		}

		[SerializeField] int startingLives = 3;
		[SerializeField] UnityEngine.UI.Text UIScore;
		[SerializeField] UnityEngine.UI.Text UILives;
		[SerializeField] UnityEngine.UI.Text UIGameOver;
		[SerializeField] Transform playerTrans;
		[SerializeField] PlayerInvencibility playerInvencibility;
		AudioSource audioSource;

		bool gameOver;

		void Start()
		{
			ins = this;

			lives = ins.startingLives;
			
			playerInvencibility = playerTrans.GetComponent<PlayerInvencibility>();
			audioSource = GetComponent<AudioSource>();

			UIGameOver.gameObject.SetActive(false);

			ModifyScore(0);
			ModifyLives(0, false);
		}

		void Update()
		{
			isInvencible = playerInvencibility.enabled;

			if ( lives <= 0 )
			{
				playerTrans.gameObject.SetActive(false);
				UIGameOver.gameObject.SetActive(true);
			}

			if ( Input.GetKeyDown(KeyCode.R) )
			{
				ResetScene();
			}
		}
	}
}