using UnityEngine;

//every state class inherits from this class
public abstract class PlayerBaseState {
  public abstract void EnterState(PlayerStateManager player);
  public abstract void UpdateState(PlayerStateManager player);
  public abstract void FixedUpdateState(PlayerStateManager player);
  public abstract void OnCollisionEnter2D(PlayerStateManager player, Collision2D collision);
  public abstract void OnCollisionExit2D(PlayerStateManager player, Collision2D other);
}
