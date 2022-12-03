using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{
    public void Change(Material material)
    {
        RenderSettings.skybox = material;
    }
}
