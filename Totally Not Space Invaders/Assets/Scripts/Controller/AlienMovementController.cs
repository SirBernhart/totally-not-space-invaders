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

    private List<Alien> _allAliens;
    private float _currentMovementInterval;
    private float _movementTimer;
    private Vector2 _currentMoveVector = Vector2.right;
    
    private float _alienHorizontalMoveLimit;

    public void Setup(List<Alien> aliens)
    {
        _allAliens = aliens;
        
        Camera mainCamera = Camera.main;
        _alienHorizontalMoveLimit = mainCamera.orthographicSize *  mainCamera.aspect - screenLimitOffset;
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
            Alien alien = _allAliens[i];
            if (alien == null)
            {
                _allAliens.RemoveAt(i);
                i--;
                continue;
            }
            
            if (!alien.CanMoveInDirection(_alienHorizontalMoveLimit, _currentMoveVector))
            {
                return false;
            }
        }

        return true;
    }
}
