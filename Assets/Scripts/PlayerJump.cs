using UnityEngine;

public class PlayerJump : MonoBehaviour {

  [SerializeField] float jumpVelocity;
  [SerializeField] float fallMultiplier;

  Rigidbody2D _rigidbody;
  void Awake() {
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  void Update() {
    //handle jump input
    var movementY = Input.GetAxis("Vertical");
    if (movementY > 0) {
      _rigidbody.velocity = Vector2.up * jumpVelocity;
    }

    //better jump
    if (_rigidbody.velocity.y < 0) {
      //if player falls
      _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }
  }
}
