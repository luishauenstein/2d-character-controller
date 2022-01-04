using UnityEngine;

public class PlayerJump : MonoBehaviour {

  [SerializeField] float jumpVelocity;
  [SerializeField] float fallGravityScale;
  [SerializeField] bool quickFall;
  float initialGravityScale;
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
    if (quickFall) {
      if (_rigidbody.velocity.y < 0) {
        //if player falls
        _rigidbody.gravityScale = fallGravityScale;
      } else {
        _rigidbody.gravityScale = initialGravityScale;
      }
    }
  }

  bool checkGrounded() {
    //check if player is grounded
    float boxHeight = 0.05f;
    LayerMask groundLayerMask = 1 << LayerMask.NameToLayer("Ground");
    RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, boxHeight, groundLayerMask);
    return raycastHit.collider != null;
  }
}
