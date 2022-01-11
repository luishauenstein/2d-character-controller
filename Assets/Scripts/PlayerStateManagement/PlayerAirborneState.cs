using UnityEngine;

public class PlayerAirborneState : PlayerBaseState {
  public override void EnterState(PlayerStateManager player) {

  }

  public override void UpdateState(PlayerStateManager player) {
    //only update inputs that are needed
    player.updateInputX();
  }

  public override void FixedUpdateState(PlayerStateManager player) {
    player.handleWalk();
  }

  public override void OnCollisionEnter2D(PlayerStateManager player, Collision2D collision) {
    if (player.isGrounded()) player.SwitchState(player.WalkingState);
  }

  public override void OnCollisionExit2D(PlayerStateManager player, Collision2D collision) {

  }
}
