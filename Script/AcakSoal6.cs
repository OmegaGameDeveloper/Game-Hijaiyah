using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcakSoal6 : MonoBehaviour
{
    public List<Sprite> huruf;
    public Slider slid;
    public int[] list1, list2, list3;

    public string[] jawaban;

    public Sprite[] karakters, teksPendukungs;
    public Image karakter, teksPendukung;

    public Image[] lokasihuruf;

    public Text teksSoal;

    public float soalCountdown, soalCountdownBegin;
    public int skor, soalsaaatini;

    public bool isCountdownSoal, isCountdown, isCountDownSalah;

    public GameObject gos1, gos2, go3, goKosong, canvas1, canvas2, goSelesai, goKurang, goSalah, goHasil;

    public CheckSwipeState ofs;


    // Start is called before the first frame update
    void Start()
    {
        soalCountdown = soalCountdownBegin;
        Acak();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountdownSoal)
        {
            soalCountdown -= Time.deltaTime * Time.timeScale;
            slid.value = soalCountdown;
        }
        else
        {
            soalCountdown = soalCountdownBegin;
        }
        if (soalCountdown < 0)
        {
            CekJawaban();
        }


    }

    public void Benar()
    {

        int karaktermuncul = Random.Range(0, 1);
        int audioteks = Random.Range(0, 2);

        karakter.sprite = karakters[karaktermuncul];
        /*audioSource.clip = audioPendukung[audioteks];
        audioSource.Play();*/
        teksPendukung.sprite = teksPendukungs[audioteks];
        isCountdown = true;
        goHasil.SetActive(true);
        Acak();
    }

    public void Salah()
    {
        skor = skor;
        int karaktermuncul = Random.Range(2, 3);
        karakter.sprite = karakters[karaktermuncul];
        /*audioSource.clip = audioPendukung[3];
        audioSource.Play();*/
        teksPendukung.sprite = teksPendukungs[3];
        isCountDownSalah = true;
        goHasil.SetActive(true);
        Acak();
    }

    public void CekJawaban()
    {
        if (soalsaaatini != 0)
        {
            soalsaaatini += 1;
        }
        else
        {
            soalsaaatini = 0;
        }
        isCountdownSoal = false;
        
        if (jawaban[soalsaaatini] == ofs.jawabandia)
        {
            Benar();
        }
        else
        {
            Salah();
        }
    }

    public void Acak()
    {
        int list1saatini = list1[soalsaaatini];
        int list2saatini = list2[soalsaaatini];
        int list3saatini = list3[soalsaaatini];
        teksSoal.text = huruf[list1saatini].name;
        int lokasisoal = Random.Range(0, 3);

        if (lokasisoal == 0)
        {
            lokasihuruf[0].sprite = huruf[list1saatini];
            lokasihuruf[1].sprite = huruf[list2saatini];
            lokasihuruf[2].sprite = huruf[list3saatini];
            jawaban[soalsaaatini] = "atas";
        }
        else if (lokasisoal == 1)
        {
            lokasihuruf[1].sprite = huruf[list2saatini];
            lokasihuruf[0].sprite = huruf[list1saatini];
            lokasihuruf[2].sprite = huruf[list3saatini];
            jawaban[soalsaaatini] = "tengah";
        }
        else if (lokasisoal == 2)
        {
            lokasihuruf[2].sprite = huruf[list3saatini];
            lokasihuruf[1].sprite = huruf[list2saatini];
            lokasihuruf[0].sprite = huruf[list1saatini];
            jawaban[soalsaaatini] = "bawah";
        }
    }
}
