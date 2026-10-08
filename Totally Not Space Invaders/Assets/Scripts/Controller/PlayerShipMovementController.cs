using UnityEngine;

public class PlayerShipMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _playerHorizontalMoveLimit;
    
    public void Move (Vector2 direction)
    {
        if (_rigidbody.position.x >= _playerHorizontalMoveLimit && direction.x > 0
            || _rigidbody.position.x <= -_playerHorizontalMoveLimit && direction.x < 0)
        {
            _rigidbody.linearVelocity = Vector2.zero;
            return;
        }
        
        _rigidbody.linearVelocity = direction * _speed;
    }
}
