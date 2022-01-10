using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour {
  PlayerBaseState currentState;
  public PlayerIdleState IdleState = new PlayerIdleState();
  public PlayerWalkingState WalkingState = new PlayerWalkingState();
  public PlayerAirborneState AirborneState = new PlayerAirborneState();

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
