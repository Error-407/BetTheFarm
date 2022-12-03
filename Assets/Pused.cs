using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pused : MonoBehaviour
{
    public CameraMove came;
    public MoveMent moveMent;
    public GameObject Canvas;
    public AudioSource audioS;
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.Stop();
    }
    public void StopGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public GameObject Player;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveMent.enabled = false;
            came.enabled = false;
            Canvas.SetActive(true);
            collision.transform.position = new Vector3(transform.position.x, collision.transform.position.y - 1, transform.position.z);
            collision.transform.eulerAngles = new Vector3(0, 0, 0);
            came.gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
            StopGame();
        }
    }
    public void Continue()
    {
        came.gameObject.transform.eulerAngles = new Vector3(came.transform.eulerAngles.x, Player.transform.eulerAngles.y, came.transform.eulerAngles.z); ;
        Player.transform.position = new Vector3(transform.position.x + 3, 0.4f, transform.position.z + 3);
        moveMent.enabled = true;
        came.enabled = true;
        Canvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Flush()
    {
        audioS.Play();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Continue();
        }
    }
}
