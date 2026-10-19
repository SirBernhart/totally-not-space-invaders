using System;
using UnityEngine;

public class PlayerShipMovementController : MonoBehaviour
{
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
        if (transform.position.x >= _playerHorizontalMoveLimit && direction.x > 0
            || transform.position.x <= -_playerHorizontalMoveLimit && direction.x < 0)
        {
            return;
        }
        
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
