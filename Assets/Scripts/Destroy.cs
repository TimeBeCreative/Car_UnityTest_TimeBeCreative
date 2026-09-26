using UnityEngine;

public class Destroy : MonoBehaviour
{

    [SerializeField] private float _lifeTime;
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
