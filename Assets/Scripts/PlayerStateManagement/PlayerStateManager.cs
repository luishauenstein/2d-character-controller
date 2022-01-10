using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour {
  PlayerBaseState currentState;
  public PlayerWalkingState WalkingState = new PlayerWalkingState(); //idle & walking
  public PlayerAirborneState AirborneState = new PlayerAirborneState(); //in air (jumping or falling)
  public PlayerDashState IdleState = new PlayerDashState(); //dash forward

  void Start() {
    //initial state
    currentState = IdleState;
    currentState.EnterState(this);
  }

  void Update() {
    currentState.UpdateState(this);
  }

  void OnCollisionEnter(Collision collision) {
    currentState.OnCollisionEnter(this, collision);
  }
  public void SwitchState(PlayerBaseState state) {
    currentState = state;
    state.EnterState(this);
  }
}
