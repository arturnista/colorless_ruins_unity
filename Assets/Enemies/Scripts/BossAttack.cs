using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : OrbShooter
{

    private GameObject _player;

    public override void OnLevelStart()
    {
        base.OnLevelStart();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override Vector2 GetAttackDirection()
    {
        if (_player == null) return Vector2.zero;
        return Vector3.Normalize(_player.transform.position - transform.position);
    }

}
