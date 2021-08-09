using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour
{
    public GetAllAnswer3 gta3;
    public int jumlahjawaban;
    public string jawaban1s,jawaban2s,jawaban3s;
    public bool jawaban1, jawaban2, jawaban3;

    public void Start()
    {
       gta3.jumlahjawaban = 0;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == "PlaceHolder1")
        {
            if (other.gameObject.name == "Tanda Baca Atas")
                other.gameObject.GetComponent<Drag>().masuk = true;
            jawaban1s = other.gameObject.name;
            gta3.jumlahjawaban += 1;


        }
        else if (gameObject.name == "PlaceHolder2")
        {
            if (other.gameObject.name != "Tanda Baca Atas" || other.gameObject.name != "Tanda Baca Bawah")
                other.gameObject.GetComponent<Drag>().masuk = true;

            jawaban2s = other.gameObject.name;
            gta3.jumlahjawaban += 1;

        }
        else if (gameObject.name == "PlaceHolder3")
        {
            if (other.gameObject.name == "Tanda Baca Bawah")
                other.gameObject.GetComponent<Drag>().masuk = true;

            jawaban3s = other.gameObject.name;
            gta3.jumlahjawaban += 1;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.name == "PlaceHolder1")
        {
            if(other.gameObject.name=="Tanda Baca Atas")
            other.gameObject.GetComponent<Drag>().masuk = true;
            jawaban1s = other.gameObject.name;
            
        }
        else if (gameObject.name == "PlaceHolder2")
        {
            if(other.gameObject.name!="Tanda Baca Atas" || other.gameObject.name !="Tanda Baca Bawah")
            other.gameObject.GetComponent<Drag>().masuk = true;

            jawaban2s = other.gameObject.name;

        }else if (gameObject.name == "PlaceHolder3")
        {
            if(other.gameObject.name=="Tanda Baca Bawah")
            other.gameObject.GetComponent<Drag>().masuk = true;

            jawaban3s = other.gameObject.name;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {    
        if (gameObject.name == "PlaceHolder1")
        {
            other.gameObject.GetComponent<Drag>().masuk = false;

            jawaban1s = "";
            gta3.jumlahjawaban -= 1;
        }
        else if (gameObject.name == "PlaceHolder2")
        {
            other.gameObject.GetComponent<Drag>().masuk = false;

            jawaban2s = "";
            gta3.jumlahjawaban -= 1;

        }
        else if (gameObject.name == "PlaceHolder3")
        {
            other.gameObject.GetComponent<Drag>().masuk = false;

            jawaban3s = "";
            gta3.jumlahjawaban -= 1;
        }
    }

}
