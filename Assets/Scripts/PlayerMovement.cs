using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] float movementSpeed = 1;
  Rigidbody2D _rigidbody;
  private void Start()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {

  }
}
