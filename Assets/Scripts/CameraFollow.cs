using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour 
{
	public Transform followTarget;
	public float moveSpeed;

	private Vector3 _targetPos;

	public void SetTarget(Transform target)
	{
		followTarget = target;
	}

	private void Update ()
	{
		_targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
		var velocity = (_targetPos - transform.position) * moveSpeed;
		transform.position = Vector3.SmoothDamp (transform.position, _targetPos, ref velocity, 1.0f, Time.deltaTime);
	}
}
