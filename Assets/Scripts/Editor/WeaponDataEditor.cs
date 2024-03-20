using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Jobs;

[CustomEditor(typeof(WeaponData))]
public class WeaponDataEditor : Editor
{
    WeaponData weaponData;
    string[] weaponSubtypes;
    int selectedWeaponSubtype;

    void OnEnable()
    {
        weaponData = (WeaponData)target;

        System.Type baseType = typeof(Weapon);
        List<System.Type> subTypes = System.AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => baseType.IsAssignableFrom(p) && p != baseType)
            .ToList();

        List<string> subTypesString = subTypes.Select(t => t.Name).ToList();
        subTypesString.Insert(0, "None");
        weaponSubtypes = subTypesString.ToArray();

        selectedWeaponSubtype = System.Math.Max(0, System.Array.IndexOf(weaponSubtypes, weaponData.behaviour));
    }

    public override void OnInspectorGUI()
    {
        selectedWeaponSubtype = EditorGUILayout.Popup("Behaviour", System.Math.Max(0, selectedWeaponSubtype), weaponSubtypes);

        if(selectedWeaponSubtype > 0) {
            weaponData.behaviour = weaponSubtypes[selectedWeaponSubtype].ToString();
            EditorUtility.SetDirty(weaponData);
            DrawDefaultInspector();
        }
    }
}