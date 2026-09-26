using UnityEngine;

[CreateAssetMenu(fileName = "ShootingDevice", menuName = "ShootingDevice/New ShootingDevice")]
public class ShootingDevice : ScriptableObject
{
    public int damage;
    public GameObject bulletPrefab;
    public float shootCooldown;
}
