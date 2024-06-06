using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    //initialize setting
    [SerializeField] private GameObject inventoryUI;
    private KeyCode showInventory = KeyCode.F;

    //show or hide inventory interface
    private void Update()
    {
        if (Input.GetKeyUp(showInventory))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}
