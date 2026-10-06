using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actionAsset;
    [SerializeField] private ShootingController shootingController;
    
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        InputActionMap map = _actionAsset.FindActionMap("Player");
        moveAction = map.FindAction("Move");
        shootAction = map.FindAction("Attack");

        shootAction.performed += HandleShootActionPerformed;
    }

    private void HandleShootActionPerformed(InputAction.CallbackContext obj)
    {
        shootingController.Shoot();
    }
}
