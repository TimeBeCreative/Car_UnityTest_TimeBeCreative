using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int Damage;
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private GameObject _explosionEffect;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }

        if (_explosionEffect != null)
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Instantiate(_explosionEffect, contactPoint, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
