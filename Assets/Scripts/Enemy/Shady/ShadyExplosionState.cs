using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadyExplosionState : EnemyState
{
    private EnemyShady enemy;
    public ShadyExplosionState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyShady enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
            enemy.SelfDestroy();
    }
}
