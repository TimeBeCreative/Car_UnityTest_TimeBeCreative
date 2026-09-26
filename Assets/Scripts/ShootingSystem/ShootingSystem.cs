using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private GameObject _device;
    [SerializeField] private InputActionReference _screenPos;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private ShootingDevice _shootingDevice;


    [SerializeField] private Transform _firePoint;

    private IShootingSystem _shootingSystem;

    private void Awake()
    {

        _shootingSystem = new Turret(
            _device,
            _screenPos,
            _shootingDevice.bulletPrefab,
            _firePoint,
            _shootingDevice.shootCooldown,
            _shootingDevice.damage
            );
    }

    private void Update()
    {
        _shootingSystem.ShootingDeviceMovement();
        _shootingSystem.Shoot(_shootingDevice.damage);
    }
}
