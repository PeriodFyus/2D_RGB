using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounderState : PlayerState
{
    public PlayerGrounderState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.R) && player.skill.blackhole.blackholeUnlocked)
        {
            if (player.skill.blackhole.cooldownTimer > 0)
            {
                player.fx.CreatePopUpText("Cooldown");
                return;
            }

            stateMachine.ChangeState(player.blackholeState);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && HasNoSword() && player.skill.sword.swordUnlocked)  
            stateMachine.ChangeState(player.aimSwordState);

        if (Input.GetKeyDown(KeyCode.Q) && player.skill.parry.parryUnlocked) 
            stateMachine.ChangeState(player.counterAttackState); 

        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.primaryAttack);

        if (!player.IsGroundDetected() && !player.IsPlatformDetected())
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(KeyCode.Space) && (player.IsGroundDetected() || player.IsPlatformDetected()))  
            stateMachine.ChangeState(player.jumpState);

        if (Input.GetKeyDown(KeyCode.S) && player.IsPlatformDetected())
        {
            player.gameObject.layer = LayerMask.NameToLayer("Platform");
            player.ResetPlayerLayer();
        }
    }

    private bool HasNoSword()
    {
        if (!player.sword)
            return true;

        player.sword.GetComponent<SwordSkillController>().ReturnSword();
        return false;
    }
}
