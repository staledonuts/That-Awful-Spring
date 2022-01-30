using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField, Range(0, 1)] private float horizontalDamp, horizontalDampStop, horizontalDampTurn;
    private float _currentSpeed;
    private float _moveX;

    private Transform _playerTransform;
    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _playerTransform = this.transform;
        _playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _currentSpeed = moveSpeed;
    }

    private void FixedUpdate()
    {
        float horizontalVel = _playerRigidbody.velocity.x;
        horizontalVel += Input.GetAxisRaw("Horizontal") * _currentSpeed;

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01F)
            horizontalVel *= Mathf.Pow(1F - horizontalDampStop, Time.deltaTime * 10F);
        else if (Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(horizontalVel))
            horizontalVel *= Mathf.Pow(1F - horizontalDampTurn, Time.deltaTime * 10F);
        else
        horizontalVel *= Mathf.Pow(1F - horizontalDamp, Time.deltaTime * 10F);
        _playerRigidbody.velocity = new Vector2(horizontalVel, _playerRigidbody.velocity.y);
    }   
}