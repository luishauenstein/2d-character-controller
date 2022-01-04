using UnityEngine;

public class PlayerJump : MonoBehaviour {

  [SerializeField] float jumpVelocity;
  [SerializeField] float fallGravityScale;

  public float initialGravityScale;
  public bool canJump;
  Rigidbody2D _rigidbody;
  float movementY;
  void Awake() {
    _rigidbody = GetComponent<Rigidbody2D>();
    canJump = true;
    initialGravityScale = _rigidbody.gravityScale;
  }

  void Update() {
    //handle jump input
    movementY = Input.GetAxisRaw("Vertical");
  }

  void FixedUpdate() {
    //handle jump
    if (canJump && movementY > 0) {
      _rigidbody.velocity = Vector2.up * jumpVelocity;
      canJump = false;
    }

    //better jump
    if (_rigidbody.velocity.y < 0) {
      //if player falls
      _rigidbody.gravityScale = fallGravityScale;
    } else {
      _rigidbody.gravityScale = initialGravityScale;
    }
  }
}
