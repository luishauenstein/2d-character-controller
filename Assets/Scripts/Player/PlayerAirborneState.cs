using UnityEngine;

public class PlayerAirborneState : PlayerBaseState {
  public override void EnterState(PlayerStateManager player) {
    player.coyoteTimer = player.coyoteTime;
  }

  public override void UpdateState(PlayerStateManager player) {
    if (player.isGrounded()) player.SwitchState(player.WalkingState); //check if player is grounded each frame

    //only update inputs that are needed
    player.updateInputX();
    player.updateInputY();

    player.coyoteTimer -= Time.deltaTime; //count coyote time down

    if (Input.GetKeyDown("left shift") || Input.GetKeyDown(KeyCode.Space)) player.handleDash(); //handle dash
  }

  public override void FixedUpdateState(PlayerStateManager player) {
    player.handleWalk();
    player.handleJump();
  }

  public override void OnCollisionEnter2D(PlayerStateManager player, Collision2D collision) {
    if (player.isGrounded()) player.SwitchState(player.WalkingState);
  }

  public override void OnCollisionExit2D(PlayerStateManager player, Collision2D collision) {

  }
}
