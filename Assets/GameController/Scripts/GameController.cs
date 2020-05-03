using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    private static SaveData _saveData;
    public static SaveData SaveData { get => _saveData; }

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Vector3 _spawnPosition;

    private GameObject _player;
    private PlayerHealth _playerHealth;
    private PlayerMovement _playerMovement;
    private PlayerFruits _playerFruits;
    private PlayerGems _playerGems;

    private Vector3 _respawnPosition;
    private Vector3 _respawnDirection;

    private GameObject _levelReference;
    private GameObject _levelPrefab;

    private Vector3 _cameraTargetPosition;
    private Camera _mainCamera;

    private Transform _lastCheckpoint;
    private IPlayerListener[] _playerListeners;

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    void Start()
    {
        // The game do not need to run at 1000 FPS....
        Application.targetFrameRate = 300;

        _respawnPosition = _spawnPosition;
        _respawnDirection = Vector3.zero;
        _saveData = new SaveData();

        _playerListeners = GetComponentsInChildren<IPlayerListener>();

        CreatePlayer();

        UIMessage.Main.Show("Move using WASD.\nYou can pause using ESC.\n\nCollect the KEY to open the door.");
    }

    void CreatePlayer()
    {
        _player = Instantiate(_playerPrefab, _respawnPosition, Quaternion.identity, transform);
        
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _playerMovement.ForceMovement(_respawnDirection);
        _playerMovement.HasFreeMovement = _saveData.HasFreeMovement;

        _playerFruits = _player.GetComponent<PlayerFruits>();
        _playerFruits.FruitCount = _saveData.FruitCount;

        _playerGems = _player.GetComponent<PlayerGems>();
        _playerGems.Red = _saveData.RedGem;
        _playerGems.Blue = _saveData.BlueGem;
        _playerGems.Green = _saveData.GreenGem;
        _playerGems.Yellow = _saveData.YellowGem;

        _playerHealth = _player.GetComponent<PlayerHealth>();
        _playerHealth.OnPlayerDeath += HandlePlayerDeath;

        if (_levelReference != null)
        {
            Destroy(_levelReference);
            _levelReference = Instantiate(_levelPrefab, transform);
            _levelReference.SetActive(true);
            _levelReference.name = _levelReference.name.Substring(7);
        }

        foreach (var listener in _playerListeners)
        {
            listener.OnPlayerCreate(_player);
        }
    }

    void HandlePlayerDeath()
    {
        StartCoroutine(PlayerRespawnCoroutine());
    }

    IEnumerator PlayerRespawnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        CreatePlayer();
    }

    public void CollectCheckpoint(Transform checkpoint)
    {
        _respawnPosition = _playerMovement.transform.position;
        _respawnDirection = _playerMovement.Direction;

        if (_levelPrefab != null)
        {
            Destroy(_levelPrefab);
        }
        
        Save();

        _levelReference = checkpoint.gameObject;
        _levelPrefab = Instantiate(_levelReference, transform);
        _levelPrefab.SetActive(false);
        _levelPrefab.name = "PREFAB_" + _levelReference.name;

        _cameraTargetPosition = checkpoint.position;
        StartCoroutine(CameraMoveCoroutine(checkpoint));
    }

    IEnumerator CameraMoveCoroutine(Transform checkpoint)
    {
        if (_lastCheckpoint != null)
        {
            var endListeners = _lastCheckpoint.GetComponentsInChildren<ILevelListener>();
            foreach (var listener in endListeners)
            {
                listener.OnLevelEnd();
            }
        }
        
        _playerMovement.enabled = false;
        Vector3 target = new Vector3(_cameraTargetPosition.x, _cameraTargetPosition.y, -10f);
        while (target != _mainCamera.transform.position)
        {
            _mainCamera.transform.position = Vector3.MoveTowards(_mainCamera.transform.position, target, 20f * Time.deltaTime);
            yield return null;
        }

        _playerMovement.enabled = true;

        var startListeners = checkpoint.GetComponentsInChildren<ILevelListener>();
        foreach (var listener in startListeners)
        {
            listener.OnLevelStart();
        }

        _lastCheckpoint = checkpoint;
    }

    public void Save()
    {
        _saveData.HasFreeMovement = _playerMovement.HasFreeMovement;

        _saveData.FruitCount = _playerFruits.FruitCount;

        _saveData.RedGem = _playerGems.Red;
        _saveData.BlueGem = _playerGems.Blue;
        _saveData.GreenGem = _playerGems.Green;
        _saveData.YellowGem = _playerGems.Yellow;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_spawnPosition, Vector3.one);
    }

}
