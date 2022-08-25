using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject npc;
    public Light light;
    public void No()
    {
        npc.SetActive(false);
    }
    public void Yes()
    {
        light.intensity = 10f;
    }
}
