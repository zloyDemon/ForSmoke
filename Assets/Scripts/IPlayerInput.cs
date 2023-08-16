using UnityEngine;

public interface IPlayerInput
{
    Vector3 InputDirection { get; }
    Vector3 LookInput { get; }
    bool SprintEnabled { get; }
    bool IsInteract { get; }
}
