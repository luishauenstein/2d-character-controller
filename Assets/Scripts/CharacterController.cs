using UnityEngine;

public class CharacterController : MonoBehaviour {

  [SerializeField] float movementSpeed;
  [SerializeField] float jumpVelocity;
  float initialGravityScale;
  Rigidbody2D _rigidbody;
  BoxCollider2D _boxCollider;
  bool grounded;
  void Awake() {
    _rigidbody = GetComponent<Rigidbody2D>();
    _boxCollider = GetComponent<BoxCollider2D>();
    initialGravityScale = _rigidbody.gravityScale;
  }

  void FixedUpdate() {
    //walk left right
    float movementX = Input.GetAxis("Horizontal");
    _rigidbody.velocity = new Vector2(movementX * movementSpeed, _rigidbody.velocity.y);

    //handle jump
    float movementY = Input.GetAxisRaw("Vertical");
    if (movementY > 0 && grounded) {
      _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpVelocity);
      grounded = false;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    checkGrounded();
  }

  void checkGrounded() {
    //check if player is grounded
    float boxHeight = 0.05f;
    LayerMask groundLayerMask = 1 << LayerMask.NameToLayer("Ground");
    RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, boxHeight, groundLayerMask);
    grounded = raycastHit.collider != null;
  }
}
