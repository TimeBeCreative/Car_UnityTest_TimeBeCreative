using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private float _speed;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private float _rotationSpeed;


    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _damageClip;

    private Rigidbody _rb;

    private void Awake()
    {
        _hp = 100;
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("2DAudioSource").GetComponent<AudioSource>();
    }

    public void NormalizeCar()
    {
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, 0, 0);
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            _rotationSpeed * Time.deltaTime * 100f
            );

        if (transform.position.x > 0 | transform.position.x < 0)
        {
            float newX = Mathf.MoveTowards(transform.position.x, 0f, _speed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            _rb.angularVelocity = Vector3.zero;
        }
    }

    public void TakeDamage(int damage)
    {
        _audioSource.PlayOneShot(_damageClip);

        _hp -= damage;
        if (_hp <= 0)
        {
            _hp = 0;
            UpdateHealthUI();
            Die();
        }
        UpdateHealthUI();

        
    }
    public void Die()
    {
        GameManager.Instance.Lose();
    }
    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y, _speed);
        NormalizeCar();
    }

    private void UpdateHealthUI()
    {
        if (_healthText != null)
        {
            _healthText.text = $"{_hp}";
        }
    }



   
}
