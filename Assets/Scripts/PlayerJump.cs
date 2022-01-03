using UnityEngine;

public class PlayerJump : MonoBehaviour {

  [SerializeField] float jumpVelocity;
  [SerializeField] float fallGravityScale;

  Rigidbody2D _rigidbody;
  float _initialGravityScale;
  bool canJump;
  void Awake() {
    _rigidbody = GetComponent<Rigidbody2D>();
    canJump = true;
    _initialGravityScale = _rigidbody.gravityScale;
  }

  void Update() {
    //handle jump input
    var movementY = Input.GetAxisRaw("Vertical");
    if (canJump && movementY > 0) {
      _rigidbody.velocity = Vector2.up * jumpVelocity;
      canJump = false;
    }
  }

  void FixedUpdate() {
    //better jump
    if (_rigidbody.velocity.y < 0) {
      //if player falls
      _rigidbody.gravityScale = fallGravityScale;
    }
  }

  void OnCollisionEnter2D(Collision2D other) {
    //reset canJump
    if (other.gameObject.CompareTag("Environment") && other.gameObject.transform.position.y < transform.position.y) {
      _rigidbody.gravityScale = _initialGravityScale;
      canJump = true;
    }
  }
}
