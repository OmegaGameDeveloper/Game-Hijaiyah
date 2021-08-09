using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GetAllAnswer3 : MonoBehaviour
{
    public List<Drag> drax;
    public GameObject[] goDrag;
    public Drag[] dras;
    public List<string> jawaban1,jawaban2;
    public string jawabannya;
    public string jawabansesungguhnya;
    public string jawabandibalik;
    public int jumlahjawaban,count1,count2,totalcount;
    public bool benar, salah;
    public AcakSoal3 acs3;

    // Start is called before the first frame update
    public void GetJawaban()
    {
        drax = new List<Drag>();
        goDrag = GameObject.FindGameObjectsWithTag("Objek3");
        int panjang = goDrag.Length;
        for (int l = 0; l < panjang; l++)
        {
            dras[l] = goDrag[l].GetComponent<Drag>();
            jawaban1[l] = dras[l].jawaban1;
            jawaban2[l] = dras[l].jawaban2;
        }
        totalcount = count1 + count2;
        var result1 = string.Join(", ", jawaban1);
        var jaw1 = result1.Replace(",", "");
        var result2 = string.Join(",", jawaban2);
        var jaw2 = result2.Replace(",", "");
        if (jumlahjawaban == 2)
        {
            jawabannya = jaw2 + jaw1;
            string balikjawaban = jaw1 + jaw2;
            balikjawaban = balikjawaban.Replace(" ", string.Empty);
            jawabannya = jawabannya.Replace(" ", string.Empty);

            if (jawabansesungguhnya == jawabannya || jawabandibalik == jawabannya || jawabansesungguhnya == balikjawaban || jawabandibalik == balikjawaban)
            {
                dras[0].selesai = true;
                dras[1].selesai = true;
                dras[2].selesai = true;
                dras[3].selesai = true;
                dras[4].selesai = true;
                dras[5].selesai = true;
                jawaban1[0] = "";
                jawaban1[1] = "";
                jawaban1[2] = "";
                jawaban1[3] = "";
                jawaban1[4] = "";
                jawaban1[5] = "";
                jawaban2[0] = "";
                jawaban2[1] = "";
                jawaban2[2] = "";
                jawaban2[3] = "";
                jawaban2[4] = "";
                jawaban2[5] = "";
                jawabannya = "";
                acs3.Benar();
                jumlahjawaban = 0;

            }
            else if(jawabansesungguhnya !=jawabannya|| jawabandibalik != jawabannya || jawabansesungguhnya != balikjawaban || jawabandibalik != balikjawaban)
            {
                dras[0].selesai = true;
                dras[1].selesai = true;
                dras[2].selesai = true;
                dras[3].selesai = true;
                dras[4].selesai = true;
                dras[5].selesai = true;
                jawaban1[0] = "";
                jawaban1[1] = "";
                jawaban1[2] = "";
                jawaban1[3] = "";
                jawaban1[4] = "";
                jawaban1[5] = "";
                jawaban2[0] = "";
                jawaban2[1] = "";
                jawaban2[2] = "";
                jawaban2[3] = "";
                jawaban2[4] = "";
                jawaban2[5] = "";
                jawabannya = "";
                acs3.Salah();
                jumlahjawaban = 0;
            }
        }
        else if(jumlahjawaban == 1)
        {
            for (int l = 0; l < panjang; l++)
            {
                if (dras[l].name=="Tanda Baca Atas"||dras[l].name=="Tanda Baca Bawah")
                {
                    dras[l].dragable = true;
                }
            }
        }
        else if(jumlahjawaban ==0)
        {
            for (int l = 0; l < panjang; l++)
            {
                if (dras[l].name == "Tanda Baca Atas" || dras[l].name == "Tanda Baca Bawah")
                {
                    dras[l].dragable = false;
                }
            }

            jawabannya = "";
        }
    }


    // Update is called once per frame
    void Update()
    {
        int panjang = dras.Length;
        if (jumlahjawaban == 0)
        {
            for (int l = 0; l < panjang; l++)
            {
                if (dras[l].name == "Tanda Baca Atas" || dras[l].name == "Tanda Baca Bawah")
                {
                    dras[l].dragable = false;
                }
            }
        }
    }
}
