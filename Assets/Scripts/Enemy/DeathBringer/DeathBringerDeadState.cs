using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBringerDeadState : EnemyState
{
    private EnemyDeathBringer enemy;

    public DeathBringerDeadState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,EnemyDeathBringer _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
        rb.velocity = Vector2.zero;
    }

    public override void Update()
    {
        base.Update();

        enemy.SetZeroVelocity();
    }
}
