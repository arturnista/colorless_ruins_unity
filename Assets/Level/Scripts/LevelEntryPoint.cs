using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntryPoint : MonoBehaviour
{
    
    private static LevelEntryPoint s_CurrentLevel;

    private Camera _mainCamera;
    private GameController _gameController;

    void Awake()
    {
        _mainCamera = Camera.main;
        _gameController = GameObject.FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player") return;

        if (s_CurrentLevel == this) return;
        s_CurrentLevel = this;

        _gameController.CollectCheckpoint(transform.parent);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (s_CurrentLevel != this) return;
        s_CurrentLevel = null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        GizmosDrawCamera();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        GizmosDrawCamera();
    }

    void GizmosDrawCamera()
    {
        Camera camera = Camera.main;
        float height = camera.orthographicSize * 2f;
        float width = camera.aspect * height;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1f));
    }
}
