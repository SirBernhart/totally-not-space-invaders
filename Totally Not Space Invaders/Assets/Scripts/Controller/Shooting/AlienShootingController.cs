using UnityEngine;
using Random = UnityEngine.Random;

public class AlienShootingController : MonoBehaviour
{
    [SerializeField] private float shotInterval;
    [SerializeField] private float chanceToShoot;
    [SerializeField] private ProjectileController[] projectileControllerPrefabs;

    private float _shotTimer = 0;
    
    private void Update()
    {
        if (_shotTimer >= shotInterval)
        {
            _shotTimer = 0;
            TryShooting();
        }
        
        _shotTimer += Time.deltaTime;
    }

    private void TryShooting()
    {
        if (!WillShoot())
        {
            return;
        }
        
        Instantiate(PickProjectilePrefab(), transform.position, Quaternion.identity);
    }

    private bool WillShoot()
    {
        int draftedChance = Random.Range(0, 100);
        return chanceToShoot > draftedChance;
    }
    
    private ProjectileController PickProjectilePrefab()
    {
        int projectileIndex = Random.Range(0, projectileControllerPrefabs.Length);
        return projectileControllerPrefabs[projectileIndex];
    }
}
