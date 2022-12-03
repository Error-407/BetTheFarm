using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMassage : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Destroy(gameObject);
        }
    }
}
