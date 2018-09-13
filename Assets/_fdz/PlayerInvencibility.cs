using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class PlayerInvencibility : MonoBehaviour
	{
		SpriteRenderer sprRender;
		[SerializeField] float seconds = 4f;
		float timer;
		Color prevColor;

		void Awake()
		{
			sprRender = GetComponent<SpriteRenderer>();
		}

		void OnEnable()
		{
			Debug.Log("PlayerInvencibility::OnEnable()");
			prevColor = sprRender.color;
			sprRender.color = Color.gray;
			timer = 0;
		}

		void Update()
		{
			timer += Time.deltaTime;
			if ( timer >= seconds )
			{
				Debug.Log("PlayerInvencibility::SetEnabledFalse()");
				this.enabled = false;
				sprRender.color = prevColor;
			}
		}
	}
}