using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAuodio : MonoBehaviour
{
    public AudioSource audioStart;

    private void Start()
    {
        audioStart.Play();
    }
}
