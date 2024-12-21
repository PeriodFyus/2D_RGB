using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadyDeadState : EnemyState
{
    private EnemyShady enemy;
    public ShadyDeadState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyShady enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
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
