using UnityEngine;

public interface IShootingSystem 
{
    int Damage { get; }
    void ShootingDeviceMovement();
    void Shoot(int damage);

}
