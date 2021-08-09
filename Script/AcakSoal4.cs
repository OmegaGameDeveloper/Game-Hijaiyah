﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AcakSoal4 : MonoBehaviour
{
    //Soal
    public string[] soal;
    public string[] jawaban;
    public AudioClip[] audioClip, audioPendukung;
    public AudioSource audioSource;
    public Sprite[] karakters, teksPendukungs;
    public int pengecoh1acak, pengecoh2acak;

    public string apakahbenar;

    public int soalkeacak, soalsebelumnya, lokasisoal, balonacak1, balonacak2, balonacak3, saatini, totalbenar, totalsalah;
    public string jawabannya;

    public int skor, keacak1, keacak2, levelload;

    public int Rand1, Rand2, Rand3;
    public int panjang;
    public List<int> list1 = new List<int>();
    public List<int> list2 = new List<int>();
    public List<int> list3 = new List<int>();
    public List<int> list4 = new List<int>();
    public List<int> list5 = new List<int>();
    public List<string> soalnya, pengecohnya1, pengecohnya2 = new List<string>();
    public List<int> soalsaatini, pengecoh1, pengecoh2, pengecoh3, pengecoh4, audionya;
    public List<AudioClip> audioClips;

    public float timeAwal, timeSelanjutnya, timerStart, timerNow, timerSoal, timerSoalAwal, timeSelanjutnyaSalah, timeAwalSalah;
    public bool isCountDown, isStart, isCountDownSalah;
    //GameObject Reference
    public GameObject go1, go2, go3, goSelesai, goSalah, goHasil, goKurang, goKosong;
    //Ojek Reference
    public Animator animall;
    public Text teks1, teks2, teks3, teksTotal, teksTotalBenar, teksTotalSalah, teksStatus;
    public Image balon1, balon2, balon3, karakter, teksPendukung, bintang;
    public Slider sliderWaktu;

    //Database
    public string progressURL, setProgressURL;
    public string username;
    public string status;
    public bool suksesSimpan,soalMulai;
    //URL GET
    public GameObject gos2;
    public GetCommunicationWeb getCommunicationWeb;
    void Start()
    {
        gos2 = GameObject.FindGameObjectWithTag("RequestManager");
        getCommunicationWeb = gos2.GetComponent<GetCommunicationWeb>();
        username = getCommunicationWeb.username;
        saatini = 0;
        saatini = 0;
        audioClips = new List<AudioClip>(new AudioClip[panjang]);
        soalnya = new List<string>(new string[panjang]);
        soalsaatini = new List<int>(new int[panjang]);
        pengecohnya1 = new List<string>(new string[panjang]);
        pengecohnya2 = new List<string>(new string[panjang]);

        for (int j = 0; j < panjang; j++)
        {
            soalsaatini[j] = list1[j];
            pengecoh1[j] = list2[j];
            pengecoh2[j] = list3[j];
        }

        for (int k = 0; k < panjang; k++)
        {
            soalkeacak = soalsaatini[k];
            pengecoh1acak = pengecoh1[k];
            pengecoh2acak = pengecoh2[k];
            audioClips[k] = audioClip[soalkeacak];
            soalnya[k] = soal[soalkeacak];
            pengecohnya1[k] = soal[pengecoh1acak];
            pengecohnya2[k] = soal[pengecoh2acak];
        }
        GetHasil();
    }

    public void GetHasil()
    {
        StartCoroutine(GetProgress());
    }

    public void SetHasil()
    {
        StartCoroutine(SetProgress());
    }


    IEnumerator GetProgress()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);

        var download = UnityWebRequest.Post(progressURL, form);


        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError)
        {
            Debug.Log(download.error);
        }
        else
        {
            Debug.Log(download.downloadHandler.text);
            status = download.downloadHandler.text;
            Acak();
        }
    }
    IEnumerator SetProgress()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("status", status);
        var www = UnityWebRequest.Post(setProgressURL, form);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            suksesSimpan = false;
        }
        else
        {
            Debug.Log("Berhasil Menyimpan Data!");
            suksesSimpan = true;
        }
    }
   
    public void SelanjutnyaSalah()
    {
        soalMulai = false;
        isCountDown = true;
        goHasil.SetActive(true);
        skor = skor;
        int karaktermuncul = Random.Range(2, 3);
        karakter.sprite = karakters[karaktermuncul];
        audioSource.clip = audioPendukung[3];
        audioSource.Play();
        totalsalah += 1;
        teksPendukung.sprite = teksPendukungs[3];
    }

    public void CobaLagi(int loadLevel)
    {
        levelload = loadLevel;
        status = "belum";
        apakahbenar = "belum";
        SetHasil();
        if (suksesSimpan)
            isStart = true;
    }

    public void MuatLevel(int loadLevel)
    {
        SceneManager.LoadScene(loadLevel);
    }


    public void Jawab1()
    {
        jawabannya = go1.name;
        if (jawabannya == soalnya[saatini])
        {
            skor += 10;

            int karaktermuncul = Random.Range(0, 1);
            int audioteks = Random.Range(0, 2);

            karakter.sprite = karakters[karaktermuncul];
            audioSource.clip = audioPendukung[audioteks];
            audioSource.Play();
            teksPendukung.sprite = teksPendukungs[audioteks];
            isCountDown = true;
            totalbenar += 1;
        }
        else
        {
            skor = skor;
            soalMulai = false;
            int karaktermuncul = Random.Range(2, 3);
            karakter.sprite = karakters[karaktermuncul];
            audioSource.clip = audioPendukung[3];
            audioSource.Play();
            teksPendukung.sprite = teksPendukungs[3];
            isCountDownSalah = true;
            goHasil.SetActive(true);
        }
    }

    public void Jawab2()
    {
        jawabannya = go2.name;
        if (jawabannya == soalnya[saatini])
        {
            skor += 10;

            int karaktermuncul = Random.Range(0, 1);
            int audioteks = Random.Range(0, 2);

            karakter.sprite = karakters[karaktermuncul];
            audioSource.clip = audioPendukung[audioteks];
            audioSource.Play();
            teksPendukung.sprite = teksPendukungs[audioteks];
            isCountDown = true;
            totalbenar += 1;

        }
        else
        {
            skor = skor;
            soalMulai = false;
            int karaktermuncul = Random.Range(2, 3);
            karakter.sprite = karakters[karaktermuncul];
            audioSource.clip = audioPendukung[3];
            audioSource.Play();
            teksPendukung.sprite = teksPendukungs[3];
            isCountDownSalah = true;
            goHasil.SetActive(true);
        }
    }
    public void Jawab3()
    {
        jawabannya = go3.name;
        if (jawabannya == soalnya[saatini])
        {
            skor += 10;

            int karaktermuncul = Random.Range(0, 1);
            int audioteks = Random.Range(0, 2);

            karakter.sprite = karakters[karaktermuncul];
            audioSource.clip = audioPendukung[audioteks];
            audioSource.Play();
            teksPendukung.sprite = teksPendukungs[audioteks];
            isCountDown = true;
            totalbenar += 1;
        }
        else
        {
            skor = skor;
            soalMulai = false;
            int karaktermuncul = Random.Range(2, 3);
            karakter.sprite = karakters[karaktermuncul];
            audioSource.clip = audioPendukung[3];
            audioSource.Play();
            teksPendukung.sprite = teksPendukungs[3];
            isCountDownSalah = true;
            goHasil.SetActive(true);
        }
    }
    public void Mulai()
    {
        goHasil.SetActive(false);
        isCountDown = false;
        soalMulai = true;
        Acak();
    }

    public void MulaiSalah()
    {
        isCountDownSalah = false;
        goHasil.SetActive(false);
        soalMulai = true;
        Acak();
    }

    public void Acak()
    {
        animall.Play("All Kartu Spawn", -1, 0f);
        if (saatini != 14)
        {
            saatini += 1;
        }
        else
        {
            saatini = 0;
            saatini += 1;
        }
        if (saatini != 14 || status != "selesai")
        {
            lokasisoal = Random.Range(0, 2);
            if (lokasisoal == 0)
            {
                go1.name = soalnya[saatini];
                go2.name = pengecohnya1[saatini];
                go3.name = pengecohnya2[saatini];
                teks1.text = soalnya[saatini];
                teks2.text = pengecohnya1[saatini];
                teks3.text = pengecohnya2[saatini];
            }
            else if (lokasisoal == 1)
            {
                go1.name = pengecohnya1[saatini];
                go2.name = soalnya[saatini];
                go3.name = pengecohnya2[saatini];
                teks1.text = pengecohnya1[saatini];
                teks2.text = soalnya[saatini];
                teks3.text = pengecohnya2[saatini];

            }
            else if (lokasisoal == 2)
            {
                go1.name = pengecohnya2[saatini];
                go2.name = pengecohnya1[saatini];
                go3.name = soalnya[saatini];
                teks1.text = pengecohnya2[saatini];
                teks2.text = pengecohnya1[saatini];
                teks3.text = soalnya[saatini];
            }
            audioSource.clip = audioClips[saatini];
            audioSource.Play();
        }
    }


    // Update is called once per frame
    void Update()
    {
        teksStatus.text = status;
        teksTotalBenar.text = totalbenar.ToString();
        teksTotalSalah.text = totalsalah.ToString();
        teksTotal.text = "Total Soal : " + saatini.ToString();

        if (totalbenar == 14 || apakahbenar == "selesai" && !audioSource.isPlaying)
        {
            goSelesai.SetActive(true);
            status = "selesai";
            SetHasil();
        }
        else
        {
            goSelesai.SetActive(false);
            if ((totalsalah == 1 || totalsalah == 2 || totalsalah == 3 || totalsalah == 4) && (totalbenar == 13 || totalbenar == 12 || totalbenar == 11 || totalbenar == 10) && saatini == 14 && !audioSource.isPlaying)
            {
                saatini = 1;
                audioSource.volume = 0f;
                animall.enabled = false;
                goKurang.SetActive(true);
                status = "belum";
                SetHasil();
            }
            else
            {
                goKurang.SetActive(false);
            }
            if (totalsalah == 5 && !audioSource.isPlaying)
            {
                goSalah.SetActive(true);
                status = "belum";
                SetHasil();
            }
            else
            {
                goSalah.SetActive(false);
            }

        }

        if (!soalMulai)
        {
            timerSoal = timerSoalAwal;
        }
        else
        {
            timerSoal -= Time.deltaTime * Time.timeScale;
            sliderWaktu.value = timerSoal;
        }

        if (timerSoal < 0 && totalsalah < 5)
        {
            SelanjutnyaSalah();
        }

        if (!isCountDownSalah)
        {
            timeSelanjutnyaSalah = timeAwalSalah;
        }
        else
        {
            timeSelanjutnyaSalah -= Time.deltaTime * Time.timeScale;
        }

        if (timeSelanjutnyaSalah < 0)
        {
            totalsalah += 1;
            MulaiSalah();
        }

        if (!isStart)
        {
            timerNow = timerStart;
        }
        else
        {
            timerNow -= Time.deltaTime * Time.timeScale;
        }

        if (timerNow < 0)
        {
            MuatLevel(levelload);
        }

        if (isCountDown)
        {
            timeSelanjutnya -= Time.deltaTime * Time.timeScale;
            goHasil.SetActive(true);
        }
        else
        {
            timeSelanjutnya = timeAwal;
        }

        if (timeSelanjutnya < 0)
        {
            soalMulai = false;
            if (!audioSource.isPlaying)
            {
                Mulai();
            }
        }
        if (status == "belum")
        {
            apakahbenar = "belum";
        }
        else if (status == "selesai")
        {
            apakahbenar = "selesai";
        }
        else if (apakahbenar == "")
        {
            apakahbenar = "";
        }
    }
}
