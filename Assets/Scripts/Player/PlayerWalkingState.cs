using UnityEngine;

public class PlayerWalkingState : PlayerBaseState {

  public override void EnterState(PlayerStateManager player) {
    // reset availability: set how many are available
    player.jumpsAvailable = 1;
    if (player.prevState == player.AirborneState) player.dashesAvailable = 1;
  }

  public override void UpdateState(PlayerStateManager player) {
    //only update inputs that are needed
    player.updateInputX();
    player.updateInputY();
  }

  public override void FixedUpdateState(PlayerStateManager player) {
    player.handleWalk();
    player.handleJump();

  }

  public override void OnCollisionEnter2D(PlayerStateManager player, Collision2D collision) {

  }
  public override void OnCollisionExit2D(PlayerStateManager player, Collision2D collision) {
    if (!player.isGrounded()) player.SwitchState(player.AirborneState);
  }
}
