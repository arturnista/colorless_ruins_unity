using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWallGlitch : MonoBehaviour, ILevelListener
{

    private Animator _animator;
    
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void OnLevelStart()
    {
        StartCoroutine(GlitchCoroutine());
    }

    public void OnLevelEnd()
    {
        StopAllCoroutines();
    }

    IEnumerator GlitchCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f + Random.Range(2f, 4f));
            _animator.SetTrigger("Glitch");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }

}
