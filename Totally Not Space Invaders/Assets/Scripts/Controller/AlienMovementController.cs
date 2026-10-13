using System;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovementController : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float baseMovementInterval;
    [SerializeField] private float movementIntervalDecrease;
    [SerializeField] private float minAllowedMovementInterval;
    [SerializeField] private float screenLimitOffset;

    private List<Transform> _allAliens;
    private float _currentMovementInterval;
    private float _movementTimer;
    private Vector2 _currentMoveVector = Vector2.right;
    
    private float _playerHorizontalMoveLimit;

    public void Setup(List<Transform> aliens)
    {
        _allAliens = aliens;
        
        Camera mainCamera = Camera.main;
        _playerHorizontalMoveLimit = mainCamera.orthographicSize *  mainCamera.aspect - screenLimitOffset;
        _currentMoveVector *= movementDistance;
        _currentMovementInterval = baseMovementInterval;
    }

    private void Update()
    {
        if (_allAliens.Count == 0)
        {
            return;
        }
        
        if (_movementTimer < _currentMovementInterval)
        {
            _movementTimer += Time.deltaTime;
            return;
        }

        if (!CanKeepMovingInSameDirection())
        {
            transform.Translate(Vector2.down * movementDistance);
            _currentMovementInterval = Math.Max(minAllowedMovementInterval, _currentMovementInterval - movementIntervalDecrease);
            _currentMoveVector *= -1;
        }
        else
        {
            transform.Translate(_currentMoveVector);
        }
        
        _movementTimer = 0f;
    }

    private bool CanKeepMovingInSameDirection()
    {
        for(int i = 0; i < _allAliens.Count; i++)
        {
            Transform alienTransform = _allAliens[i];
            if (alienTransform == null)
            {
                _allAliens.RemoveAt(i);
                i--;
                continue;
            }
            
            if (alienTransform.position.x >= _playerHorizontalMoveLimit && _currentMoveVector.x > 0
                || alienTransform.position.x <= -_playerHorizontalMoveLimit && _currentMoveVector.x < 0)
            {
                return false;
            }
        }

        return true;
    }
}
