using UnityEngine;

public class PlayerJump : MonoBehaviour {

  [SerializeField] float jumpVelocity;
  [SerializeField] float fallGravityScale;

  public float initialGravityScale;
  [SerializeField] Transform groundCheck;
  Rigidbody2D _rigidbody;
  BoxCollider2D _boxCollider;
  void Awake() {
    _rigidbody = GetComponent<Rigidbody2D>();
    _boxCollider = GetComponent<BoxCollider2D>();
    initialGravityScale = _rigidbody.gravityScale;
  }

  void FixedUpdate() {

    //handle jump
    float movementY = Input.GetAxisRaw("Vertical");
    if (movementY > 0 && checkGrounded()) {
      _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpVelocity);
    }

    //better jump
    if (_rigidbody.velocity.y < 0) {
      //if player falls
      _rigidbody.gravityScale = fallGravityScale;
    } else {
      _rigidbody.gravityScale = initialGravityScale;
    }
  }

  [SerializeField] LayerMask groundLayerMask;
  bool checkGrounded() {
    //check if player is grounded
    float boxHeight = 0.05f;
    RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, boxHeight, groundLayerMask);
    return raycastHit.collider != null;
  }
}
