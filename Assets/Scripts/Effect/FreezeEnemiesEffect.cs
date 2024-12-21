using UnityEngine;

[CreateAssetMenu(fileName = "Freeze Enemies Effect", menuName = "Data/Item Effect/Freeze Enemies Effect")]
public class FreezeEnemiesEffect : ItemEffect
{
    [SerializeField] private float duration;
    [SerializeField] private float radius;

    public override void ExecuteEffect(Transform _enemyPosition)
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        if (!Inventory.instance.CanUseArmor())
            return;

        if (playerStats.currentHealth > playerStats.GetMaxHealthValue() * 0.1f)
            return;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_enemyPosition.position, radius, PlayerManager.instance.player.whatIsEnemy);

        foreach (var hit in colliders)
        {
            hit.GetComponent<Enemy>()?.FreezeTimeFor(duration);
        }
    }
}
