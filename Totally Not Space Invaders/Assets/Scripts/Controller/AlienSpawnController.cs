using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnController : MonoBehaviour
{
    [SerializeField] private Alien[] alienPrefabByRow;
    [SerializeField] private Transform aliensParent;
    [SerializeField] private float verticalSpacing;
    [SerializeField] private float horizontalSpacing;
    [SerializeField] private int aliensByRowAmount;
    [SerializeField] private AlienMovementController alienMovementController;

    public List<Alien> SpawnAliens()
    {
        List<Alien> allAliens = new();
        float currentVerticalPosition = 0;
        foreach (Alien alienPrefab in alienPrefabByRow)
        {
            float currentHorizontalPosition = 0;
            
            for (int i = 0; i < aliensByRowAmount; i++)
            {
                Alien alien = Instantiate(alienPrefab, new Vector2(currentHorizontalPosition, currentVerticalPosition), 
                    Quaternion.identity, new InstantiateParameters{parent = aliensParent});
                
                allAliens.Add(alien);
                currentHorizontalPosition += horizontalSpacing;                
            }
            
            currentVerticalPosition -= verticalSpacing;
        }
        
        alienMovementController.Setup(allAliens);
        return allAliens;
    }
}
