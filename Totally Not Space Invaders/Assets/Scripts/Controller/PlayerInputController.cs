using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private PlayerShootingController shootingController;
    [SerializeField] private PlayerShipMovementController movementController;
    
    private InputAction _moveAction;
    private InputAction _shootAction;
    private Vector2 _previousMoveDirection;

    private void Awake()
    {
        InputActionMap map = actionAsset.FindActionMap("Player");
        _moveAction = map.FindAction("Move");
        _shootAction = map.FindAction("Attack");

        _shootAction.performed += HandleShootActionPerformed;
    }

    private void HandleShootActionPerformed(InputAction.CallbackContext obj)
    {
        shootingController.Shoot();
    }

    private void Update()
    {
        _previousMoveDirection = _moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        movementController.Move(_previousMoveDirection);
    }
}
