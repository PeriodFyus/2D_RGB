using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SkillTreeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISaveManager
{
    private UI ui;
    private Image skillImage;

    [SerializeField] private int skillCost;
    [SerializeField] private string skillName;
    [TextArea]
    [SerializeField] private string skillDescription;
    [SerializeField] private Color lockedSkillColor;

    public bool unlocked;

    [SerializeField] private UI_SkillTreeSlot[] conflictSkills;
    [SerializeField] private UI_SkillTreeSlot[] prepositionSkills;
    [SerializeField] private UI_SkillTreeSlot[] postpositionSkills;


    private void OnValidate()
    {
        gameObject.name = "SkillTreeSlot_UI_" + skillName;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => UnlockSkillSlot());
    }

    private void Start()
    {
        skillImage = GetComponent<Image>();
        ui = GetComponentInParent<UI>();

        skillImage.color = lockedSkillColor;

        if (unlocked)
            skillImage.color = Color.white;
    }


    public void UnlockSkillSlot()
    {
        if (!unlocked)
        {
            for (int i = 0; i < conflictSkills.Length; i++)
            {
                if (conflictSkills[i].unlocked)
                {
                    Debug.Log("Cannot unlock skill");
                    return;
                }
            }

            for (int i = 0; i < prepositionSkills.Length; i++)
            {
                if (!prepositionSkills[i].unlocked)
                {
                    Debug.Log("Cannot unlock skill");
                    return;
                }
            }

            if (!PlayerManager.instance.HaveEnoughMoney(skillCost))
                return;

            unlocked = true;
            skillImage.color = Color.white;
        }
        else
        {
            for(int i = 0;i<postpositionSkills.Length;i++)
            {
                if(postpositionSkills[i].unlocked)
                {
                    Debug.Log("Cannot lock skill");
                    return;
                }
            }

            PlayerManager.instance.currency += Mathf.FloorToInt(skillCost * 0.8f);
            unlocked = false;
            skillImage.color = lockedSkillColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.skillToolTip.ShowToolTip(skillDescription, skillName, skillCost);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ui.skillToolTip.HideToolTip();
    }

    public void LoadDate(GameData _data)
    {
        if (_data.skillTree.TryGetValue(skillName, out bool value))
        {
            unlocked = value;
        }
    }

    public void SaveDate(ref GameData _data)
    {
        if(_data.skillTree.TryGetValue(skillName,out bool value))
        {
            _data.skillTree.Remove(skillName);
            _data.skillTree.Add(skillName, unlocked);
        }
        else
            _data.skillTree.Add(skillName, unlocked);
    }
}
