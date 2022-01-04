using UnityEngine;

public class ResetCanJump : MonoBehaviour {
  Rigidbody2D _parentRigidbody;
  PlayerJump _playerJumpScript;

  private void Awake() {
    _parentRigidbody = GetComponentInParent<Rigidbody2D>();
    _playerJumpScript = GetComponentInParent<PlayerJump>();
  }

  private void OnTriggerEnter2D(Collider2D other) {
    //reset canJump
    if (!_playerJumpScript.canJump && other.gameObject.CompareTag("Environment")) {
      _playerJumpScript.canJump = true;
    }
  }
}
