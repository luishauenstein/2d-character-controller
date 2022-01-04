using UnityEngine;

public class PlayerJump : MonoBehaviour {

  [SerializeField] float jumpVelocity;
  [SerializeField] float fallGravityScale;

  public float initialGravityScale;
  public bool canJump;
  Rigidbody2D _rigidbody;
  void Awake() {
    _rigidbody = GetComponent<Rigidbody2D>();
    canJump = true;
    initialGravityScale = _rigidbody.gravityScale;
  }

  void FixedUpdate() {
    //handle jump
    float movementY = Input.GetAxisRaw("Vertical");
    if (canJump && movementY > 0) {
      _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpVelocity);
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
