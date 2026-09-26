using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField] private InputActionReference _startGameAction;

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _WinClip;

    //private bool _isPlaying = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        PlayerPrefs.SetString("GameState", "Start");

        _audioSource = GameObject.FindGameObjectWithTag("2DAudioSource").GetComponent<AudioSource>();

        _player.GetComponent<Player>().enabled = false;
        _player.GetComponent<ShootingSystem>().enabled = false;
    }
    void Update()
    {
        var gameState = PlayerPrefs.GetString("GameState");
        switch (gameState)
        {
            case "Start":
                if (_startGameAction.action.WasPressedThisFrame())
                {
                    // _isPlaying = true;
                    PlayerPrefs.SetString("GameState", "isPlaying");
                    StartGame();
                }
                break;

            case "Lose":
            case "Win":
                if (_startGameAction.action.WasPressedThisFrame())
                {
                    RestartGame();
                }
                
                break;

        }

        
        
    }

    public void StartGame()
    {
        PlayerPrefs.SetString("GameState", "Playing");
        _player.GetComponent<Player>().enabled = true;
        _player.GetComponent<ShootingSystem>().enabled = true;
        _enemySpawner.GetComponent<EnemySpawner>().enabled = true;
    }

    public void Lose()
    {
        _losePanel.SetActive(true);


        _player.GetComponent<Player>().enabled = false;
        _player.GetComponent<ShootingSystem>().enabled = false;
        _enemySpawner.GetComponent<EnemySpawner>().enabled = false;

        PlayerPrefs.SetString("GameState", "Lose");
    }


    public void Win()
    {

        _audioSource.PlayOneShot(_WinClip);

        _winPanel.SetActive(true);

        _player.GetComponent<Player>().enabled = false;
        _player.GetComponent<ShootingSystem>().enabled = false;

        _enemySpawner.GetComponent<EnemySpawner>().enabled = false;

        PlayerPrefs.SetString("GameState", "Win");
    }

    public void RestartGame()
    {
        PlayerPrefs.SetString("GameState", "Start");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
