using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private ProjectileController projectileControllerPrefab;
    
    private bool canShoot = true;
    
    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }
        
        ProjectileController projectile = Instantiate(projectileControllerPrefab, transform.position, Quaternion.identity);
        projectile.Setup(HandleCurrentProjectileDestroyed);
        
        canShoot = false;
    }

    private void HandleCurrentProjectileDestroyed()
    {
        canShoot = true;
    }
}
