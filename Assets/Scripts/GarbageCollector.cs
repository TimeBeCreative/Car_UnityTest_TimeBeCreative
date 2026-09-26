using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
    private void FixedUpdate()
    {

        Vector3 _targetPosition = _target.position;
        _targetPosition += _offset;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed);
    }
}
