using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

    public Image skillIcon;
    public Button button;
    public Text skillName;
    int skillIndex;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate
        {
            BattleManager.instance.SelectCharacterSkill(SkillIndex);
        });
    }
    public int SkillIndex
    {
        set { skillIndex = value; }
        get { return skillIndex; }
    }
    public void UpdateButton(ScriptableSkill skill, float characterMana)
    {
        skillIcon.sprite = skill.icon;
        skillName.text = skill.skillName;
        if (characterMana < skill.manaCost)
            button.interactable = false;
        else
            button.interactable = true;
    }
}
