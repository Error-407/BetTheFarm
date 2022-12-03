using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EatDrink : MonoBehaviour
{
    public int Apple;
    public int Drink;

    public TextMeshProUGUI textApple;
    public TextMeshProUGUI textDrink;
    public Slider sliderEat;
    public Slider sliderDrink;

    public MoneySystem moneySystem;
    public void Eat(int Take)
    {
        if (Take > 0)
        {
            Apple += Take;
        }
        else
        if (Apple + Take >= 0)
        {
            Apple += Take;
            sliderEat.value += 20;
        }
        textApple.text = Apple.ToString();
    }

    public void Drinking(int Take)
    {
        if (Take > 0)
        {
            Drink += Take;
        }
        else
        if (Drink + Take >= 0)
        {
            Drink += Take;
            sliderDrink.value += 20;
        }
        textDrink.text = Drink.ToString();
    }
}
