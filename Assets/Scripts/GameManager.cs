using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMouseLook playerMouseLook;

    private IPlayerInput gameInput;
    
    private void Awake()
    {
        gameInput = GetComponent<IPlayerInput>();
        
        playerController.Init(gameInput);
        playerMouseLook.Init(playerController.CameraHolder, gameInput);
    }
}
