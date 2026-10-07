using UnityEngine;

public class PlayerShipMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    
    public void Move (Vector2 direction)
    {
        _rigidbody.linearVelocity = direction * _speed;
    }
}
