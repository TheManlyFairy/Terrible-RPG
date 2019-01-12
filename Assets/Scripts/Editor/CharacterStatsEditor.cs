using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CharacterStats))]
public class CharacterStatsEditor : Editor
{
    bool baseStats = true;
    bool bonusStats = true;
    bool totalStats = true;
    bool perLevelStatGrowth = false;

    public override void OnInspectorGUI()
    {
        CharacterStats stats = (CharacterStats)target;

        CharacterStats.partyLevel = EditorGUILayout.IntField("Party Level",CharacterStats.partyLevel);

        perLevelStatGrowth = EditorGUILayout.Foldout(perLevelStatGrowth, "Per Level Growth Stats");
        if (perLevelStatGrowth)
        {
            EditorGUI.indentLevel++;
            stats.maxHealth = EditorGUILayout.FloatField("Max Health Per Level", stats.maxHealth);
            stats.maxMana = EditorGUILayout.FloatField("Max Mana Per Level", stats.maxMana);
            stats.strength = EditorGUILayout.FloatField("Strength Per Level", stats.strength);
            stats.armor = EditorGUILayout.FloatField("Armor Per Level", stats.armor);
            stats.magic = EditorGUILayout.FloatField("Magic Per Level", stats.magic);
            stats.resistance = EditorGUILayout.FloatField("Resistance Per Level", stats.resistance);
            stats.agility = EditorGUILayout.FloatField("Agility Per Level", stats.agility);
            EditorGUI.indentLevel--;
        }

        baseStats = EditorGUILayout.Foldout(baseStats,"Base Stats",true);
        if (baseStats)
        {
            GUI.enabled = false;
            EditorGUI.indentLevel++;
            EditorGUILayout.FloatField("Base Health",stats.BaseHealth);
            EditorGUILayout.FloatField("Base Mana",stats.BaseMana);
            EditorGUILayout.FloatField("Base Strength",stats.BaseStrength );
            EditorGUILayout.FloatField("Base Armor",stats.BaseArmor);
            EditorGUILayout.FloatField("Base Magic",stats.BaseMagic);
            EditorGUILayout.FloatField("Base Resistance",stats.BaseResistance);
            EditorGUILayout.FloatField("Base Agility",stats.BaseAgility);
            EditorGUI.indentLevel--;
            GUI.enabled = true;
        }
        bonusStats = EditorGUILayout.Foldout(bonusStats,"Bonus Stats",true);
        if (bonusStats)
        {
            GUI.enabled = false;
            EditorGUI.indentLevel++;
            EditorGUILayout.FloatField("Bonus Health",stats.BonusHealth);
            EditorGUILayout.FloatField("Bonus Mana",stats.BonusMana);
            EditorGUILayout.FloatField("Bonus Strength",stats.BonusStrength);
            EditorGUILayout.FloatField("Bonus Armor",stats.BonusArmor);
            EditorGUILayout.FloatField("Bonus Magic",stats.BonusMagic);
            EditorGUILayout.FloatField("Bonus Resistance",stats.BonusResistance);
            EditorGUILayout.FloatField("Bonus Agility",stats.BonusAgility);
            EditorGUI.indentLevel--;
            GUI.enabled = true;
        }
        totalStats = EditorGUILayout.Foldout(totalStats,"Total Stats",true);
        if (totalStats)
        {
            GUI.enabled = false;
            EditorGUI.indentLevel++;
            EditorGUILayout.FloatField("Total Health",stats.TotalHealth);
            EditorGUILayout.FloatField("Current Health",stats.currentHealth);
            EditorGUILayout.FloatField("Total Mana",stats.TotalMana);
            EditorGUILayout.FloatField("Current Mana",stats.currentMana);
            EditorGUILayout.FloatField("Total Strength",stats.TotalStrength);
            EditorGUILayout.FloatField("Total Armor",stats.TotalArmor);
            EditorGUILayout.FloatField("Total Magic",stats.TotalMagic);
            EditorGUILayout.FloatField("Total Resistance",stats.TotalResistance);
            EditorGUILayout.FloatField("Total Agility",stats.TotalAgility);
            EditorGUI.indentLevel--;
            GUI.enabled = true;
        }
       

        EditorUtility.SetDirty(target);
    }
}
