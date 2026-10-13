using System;
using UnityEngine;

public class PlayerShipMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float screenLimitOffset;
    
    private float _playerHorizontalMoveLimit;
    
    private void Awake()
    {
        Camera mainCamera = Camera.main;
        _playerHorizontalMoveLimit = mainCamera.orthographicSize *  mainCamera.aspect - screenLimitOffset;
    }

    public void Move (Vector2 direction)
    {
        if (rigidbody.position.x >= _playerHorizontalMoveLimit && direction.x > 0
            || rigidbody.position.x <= -_playerHorizontalMoveLimit && direction.x < 0)
        {
            rigidbody.linearVelocity = Vector2.zero;
            return;
        }
        
        rigidbody.linearVelocity = direction * speed;
    }
}
