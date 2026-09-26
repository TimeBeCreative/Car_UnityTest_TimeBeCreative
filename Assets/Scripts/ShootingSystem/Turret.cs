using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : IShootingSystem
{
    public int DeviceDamage;
    public int Damage => DeviceDamage;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _lastShootTime;

    private GameObject _turretObject;
    private InputActionReference _screenPos;
    
    
    public Turret(GameObject turretObject, InputActionReference screenPos, GameObject bulletPrefab, Transform firePoint, float shootCooldown, int deviceDamage)
    {
        _turretObject = turretObject;
        _screenPos = screenPos;
        _bulletPrefab = bulletPrefab;
        _firePoint = firePoint;
        _shootCooldown = shootCooldown;
        DeviceDamage = deviceDamage;
    }
    public void ShootingDeviceMovement()
    {
        float x = _screenPos.action.ReadValue<float>();
        float normalizedX = (x / Screen.width) * 2f - 1f;

        float rotationY = normalizedX * 90f;

        _turretObject.transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    public void Shoot(int damage)
    {
        if (Time.time - _lastShootTime < _shootCooldown)
        {
            return;
        }
        _lastShootTime = Time.time;
        GameObject bullet = Object.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.GetComponent<Bullet>().Damage = damage;
    }
}
