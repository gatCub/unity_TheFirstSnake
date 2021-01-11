using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDF : MonoBehaviour
{
    public GameObject Food;
    public GameObject Dead;
    public RandDead ReDead = new RandDead();
    public RandFood ReFood = new RandFood();
    void Update()
    {
        if (Dead.transform.position == Food.transform.position)
            ReDead.AddNewDead();
        if (Food.transform.position == Dead.transform.position)
            ReFood.AddNewFood();
    }
}
