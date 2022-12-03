using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayCount : MonoBehaviour
{
    public Material light;
    public int Day;
    public int Seconds = 240;
    public int Hour;
    public TextMeshProUGUI text;
    public GameObject End;
    public GameObject EndCanvas;
    public GameObject AudioStop1;
    public GameObject AudioStop2;
    public GameObject AudioStop3;

    void Start()
    {
        Chickens = GameObject.FindGameObjectsWithTag("Chicken");
        for (int i = 0; i < Chickens.Length; i++)
        {
            Destroy(Chickens[i]);
        }
        Chickens = null;
        Chickens = GameObject.FindGameObjectsWithTag("Pig");
        for (int i = 0; i < Chickens.Length; i++)
        {
            Destroy(Chickens[i]);
        }
        Chickens = null;
        Chickens = GameObject.FindGameObjectsWithTag("Sheep");
        for (int i = 0; i < Chickens.Length; i++)
        {
            Destroy(Chickens[i]);
        }
        Chickens = GameObject.FindGameObjectsWithTag("Wolf");
        for (int i = 0; i < Chickens.Length; i++)
        {
            Destroy(Chickens[i]);
        }
        Chickens = null;
        for (int i = 0; i < grass.Length; i++)
        {
            if (grass[i].TOF == true)
            {
                grass[i].Changed();
                money.ChangeMoney(5);
            }
        }
        Spawn.Work();
        PigSpawn.Work();
        for (int i = 0; i < count.Length; i++)
        {
            count[i].Egges = 0;
            count[i].Again = false;
        }
        for (int i = 0; i < egg.Length; i++)
        {
            egg[i].Work();
        }
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }
    public MoneySystem money;
    public GrassChange[] grass;
    int d;
    public GameObject[] Chickens;
    public GameObject[] SP;
    public Transform Max;
    public Transform Min;
    public bool CanSleep;
    public void Stop()
    {
        Destroy(this);
    }
    IEnumerator ExampleCoroutine()
    {
        if (Day == 100 && Seconds % 360 == 0 && Hour == 0)
        {
            End.SetActive(true);
            EndCanvas.SetActive(false);
            AudioStop1.SetActive(false);
            AudioStop2.SetActive(false);
            AudioStop3.SetActive(false);
            Destroy(this);
        }
        if (Seconds % 360 == 0 && Seconds != 0)
        {
            GameObject D = Instantiate(SP[Random.Range(0, SP.Length)]);
            D.transform.position = new Vector3(
                Random.Range(Min.transform.position.x, Max.transform.position.x),
                Random.Range(Min.transform.position.y, Max.transform.position.y),
                Random.Range(Min.transform.position.z, Max.transform.position.z)
            );
            Day++;
            Hour = -1;
        }
        yield return new WaitForSeconds(1);
        Seconds++;

        StartCoroutine(ExampleCoroutine());
        if (Seconds % 15 == 0)
        {
            Hour++;
            text.text = ("Hour : " + Hour + "\nDay : " + Day);
        }
        if (CanSleep == true)
            sliderSleep.value -= 0.4f;
        else
            sliderSleep.value += 0.4f;
        sliderEat.value -= 0.3f;
        sliderDrink.value -= 0.35f;

        if (sliderDrink.value <= 0)
        {
            sliderHealth.value -= 0.3f;
        }
        if (sliderEat.value <= 0)
        {
            sliderHealth.value -= 0.3f;
        }
        if (sliderEat.value > 0 && sliderDrink.value > 0)
        {
            sliderHealth.value += 0.3f;
        }
        if (Hour % 12 == 0 && Seconds % 180 == 0)
        {
            print("d");
            Chickens = GameObject.FindGameObjectsWithTag("Chicken");
            for (int i = 0; i < Chickens.Length; i++)
            {
                Destroy(Chickens[i]);
            }
            Chickens= null;
            Chickens = GameObject.FindGameObjectsWithTag("Pig");
            for (int i = 0; i < Chickens.Length; i++)
            {
                Destroy(Chickens[i]);
            }
            Chickens = null;
            Chickens = GameObject.FindGameObjectsWithTag("Sheep");
            for (int i = 0; i < Chickens.Length; i++)
            {
                Destroy(Chickens[i]);
            }
            Chickens = GameObject.FindGameObjectsWithTag("Wolf");
            for (int i = 0; i < Chickens.Length; i++)
            {
                Destroy(Chickens[i]);
            }
            Chickens = null;
            for (int i = 0; i < grass.Length; i++)
            {
                if (grass[i].TOF == true)
                {
                    grass[i].Changed();
                    money.ChangeMoney(5);
                }
            }
            Spawn.Work();
            PigSpawn.Work();
            for (int i = 0; i < count.Length; i++)
            {
                count[i].Egges = 0;
                count[i].Again = false;
            }
            for (int i = 0; i < egg.Length; i++)
            {
                egg[i].Work();
            }
        }
    }
    public Egg[] egg;
    public CountChickens[] count;
    public PigSpawn PigSpawn;
    public SheepCage Spawn;
    public Slider sliderSleep;
    public Slider sliderEat;
    public Slider sliderDrink;
    public Slider sliderHealth;
}
