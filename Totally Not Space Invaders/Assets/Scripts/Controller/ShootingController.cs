using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private float _shotSpeed;
    [SerializeField] private float _shotInterval;
    [SerializeField] private bool _onlyAllowOneActiveShot;
    [SerializeField] private ProjectileController _projectileControllerPrefab;
    [SerializeField] private Vector2 _shotDirection;

    private bool canShoot = true;
    
    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }
        
        ProjectileController projectile = Instantiate(_projectileControllerPrefab, transform.position, Quaternion.identity);
        projectile.Setup(_shotDirection, _shotSpeed, HandleCurrentProjectileDestroyed);
        canShoot = false;
    }

    private void HandleCurrentProjectileDestroyed()
    {
        canShoot = true;
    }
    
}
