using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decrease8 : MonoBehaviour
{
    public GameObject b;
    void Start()
    {
        b.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
    }
}
