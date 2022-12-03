using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    CharacterController characterController;
    public float m_Speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    Rigidbody m_Rigidbody;
    public AudioSource audio1;
    public AudioSource NoneStop;
    void Start()
    {
        NoneStop.Stop();
        characterController = GetComponent<CharacterController>();
        m_Rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public GameObject game;
    public int minimap;
    public bool Shoot;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Shoot == true)
        {
            audio1.Play();
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            NoneStop.Play();
            minimap++;
            if (minimap > 1)
            {
                minimap = 0;
            }
            if (minimap == 0)
            {
                game.SetActive(false);
                Shoot = false;
            }
            if (minimap == 1)
            {
                game.SetActive(true);
                Shoot = true;
            }
            audio1.Stop();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            NoneStop.Play();
            minimap--;
            if (minimap < 0)
            {
                minimap = 1;
            }
            if (minimap == 0)
            {
                game.SetActive(false);
                Shoot = false;
            }
            if (minimap == 1)
            {
                game.SetActive(true);
                Shoot = true;
            }
            audio1.Stop();
        }

        if (Input.GetKey(KeyCode.W))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.forward * m_Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = -transform.forward * m_Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.right * m_Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = -transform.right * m_Speed;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            m_Rigidbody.velocity = transform.forward * 0;

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            m_Rigidbody.velocity = transform.right * 0;

        float x = 3 * Input.GetAxis("Mouse X");
        transform.Rotate(0, x,0);
    }
}
