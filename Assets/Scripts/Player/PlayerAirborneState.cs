using UnityEngine;

public class PlayerAirborneState : PlayerBaseState {
  public override void EnterState(PlayerStateManager player) {
    player.coyoteTimer = player.coyoteTime;
  }

  public override void UpdateState(PlayerStateManager player) {
    //only update inputs that are needed
    player.updateInputX();
    player.updateInputY();
    //count coyote time down
    player.coyoteTimer -= Time.deltaTime;

    //handle dash
    bool dashIntent = false;
    if (Input.GetKeyDown("left shift") || Input.GetKeyDown(KeyCode.Space)) dashIntent = true;
    if (dashIntent && player.dashesAvailable > 0) {
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
