using UnityEngine;

namespace Objective
{
	public class O_1_1 : MonoBehaviour, IObjective
	{
		public int count = 0;
		public int goal = 3;

		public Transform mom;
		
		private CameraFollow _camera;
		
		private void Start()
		{
			_camera = Camera.main.GetComponent<CameraFollow>();
		}

		private void Update()
		{
			if (!IsSolved()) return;

			_camera.SetTarget(mom);
		}

		public void IncrementTask()
		{
			count++;
		}

		public bool IsSolved() => count >= goal;
	}
}
