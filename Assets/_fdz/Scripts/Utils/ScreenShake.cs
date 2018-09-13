using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class ScreenShake : MonoBehaviour
	{
		//https://forum.unity.com/threads/screen-shake-effect.22886/

		static ScreenShake ins;

		public static void DoIt(float shakeForSeconds, float shakeAmount )
		{
			if (ins == null)
			{
				return;
			}
			ins.shake = shakeForSeconds;
			ins.shakeAmount = shakeAmount;
		}

		Camera cam; // set this via inspector
		float shake = 0;
		float shakeAmount = 0.7f;
		float decreaseFactor = 1.0f;

		void Start()
		{
			cam = GetComponent<Camera>();
			ins = this;
		}

		void Update()
		{
			if (shake > 0)
			{
				var pos = Random.insideUnitSphere * shakeAmount;
				cam.transform.localPosition = new Vector3(pos.x, pos.y, cam.transform.localPosition.z);
				shake -= Time.deltaTime * decreaseFactor;

			}
			else
			{
				var to = new Vector3(0, 0, cam.transform.localPosition.z);;
				cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, to, Time.deltaTime);
				shake = 0f;
			}
		}
	}
}