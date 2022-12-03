using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountChickens : MonoBehaviour
{
    public int Egges;
    public GameObject panel;

    public TMP_InputField slider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Good();
        }
    }
    private void Start()
    {
        audio1.Stop();
        audio2.Stop();
    }
    public bool Again;
    public MoneySystem money;
    public AudioSource audio1;
    public AudioSource audio2;
    public void Good()
    {
        if (Again == false)
        {
            if (slider.text == Egges.ToString())
            {
                audio1.Play();
                Again = true;
                money.ChangeMoney(30);
            } else
            {
                audio2.Play();
            }
            came.enabled = true;
            panel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public CameraMove came;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            slider.text = "";
            came.enabled = false;
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            came.enabled = true;
            panel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
