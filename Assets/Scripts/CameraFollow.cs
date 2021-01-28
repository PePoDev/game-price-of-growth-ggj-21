using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	public float moveSpeed;

	private Transform _followTarget;
	private Vector3 _targetPos;
	private bool _isFollowTargetNull;

	public CameraFollow(Transform target)
	{
		_followTarget = target;
	}

	private void Start()
	{
		_followTarget = GameObject.FindGameObjectWithTag(Statics.TAG_PLAYER).GetComponent<Transform>();
		_isFollowTargetNull = _followTarget == null;
	}

	private void Update ()
	{
		if (_isFollowTargetNull) return;
		_targetPos = new Vector3(_followTarget.position.x, _followTarget.position.y, transform.position.z);
		var velocity = (_targetPos - transform.position) * moveSpeed;
		transform.position = Vector3.SmoothDamp (transform.position, _targetPos, ref velocity, 1.0f, Time.deltaTime);
	}
}
