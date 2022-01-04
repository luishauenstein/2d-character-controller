using UnityEngine;

public class PlayerJump : MonoBehaviour {

  [SerializeField] float jumpVelocity;
  [SerializeField] float fallGravityScale;

  Rigidbody2D _rigidbody;
  public float initialGravityScale;
  public bool canJump;
  void Awake() {
    _rigidbody = GetComponent<Rigidbody2D>();
    canJump = true;
    initialGravityScale = _rigidbody.gravityScale;
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
    } else {
      _rigidbody.gravityScale = initialGravityScale;
    }
  }
}
