using UnityEngine;

public abstract class PlayerBaseState {
  public abstract void EnterState(PlayerStateManager player);
  public abstract void UpdateState(PlayerStateManager player);
  public abstract void OnCollisionEnter(PlayerStateManager player, Collision collision);
}
