using UnityEngine;

public class PlayerWalkingState : PlayerBaseState {

  public override void EnterState(PlayerStateManager player) {

  }

  public override void UpdateState(PlayerStateManager player) {
    //only update inputs that are needed
    player.updateInputX();
    player.updateInputY();
  }

  public override void FixedUpdateState(PlayerStateManager player) {
    //set player horizontal velocity according to input
    player.rb.velocity = new Vector2(player.inputX * player.movementSpeed, player.rb.velocity.y);
  }

  public override void OnCollisionEnter2D(PlayerStateManager player, Collision2D collision) {

  }
  public override void OnCollisionExit2D(PlayerStateManager player, Collision2D collision) {

  }
}
