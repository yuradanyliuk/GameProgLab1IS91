using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    #region Fields
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    
    private Rigidbody2D _rigidbody;
    private Vector2 _movingForce;
    private Vector2 _jumpForce = Vector2.zero;
    private bool _needToJump;
    #endregion
    
    #region Methods
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _jumpForce.y = jumpPower;
    }
    private void Update()
    {
        UpdateInputParameters();

        if (_needToJump)
            Jump();
    }
    private void FixedUpdate()
    {
        if(_movingForce != Vector2.zero)
            Move(_movingForce);
    }

    private void UpdateInputParameters()
    {
        const string horizontalAxisName = "Horizontal";
        _movingForce.x = Input.GetAxis(horizontalAxisName);
        _needToJump = Input.GetKeyDown(KeyCode.Space);
    }
    private void Move(Vector2 movingForce) => transform.Translate(moveSpeed * Time.fixedDeltaTime * movingForce);
    private void Jump() => _rigidbody.AddForce(_jumpForce, ForceMode2D.Impulse);
    #endregion
}
