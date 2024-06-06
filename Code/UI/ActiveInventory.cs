using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : Singleton<ActiveInventory>
{
    //initialize setting
    private int activeSlotIndex = 0;
    private PlayerControls playerControls;

    //initialize
    protected override void Awake()
    {
        base.Awake();

        playerControls = new PlayerControls();
    }

    //start setting
    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
    }

    //enable player controls
    private void OnEnable()
    {
        playerControls.Enable();
    }

    //equip start weapon while enter the game or revive
    public void EquipStartWeapon()
    {
        ToggleActiveHighlight(0);
    }

    //toggle to the current active slot
    private void ToggleActiveSlot(int value)
    {
        ToggleActiveHighlight(value - 1);
    }

    //toggle the highlight to current active slot
    private void ToggleActiveHighlight(int index)
    {
        activeSlotIndex = index;

        foreach (Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        this.transform.GetChild(index).GetChild(0).gameObject.SetActive(true);
        ChangeActiveWeapon();
    }

    //change the active weapon implement
    private void ChangeActiveWeapon()
    {
        if (ActiveWeapon.Instance.CurrentActiveWeapon != null)
        {
            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject);
        }

        Transform childTransform = transform.GetChild(activeSlotIndex);
        InventorySlot inventorySlot = childTransform.GetComponentInChildren<InventorySlot>();
        WeaponInfo weaponInfo = inventorySlot.GetWeaponInfo();
        GameObject weaponToSpawn = weaponInfo.weaponPrefab;

        if (weaponInfo == null)
        {
            ActiveWeapon.Instance.WeaponNull();
            return;
        }

        GameObject newWeapon = Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform);
        ActiveWeapon.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
    }
}
