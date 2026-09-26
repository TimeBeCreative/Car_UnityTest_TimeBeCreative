using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _destroyClip;

    private bool _chasePlayer;
    private int _currentHp;

    private void Awake()
    {


        if (_enemyData != null)
        {
            _currentHp = _enemyData.maxHp;
        } else
        {
            Debug.Log("No scriptable EnemyData added to Enemy");
        }

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        
    }

    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("2DAudioSource").GetComponent<AudioSource>();
    }

    public void ChasePlayer()
    {
        _chasePlayer = true;
        _animator.SetBool("Running", true);

       
    }

    public void TakeDamage(int damage)
    {
        _audioSource.PlayOneShot(_destroyClip);

            _currentHp -= damage;
        if (_currentHp <= 0)
        {
            Die();
        }
    }

    public void Attack(int damage)
    {
        _animator.SetTrigger("Attack");
        _player.TakeDamage(damage);
    }

    private void Update()
    {
        if(_chasePlayer)
        {
            Vector3 direction = (_player.transform.position - transform.position).normalized;
            float step = _enemyData.moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, step);

            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, step);
            }
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack(_enemyData.damage);
        }
    }

}

public interface IDamageable
{
    void TakeDamage(int damage);
    void Attack(int damage);
}