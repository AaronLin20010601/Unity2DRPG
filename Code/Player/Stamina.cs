using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : Singleton<Stamina>
{
    //initialize setting
    public int CurrentStamina { get; private set; }
    [SerializeField] private Sprite fullStamina, emptyStamina;
    [SerializeField] private int timeBetweenStaminaRefresh = 3;

    private Transform staminaContainer;
    private int startingStamina = 3;
    private int maxStamina;
    const string STAMINA_CONTAINER_TEXT = "Stamina Container";

    //initialize
    protected override void Awake()
    {
        base.Awake();

        maxStamina = startingStamina;
        CurrentStamina = startingStamina;
    }

    //start setting
    private void Start()
    {
        staminaContainer = GameObject.Find(STAMINA_CONTAINER_TEXT).transform;
    }

    //reduce stamina after using it
    public void UseStamina()
    {
        CurrentStamina--;
        UpdateStaminaImage();
    }

    //refresh stamina after picking up
    public void RefreshStamina()
    {
        if (CurrentStamina < maxStamina)
        {
            CurrentStamina++;
        }

        UpdateStaminaImage();
    }

    //routine of refresh stamina
    private IEnumerator RefreshStaminaRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenStaminaRefresh);
            RefreshStamina();
        }
    }

    //update the show image of stamina bar
    private void UpdateStaminaImage()
    {
        for (int i = 0; i < maxStamina; i++)
        {
            if (i <= CurrentStamina - 1)
            {
                staminaContainer.GetChild(i).GetComponent<Image>().sprite = fullStamina;
            }
            else
            {
                staminaContainer.GetChild(i).GetComponent<Image>().sprite = emptyStamina;
            }
        }

        if (CurrentStamina < maxStamina)
        {
            StopAllCoroutines();
            StartCoroutine(RefreshStaminaRoutine());
        }
    }
}
