using UnityEngine;

public class PlayerWalkingState : PlayerBaseState {

  float inputX;
  int inputY;

  public override void EnterState(PlayerStateManager player) {

  }

  public override void UpdateState(PlayerStateManager player) {
    //walk left right
    inputX = Input.GetAxis("Horizontal");
  }

  public override void FixedUpdateState(PlayerStateManager player) {
    //set player horizontal velocity according to input
    player.rb.velocity = new Vector2(inputX * player.movementSpeed, player.rb.velocity.y);
  }

  public override void OnCollisionEnter2D(PlayerStateManager player, Collision2D collision) {

  }
  public override void OnCollisionExit2D(PlayerStateManager player, Collision2D collision) {

  }
}
