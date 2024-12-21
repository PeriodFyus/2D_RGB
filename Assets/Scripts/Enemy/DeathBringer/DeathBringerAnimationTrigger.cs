using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBringerAnimationTrigger : EnemyAnimationTriggers
{
    private EnemyDeathBringer enemyDeathBringer => GetComponentInParent<EnemyDeathBringer>();

    private void Relocate() => enemyDeathBringer.FindPosition();

    private void MakeInvisible() => enemyDeathBringer.fx.MakeTransprent(true);

    private void Makevisible() => enemyDeathBringer.fx.MakeTransprent(false);
}
