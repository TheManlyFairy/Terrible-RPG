using UnityEngine;
using UnityEditor;
using Utility;

[CustomEditor(typeof(ScriptableStatus))]
public class ScriptableStatusEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ScriptableStatus status = (ScriptableStatus)target;

        status.statusType = (StatusType)EditorGUILayout.EnumPopup("Status Type", status.statusType);
        status.effectName = EditorGUILayout.TextField("Effect Name", status.effectName);

        switch(status.statusType)
        {
            case StatusType.heal: ShowHealEditor(status); break;
            case StatusType.buff: ShowBuffEditor(status); break;
            case StatusType.debuff: ShowDebuffEditor(status); break;
            case StatusType.burn: ShowBurnEditor(status); break;
            case StatusType.poison: ShowPoisonEditor(status); break;
        }
    }

    void ShowHealEditor(ScriptableStatus status)
    {
        status.instantEffectMultiplier = EditorGUILayout.FloatField("Healing Multiply Factor", status.instantEffectMultiplier);
    }
    void ShowBurnEditor(ScriptableStatus status)
    {
        status.duration = EditorGUILayout.IntField("Duration", status.duration);
        status.instantEffectMultiplier = EditorGUILayout.FloatField("Armor Reduction Factor", status.instantEffectMultiplier);
        status.perTurnEffectMultiplier = EditorGUILayout.FloatField("Burn Damage Factor", status.perTurnEffectMultiplier);
    }
    void ShowPoisonEditor(ScriptableStatus status)
    {
        status.duration = EditorGUILayout.IntField("Duration", status.duration);
        status.instantEffectMultiplier = EditorGUILayout.FloatField("Resistance Reduction Factor", status.instantEffectMultiplier);
        status.perTurnEffectMultiplier = EditorGUILayout.FloatField("Max Health Damage Per Turn", status.perTurnEffectMultiplier);
    }
    void ShowBuffEditor(ScriptableStatus status)
    {
        status.duration = EditorGUILayout.IntField("Duration", status.duration);
        status.actorStat = (AffectedStat)EditorGUILayout.EnumPopup("Actor Stat Buff Is Based From", status.actorStat);
        status.targetStat = (AffectedStat)EditorGUILayout.EnumPopup("Target Stat To Buff", status.targetStat);
        status.instantEffectMultiplier = EditorGUILayout.FloatField("Buff Factor", status.instantEffectMultiplier);
    }
    void ShowDebuffEditor(ScriptableStatus status)
    {
        status.duration = EditorGUILayout.IntField("Duration", status.duration);
        status.targetStat = (AffectedStat)EditorGUILayout.EnumPopup("Stat To Debuff", status.targetStat);
        status.instantEffectMultiplier = EditorGUILayout.FloatField("Debuff Factor", status.instantEffectMultiplier);
    }
}
