using UnityEngine;

public class PlayerAirborneState : PlayerBaseState {
  public override void EnterState(PlayerStateManager player) {

  }

  public override void UpdateState(PlayerStateManager player) {
    //only update inputs that are needed
    player.updateInputX();
    player.updateInputY();

    //hanlde dash
    if (player.dashesAvailable > 0 && Input.GetKeyDown("left shift")) {
      player.dashesAvailable--;
      player.SwitchState(player.DashState);
    }
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
