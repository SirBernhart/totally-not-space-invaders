using System;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] alienPrefabByRow;
    [SerializeField] private Transform aliensParent;
    [SerializeField] private float verticalSpacing;
    [SerializeField] private float horizontalSpacing;
    [SerializeField] private int aliensByRowAmount;
    [SerializeField] private AlienMovementController alienMovementController;

    private void Awake()
    {
        List<Transform> allAliens = new();
        float currentVerticalPosition = 0;
        foreach (Transform alienPrefab in alienPrefabByRow)
        {
            float currentHorizontalPosition = 0;
            
            for (int i = 0; i < aliensByRowAmount; i++)
            {
                Transform alien = Instantiate(alienPrefab, new Vector2(currentHorizontalPosition, currentVerticalPosition), 
                    Quaternion.identity, new InstantiateParameters{parent = aliensParent});
                
                allAliens.Add(alien);
                currentHorizontalPosition += horizontalSpacing;                
            }
            
            currentVerticalPosition -= verticalSpacing;
        }
        
        alienMovementController.Setup(allAliens);
    }
}
