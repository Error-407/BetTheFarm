using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    public int MoneyAmount;
    public TextMeshProUGUI textMeshProUGUI;

    public void ChangeMoney(int Amount)
    {
        if (MoneyAmount + Amount >= 0 && Amount < 0 || Amount > 0)
        {
            MoneyAmount += Amount;
            textMeshProUGUI.text = MoneyAmount.ToString() + "$";
        } else
        {
            print("You Got No Money :(");
        }
    }
}
