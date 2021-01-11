using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject Back1;
    public GameObject Back2;
    public GameObject Back3;
    public GameObject Back4;
    public GameObject Back5;
    public GameObject Back6;
    public int k;
    public float step;
    Color _color;
    Color Next_color;


    void Update()
    {
        switch(k)
        {
            case 1: StartK(Back1, Back2); break;
            case 2: StartK(Back2, Back3); break;
            case 3: StartK(Back3, Back4); break;
            case 4: StartK(Back4, Back5); break;
            case 5: StartK(Back5, Back6);  break    ;
            case 6: StartK(Back6, Back1); break;
            default: Debug.LogError("Ошибка фона"); break;
        }

    }

    public void StartK(GameObject a, GameObject NextBack)
    {

        _color = a.GetComponent<Renderer>().material.color;
        Next_color = NextBack.GetComponent<Renderer>().material.color;
        if (_color.a > 0f)
        {
            _color.a -= step;
            Next_color.a += step;
            a.GetComponent<Renderer>().material.color = _color;
            NextBack.GetComponent<Renderer>().material.color = Next_color;
        }
        else
        {
            k++;
            if (k > 6)
                k = 1;
        }
        
    }

}
