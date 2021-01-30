using TMPro;
using UnityEngine;

namespace Objective
{
	public class O_1_1 : MonoBehaviour, IObjective
	{
		public TextMeshProUGUI textObjective;
		
		public int count = 0;
		public int goal = 3;

		private CameraFollow _camera;
		
		private void Start()
		{
			_camera = Camera.main.GetComponent<CameraFollow>();
		}

		private void Update()
		{
			textObjective.text = $"- Make Fun ({count}/{goal})";
			
			if (!IsSolved()) return;
		}

		public void IncrementTask()
		{
			count++;
		}

		public bool IsSolved() => count >= goal;
	}
}
