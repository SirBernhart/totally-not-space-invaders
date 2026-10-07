using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actionAsset;
    [SerializeField] private ShootingController _shootingController;
    [SerializeField] private PlayerShipMovementController _movementController;
    
    
    private InputAction _moveAction;
    private InputAction _shootAction;
    private Vector2 _previousMoveDirection;

    private void Awake()
    {
        InputActionMap map = _actionAsset.FindActionMap("Player");
        _moveAction = map.FindAction("Move");
        _shootAction = map.FindAction("Attack");

        _shootAction.performed += HandleShootActionPerformed;
    }

    private void HandleShootActionPerformed(InputAction.CallbackContext obj)
    {
        _shootingController.Shoot();
    }

    private void Update()
    {
        _previousMoveDirection = _moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _movementController.Move(_previousMoveDirection);
    }
}
