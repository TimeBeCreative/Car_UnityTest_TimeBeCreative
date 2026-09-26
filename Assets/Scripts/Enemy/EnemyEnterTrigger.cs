using UnityEngine;

public class EnemyEnterTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemy.ChasePlayer();
        }
    }
}
