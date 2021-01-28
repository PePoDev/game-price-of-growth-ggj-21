using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 1f;
    
    private PlayerRenderer _isoRenderer;
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _isoRenderer = GetComponentInChildren<PlayerRenderer>();
    }

    private void FixedUpdate()
    {
        var currentPos = _rigid.position;
        var horizontalInput = Input.GetAxis(Statics.INPUT_HORIZONTAL);
        var verticalInput = Input.GetAxis(Statics.INPUT_VERTICAL);
        
        var inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        var movement = inputVector * movementSpeed;
        var newPos = currentPos + movement * Time.fixedDeltaTime;
        
        _isoRenderer.SetDirection(movement);
        _rigid.MovePosition(newPos);
    }
}
