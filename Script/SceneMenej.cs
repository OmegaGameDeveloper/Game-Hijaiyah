using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenej : MonoBehaviour
{

    public int levelLoad;
    public GameObject gos1, gos2;

    public void BukaHalamanUtama(string url)
    {
        Application.OpenURL(url);
    }

    public void MuatLevel(int loadLevel)
    {
        SceneManager.LoadScene(loadLevel);
    }

    public void Keluar()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        gos1 = GameObject.FindGameObjectWithTag("WebManager");
        gos2 = GameObject.FindGameObjectWithTag("RequestManager");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
