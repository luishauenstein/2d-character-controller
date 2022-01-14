using UnityEngine;
using System;

public class PlayerDashState : PlayerBaseState {
  int direction;
  DateTime endingTime; //time stamp of when dash state should be left
  public override void EnterState(PlayerStateManager player) {
    endingTime = DateTime.Now.AddMilliseconds(player.dashDuration);
    //get direction
    player.updateInputX();
    if (player.directionLeft) direction = -1;
    else direction = 1;
  }

  public override void UpdateState(PlayerStateManager player) {

  }

  public override void FixedUpdateState(PlayerStateManager player) {
    if (DateTime.Now < endingTime) {
      player.rb.velocity = new Vector2(player.dashSpeed * direction, 0);
    } else {
      //if time is up: check if grounded and then assign player the correct state
      if (player.isGrounded())
        player.SwitchState(player.WalkingState);
      else
        player.SwitchState(player.AirborneState);
    }
  }

  public override void OnCollisionEnter2D(PlayerStateManager player, Collision2D collision) {

  }

  public override void OnCollisionExit2D(PlayerStateManager player, Collision2D collision) {

  }
}
