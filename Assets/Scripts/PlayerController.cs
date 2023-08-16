using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMoveController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    
    private IPlayerInput input;
    private PlayerMoveController playerMoveController;
    private PlayerGroundInfo playerGroundInfo;

    public Transform CameraHolder => cameraHolder;

    public void Init(IPlayerInput playerInput)
    {
        input = playerInput;
    }

    private void Awake()
    {
        playerMoveController = GetComponent<PlayerMoveController>();
        playerGroundInfo = GetComponent<PlayerGroundInfo>();
        
        playerMoveController.SetMoveSpeed(20);
        playerMoveController.SetRotationSpeed(100);
    }

    private void Update()
    {
        playerMoveController.RotationOnYAxis(input.LookInput.x);
    }

    private void FixedUpdate()
    {
        playerMoveController.MoveOnGround(input.InputDirection.normalized, playerGroundInfo.GroundNormal);
    }
}
