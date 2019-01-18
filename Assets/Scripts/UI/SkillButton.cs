using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

    public Image skillIcon;
    public Text skillName;
    int skillIndex;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            BattleManager.battleManager.SelectCharacterSkill(SkillIndex);
        });
    }
    public int SkillIndex
    {
        set { skillIndex = value; }
        get { return skillIndex; }
    }
    public void UpdateButton(ScriptableSkill skill)
    {
        skillIcon.sprite = skill.icon;
        skillName.text = skill.skillName;
    }


}
