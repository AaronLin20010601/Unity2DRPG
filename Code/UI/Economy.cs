using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : Singleton<Economy>
{
    //initialize setting
    private TMP_Text coinAmount;
    private int currentGold;
    const string COIN_AMOUNT_TEXT = "Gold Amount";

    //update the current coin amount on screen ui
    public void UpdateCurrentGold()
    {
        currentGold += 1;

        if (coinAmount == null)
        {
            coinAmount = GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
        }

        coinAmount.text = currentGold.ToString("D4");
    }
}
