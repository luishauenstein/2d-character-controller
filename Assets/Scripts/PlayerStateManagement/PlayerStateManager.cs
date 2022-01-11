using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour {
  //set relevant variables
  [SerializeField] float movementSpeed;
  [SerializeField] float jumpVelocity;

  //get components so scripts can access
  public Rigidbody2D rb;
  public BoxCollider2D boxCollider;

  // instantiate state objects
  PlayerBaseState currentState;
  public PlayerWalkingState WalkingState = new PlayerWalkingState(); //idle & walking
  public PlayerAirborneState AirborneState = new PlayerAirborneState(); //in air (jumping or falling)
  public PlayerDashState IdleState = new PlayerDashState(); //dash forward

  //call state methods
  void Start() {
    //get components
    rb = GetComponent<Rigidbody2D>();
    boxCollider = GetComponent<BoxCollider2D>();

    //initial state
    currentState = IdleState;
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

  public void SwitchState(PlayerBaseState state) {
    currentState = state;
    state.EnterState(this);
  }
}
