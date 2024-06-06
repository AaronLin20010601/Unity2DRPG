using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class WeaponInfo : ScriptableObject
{
    //initialize setting
    public GameObject weaponPrefab;
    public float weaponCD;
    public int weaponDamage;
    public float weaponRange;
}
