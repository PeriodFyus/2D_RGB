using UnityEngine;

public class ItemEffect : ScriptableObject
{
    [TextArea]
    public string itemEffectDeScription;

    public virtual void ExecuteEffect(Transform _enemyPosition)
    {

    }
}
