using UnityEngine;
using UnityEngine.UI;

public class ParrySkill : Skill
{
    [Header("Parry")]
    [SerializeField] private UI_SkillTreeSlot parryUnlockedButton;
    public bool parryUnlocked { get; private set; }

    [Header("Parry Restore")]
    [SerializeField] private UI_SkillTreeSlot restoreUnlockedButton;
    [Range(0f, 1f)]
    [SerializeField] private float restoreHealthPerentage;
    public bool restoreUnlocked {  get; private set; }

    [Header("Parry With Mirage")]
    [SerializeField] private UI_SkillTreeSlot parryWithMirageUnlockedButton;
    public bool parryWithMirageUnlocked {  get; private set; }

    public override void UseSkill()
    {
        base.UseSkill();

        if (restoreUnlocked)
        {
            int restoreAmount = Mathf.RoundToInt(player.stats.GetMaxHealthValue() * restoreHealthPerentage);
;            player.stats.IncreaseHealthBy(restoreAmount);

        }
    }

    protected override void Start()
    {
        base.Start();

        parryUnlockedButton.GetComponent<Button>().onClick.AddListener(UnlockParry);
        restoreUnlockedButton.GetComponent<Button>().onClick.AddListener(UnlockRestore);
        parryWithMirageUnlockedButton.GetComponent<Button>().onClick.AddListener(UnlockParryWithMirage);
    }

    protected override void CheckUnlock()
    {
        UnlockParry();
        UnlockRestore();
        UnlockParryWithMirage();
    }

    private void UnlockParry()
    {
        if (parryUnlockedButton.unlocked)
            parryUnlocked = true;
        else
            parryUnlocked = false;
    }

    private void UnlockRestore()
    {
        if (restoreUnlockedButton.unlocked)
            restoreUnlocked = true;
        else
            restoreUnlocked = false;
    }

    private void UnlockParryWithMirage()
    {
        if (parryWithMirageUnlockedButton.unlocked)
            parryWithMirageUnlocked = true;
        else
            parryWithMirageUnlocked = false;
    }

    public void MakeMirageOnParry(Transform _respawnTransform)
    {
        if (parryWithMirageUnlocked)
            SkillManager.instance.clone.CreateCloneWithDelay(_respawnTransform);
    }
}
