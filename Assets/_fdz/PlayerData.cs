using System.Collections;
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
		static int startingLives = 3;

		public static void ModifyScore(int value)
		{
			score += value;
			ins.UIScore.text = score.ToString();
		}

		public static void ModifyLives(int value, bool reloadScene = true )
		{
			lives += value;
			ins.UILives.text = lives.ToString();
			
			if ( lives <= 0 )
			{
				lives = startingLives;
			}

			if (reloadScene)
			{
				SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
			}
		}

		[SerializeField] UnityEngine.UI.Text UIScore;
		[SerializeField] UnityEngine.UI.Text UILives;

		void Start()
		{
			ins = this;
			ModifyScore(0);
			ModifyLives(0, false);
		}
	}
}