using System;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    private Transform cameraHolder;
    private float xRotation;
    private IPlayerInput playerInput;
    
    public void Init(Transform target, IPlayerInput input)
    {
        cameraHolder = target;
        playerInput = input;
    }
    
    public void SetMouseLookX(float xValue)
    {
        xRotation += xValue * Time.deltaTime * 50;
        xRotation = Mathf.Clamp(xRotation, -70, 80);
        transform.rotation = Quaternion.Euler(-xRotation, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void Update()
    {
        if (cameraHolder != null)
        {
            transform.position = cameraHolder.transform.position;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, cameraHolder.transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    private void LateUpdate()
    {
        SetMouseLookX(playerInput.LookInput.y);
    }
}
