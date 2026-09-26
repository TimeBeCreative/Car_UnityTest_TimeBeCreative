using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName  = "Enemy/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public int maxHp = 100;
    public int damage;
    public float moveSpeed = 2f;
}
