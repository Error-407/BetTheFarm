using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public bool Open;
    public Animator animator;
    public CameraMove came;
    public MoveMent moveMent;
    public GameObject backpack;
    public GameObject backpack2;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && backpack.activeInHierarchy == false && backpack2.activeInHierarchy == false)
        {
            if (Open == true)
            {
                moveMent.enabled = true;
                came.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Open = false;
                animator.SetBool("Open", false);
            }
            else
            {
                moveMent.enabled = false;
                came.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Open = true;
                animator.SetBool("Open", true);
            }
        }
    }
}
