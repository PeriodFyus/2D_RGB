using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherGroundState : EnemyState
{
    protected Transform player;
    protected EnemyArcher enemy;

    public ArcherGroundState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyArcher _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.transform.position) < enemy.agroDistance)
            stateMachine.ChangeState(enemy.battleState);
    }
}