using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour {
  //set relevant variables
  [SerializeField] public float movementSpeed;
  [SerializeField] public float jumpVelocity;

  //get components so scripts can access
  [System.NonSerialized] public Rigidbody2D rb;
  [System.NonSerialized] public BoxCollider2D boxCollider;
  [System.NonSerialized] public float inputX; //input left and right (e.g. for walking)
  [System.NonSerialized] public float inputY; //input up and down (e.g. for jumping)

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

  //input methods
  public void updateInputX() {
    inputX = Input.GetAxis("Horizontal");
  }

  public void updateInputY() {
    inputY = Input.GetAxisRaw("Vertical");
  }
}
