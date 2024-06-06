using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    //initialize setting
    [SerializeField] private WeaponInfo weaponInfo;

    //get the info of weapon
    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
