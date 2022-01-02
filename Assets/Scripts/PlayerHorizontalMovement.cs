using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour {
  [SerializeField] float movementSpeed;
  Rigidbody2D _rigidbody;

  private void Start() {
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  private void Update() {
    //walk left right
    var movementX = Input.GetAxis("Horizontal");
    transform.Translate(movementX * movementSpeed * Time.deltaTime, 0, 0, Space.World);
  }
}