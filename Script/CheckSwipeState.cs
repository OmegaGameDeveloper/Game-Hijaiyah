﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckSwipeState : MonoBehaviour
{
    public string jawabandia;
    public bool atas,bawah,tengah;
    public RectTransform rek;
    public Vector2 vecAtas,vecTengah,vecBawah;

    public void Atas()
    {
        if (atas)
        {

        }
        else if(tengah)
        {
            tengah = false;
            atas = true;
            jawabandia = "atas";
        }
        else if (bawah)
        {
            bawah = false;
            tengah = true;
            jawabandia = "tengah";
        }
    }

    public void Bawah()
    {
        if (atas)
        {
            atas = false;
            tengah = true;
            jawabandia = "tengah";

        }
        else if (tengah)
        {
            tengah = false;
            bawah = true;
            jawabandia = "bawah";

        }

        else if (bawah)
        {
            
        }
    }

    public void Check()
    {

    }

    public void Geraks()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        rek = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atas)
        {
            rek.anchoredPosition = vecAtas;
        }else if (tengah)
        {
            rek.anchoredPosition = vecTengah;
        }
        else if (bawah)
        {
            rek.anchoredPosition = vecBawah;
        }
    }
}
