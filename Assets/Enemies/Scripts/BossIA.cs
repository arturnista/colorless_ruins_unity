using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIA : MonoBehaviour, ILevelListener
{

    [SerializeField] private AudioClip _deathSound;

    private BossHealth _health;
    private Animator _animator;
    
    private BossMultipleAttack _multipleAttack;

    private enum FightStage
    {
        Start,
        Angry,
        Final   
    }
    private FightStage _stage;

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnLevelStart()
    {
        _animator = GetComponentInChildren<Animator>();
        _health = GetComponent<BossHealth>();
        _multipleAttack = GetComponent<BossMultipleAttack>();
        _health.OnTakeDamage += HandleTakeDamage;

        _stage = FightStage.Start;
    }

    public void OnLevelEnd()
    {
        _health.OnTakeDamage -= HandleTakeDamage;
    }

    void HandleTakeDamage()
    {
        switch (_stage)
        {
            case FightStage.Start:
                if (_health.HealthPercentage > .7f) break;
                StopAllCoroutines();
                StartCoroutine(AngryStageCoroutine());
                break;
            case FightStage.Angry:
                if (_health.HealthPercentage > .3f) break;
                StopAllCoroutines();
                StartCoroutine(FinalStageCoroutine());
                break;
        }

        if (_health.HealthPercentage <= 0f)
        {
            StopAllCoroutines();
            StartCoroutine(DeathCoroutine());
        }
    }

    IEnumerator AngryStageCoroutine()
    {
        _stage = FightStage.Angry;
        _animator.SetTrigger("Angry");
        _animator.SetBool("IsFinal", false);
        yield return new WaitForSeconds(.5f);
        _multipleAttack.Fire();
    }

    IEnumerator FinalStageCoroutine()
    {
        _stage = FightStage.Final;
        _animator.SetTrigger("Angry");
        _animator.SetBool("IsFinal", true);
        yield return new WaitForSeconds(.5f);
        _multipleAttack.Fire(2);

        while (true)
        {
            yield return new WaitForSeconds(2f);
            _multipleAttack.Fire();
        }
    }

    IEnumerator DeathCoroutine()
    {
        if (_deathSound != null)
        {
            _audioSource.PlayOneShot(_deathSound);
        }
        Destroy(GetComponent<BossAttack>());
        Destroy(GetComponent<KillPlayerOnTrigger>());

        GameObject[] dangers = GameObject.FindGameObjectsWithTag("Danger");
        foreach (var item in dangers)
        {
            Destroy(item);
        }

        _animator.SetTrigger("Death");
        yield return new WaitForSeconds(2f);

        GameObject.FindObjectOfType<KnightSymbol>().Activate();
        GameObject.FindObjectOfType<FinalPortal>().Activate();
        UIMessage.Main.Show("After you defeat the skull-head-thing, you watch as a portal is created in front of you.\n\nInside, you can see the Color Kingdom, your realm.");
        Destroy(gameObject);
    }

}
