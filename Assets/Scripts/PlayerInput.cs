using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    private Vector3 _input;
    private Vector3 _mouseAxis;
    private bool _isSprint;
    private bool _interactiveActivated;

    public Vector3 InputDirection => _input;
    public Vector3 LookInput => _mouseAxis;
    public bool SprintEnabled => _isSprint;
    public bool IsInteract => _interactiveActivated;
    
    public Vector3 MouseAxis => _mouseAxis;

    void Update()
    {
        CollectInput();
    }

    private void CollectInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        _input = new Vector3(xInput, 0, yInput);
        _isSprint = Input.GetKeyDown(KeyCode.LeftShift);
        _interactiveActivated = Input.GetKeyDown(KeyCode.F);
        _mouseAxis = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
