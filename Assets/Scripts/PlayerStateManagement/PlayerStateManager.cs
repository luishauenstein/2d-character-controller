using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour {
  //set relevant variables
  [SerializeField] public float movementSpeed;
  [SerializeField] public float jumpVelocity;

  //vars scripts need to access
  [System.NonSerialized] public Rigidbody2D rb;
  [System.NonSerialized] public BoxCollider2D boxCollider;
  [System.NonSerialized] public float inputX; //input left and right (e.g. for walking)
  [System.NonSerialized] public float inputY; //input up and down (e.g. for jumping)
  [System.NonSerialized] public int jumpsAvailable; //number of jumps available
  [System.NonSerialized] public int dashesAvailable; //number of dashes available

  // instantiate state objects
  PlayerBaseState currentState;
  public PlayerWalkingState WalkingState = new PlayerWalkingState(); //idle & walking
  public PlayerAirborneState AirborneState = new PlayerAirborneState(); //in air (jumping or falling)
  public PlayerDashState DashState = new PlayerDashState(); //dash forward

  //call state methods
  void Start() {
    //get components
    rb = GetComponent<Rigidbody2D>();
    boxCollider = GetComponent<BoxCollider2D>();

    //initial state
    currentState = WalkingState;
    currentState.EnterState(this);
  }

  void Update() {
    currentState.UpdateState(this); //call update method on every state
  }

  void FixedUpdate() {
    currentState.FixedUpdateState(this);
  }

  void OnCollisionEnter2D(Collision2D collision) {
    currentState.OnCollisionEnter2D(this, collision);
  }

  void OnCollisionExit2D(Collision2D collision) {
    currentState.OnCollisionExit2D(this, collision);
  }

  // switch to another state
  public void SwitchState(PlayerBaseState state) {
    currentState = state;
    state.EnterState(this);
  }

  //player input & movement methods
  public void updateInputX() {
    inputX = Input.GetAxis("Horizontal");
  }

  public void updateInputY() {
    inputY = Input.GetAxisRaw("Vertical");
  }

  public void handleWalk() {
    //normal "walking" sets player horizontal velocity according to input when called
    rb.velocity = new Vector2(inputX * movementSpeed, rb.velocity.y);
  }

  public void handleJump() {
    //checks if "jump" has been pressed and if so, jumps
    if (inputY > 0 && jumpsAvailable > 0) {
      rb.velocity = new Vector2(rb.velocity.x, jumpVelocity); //upwards movement
      jumpsAvailable--;
      SwitchState(AirborneState);
    }
  }

  public bool isGrounded() {
    //check if player is grounded
    float boxHeight = 0.05f;
    LayerMask groundLayerMask = 1 << LayerMask.NameToLayer("Ground");
    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, boxHeight, groundLayerMask);
    bool grounded = raycastHit.collider != null;
    return grounded;
  }
}
