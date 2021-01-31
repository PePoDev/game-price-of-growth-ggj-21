using System.Collections;
using System.Collections.Generic;
using Dialog;
using Player;
using TMPro;
using UnityEngine;

namespace Objective
{
	public class O_1_1 : MonoBehaviour, IObjective
	{
		public GameObject goHomeMessage;
		public TextMeshProUGUI textObjective;
		
		public int count = 0;
		public int goal = 3;

		private bool isGoHome = false;
		private CameraFollow _camera;
		
		private void Start()
		{
			_camera = Camera.main.GetComponent<CameraFollow>();
		}

		private void Update()
		{
			textObjective.text = $"- Make Fun";
			
			if (!IsSolved() && isGoHome == false) return;
			isGoHome = true;
			StartCoroutine(goHome());
		}

		private IEnumerator goHome()
		{
			yield return new WaitForSeconds(6f);
			GameObject.FindGameObjectWithTag(Statics.TAG_PLAYER).GetComponent<PlayerMovementController>().enabled = false;
			goHomeMessage.SetActive(true);
			yield return new WaitForSeconds(5f);
			Initiate.Fade("Chapter 1-2", Color.black, 1f);
		}

		public void IncrementTask()
		{
			count++;
		}

		public bool IsSolved() => count >= goal;
	}
}
