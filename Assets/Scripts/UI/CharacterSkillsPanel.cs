using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkillsPanel : MonoBehaviour
{

    public SkillButton skillButtonTemplate;
    public List<SkillButton> skillButtons;

    public void Init()
    {
        skillButtons = new List<SkillButton>();
        skillButtonTemplate.gameObject.SetActive(false);
    }

    public void UpdateSkillMenu()
    {
        int skillIndex = 0;
        foreach (ScriptableSkill skill in BattleManager.CurrentCharacter.skills)
        {
            SkillButton newSkillButton = Instantiate(skillButtonTemplate);
            newSkillButton.transform.SetParent(transform);
            newSkillButton.transform.localScale = Vector3.one;
            newSkillButton.UpdateButton(skill);
            newSkillButton.gameObject.SetActive(true);
            newSkillButton.SkillIndex = skillIndex;
            skillButtons.Add(newSkillButton);
            //Debug.Log("Added " + newSkillButton.skillName.text);
            skillIndex++;
        }
    }
    public void RemoveCurrentSkillButtons()
    {
        foreach (SkillButton button in skillButtons)
        {
            //Debug.Log("Removing " + button.skillName.text);
            Destroy(button.gameObject);
        }
        skillButtons = new List<SkillButton>();
    }
}
