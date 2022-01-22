using UnityEngine;

public class PlayerStateManager : MonoBehaviour {
  //set relevant variables
  [SerializeField] public float movementSpeed;
  [SerializeField] public float jumpVelocity;
  [SerializeField] public float dashSpeed;
  [SerializeField] public float dashDuration; //in milliseconds
  //vars scripts need to access
  [System.NonSerialized] public Rigidbody2D rb;
  [System.NonSerialized] public BoxCollider2D boxCollider;
  [System.NonSerialized] public float inputX; //input left and right (e.g. for walking)
  [System.NonSerialized] public bool inputY; //input up and down (e.g. for jumping)
  [System.NonSerialized] public int jumpsAvailable; //number of jumps available
  [System.NonSerialized] public int dashesAvailable; //number of dashes available
  [System.NonSerialized] public bool directionLeft = false; //shows if direction is left or right

  // coyote time variables
  [System.NonSerialized] public float coyoteTimer; //counts how much time has passed after being airborne
  [System.NonSerialized] public float coyoteTime = 0.1f; //defines how long coyote time should be

  // instantiate state objects
  PlayerBaseState currentState;
  [System.NonSerialized] public PlayerBaseState prevState; //previousState;
  public PlayerWalkingState WalkingState = new PlayerWalkingState(); //idle & walking
  public PlayerAirborneState AirborneState = new PlayerAirborneState(); //in air (jumping or falling)
  public PlayerDashState DashState = new PlayerDashState(); //dash forward

  //call state methods
  void Start() {
    //get components
    rb = GetComponent<Rigidbody2D>();
    boxCollider = GetComponent<BoxCollider2D>();

    //initial state
    prevState = AirborneState;
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
    prevState = currentState;
    currentState = state;
    state.EnterState(this);
    //Debug.Log("Switched to State: " + currentState);
  }

  //player input & movement methods
  public void updateInputX() {
    inputX = Input.GetAxis("Horizontal");
    //update directionX: stays the same if no input
    if (inputX < 0) directionLeft = true;
    else if (inputX > 0) directionLeft = false;
  }

  public void updateInputY() {
    if (Input.GetKeyDown(KeyCode.W)) inputY = true;
  }

  public void handleWalk() {
    //normal "walking" sets player horizontal velocity according to input when called
    rb.velocity = new Vector2(inputX * movementSpeed, rb.velocity.y);
  }

  public void handleJump() {
    //checks if "jump" has been pressed and if so, jumps
    if (inputY && jumpsAvailable > 0) {
      rb.velocity = new Vector2(rb.velocity.x, jumpVelocity); //upwards movement
      if (currentState != WalkingState && coyoteTimer < 0f) jumpsAvailable--; //only decrement if player is not walking (and coyote time has ran out), otherwise first jump is "free"
      inputY = false;
    }
  }

  public void handleDash() {
    if (dashesAvailable > 0) {
      dashesAvailable--;
      SwitchState(DashState);
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
