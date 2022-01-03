using UnityEngine;

public class PlayerJump : MonoBehaviour {

  [SerializeField] float jumpVelocity;
  [SerializeField] float fallMultiplier;

  Rigidbody2D _rigidbody;
  bool canJump;
  void Awake() {
    _rigidbody = GetComponent<Rigidbody2D>();
    canJump = true;
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
      _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }
  }

  void OnCollisionEnter2D(Collision2D other) {
    //reset canJump
    if (other.gameObject.CompareTag("Environment") && other.gameObject.transform.position.y < transform.position.y) {
      canJump = true;
    }
  }
}
