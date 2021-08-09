using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Drag : MonoBehaviour
{

    public int jumlahjawaban;
    public RectTransform rt, rt2;
    public Vector3 trans;
    public bool selesai,masuk,dragable;
    public string jawaban1, jawaban2;
    public Animator animat;
    public GetAllAnswer3 gta3;
    BoxCollider bocol;


    /*    public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData) 
        {
            transform.localPosition = Vector3.zero;
        }*/

    public Canvas parentCanvas;
    public RawImage mouseCursor;


    public void MulaiDrag()
    {
        if (gameObject.name == "Tanda Baca Atas" || gameObject.name == "Tanda Baca Bawah")
        {
            dragable = false;
            animat.enabled = false;
        }
        else
        {
            dragable = true;
            animat.enabled = false;
        }

    }

    public void Dragging()
    {
        if (dragable)
        {
            Vector2 movePos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentCanvas.transform as RectTransform,
                Input.mousePosition, parentCanvas.worldCamera,
                out movePos);

            Vector3 mousePos = parentCanvas.transform.TransformPoint(movePos);

            //Set fake mouse Cursor
            //mouseCursor.transform.position = mousePos;

            //Move the Object/Panel
            transform.position = mousePos;

            /*  animat.enabled = false;
              rt.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

              rt.transform.position = new Vector3(rt.transform.position.x, rt.transform.position.y, 0f);*/
        }
    }

    public void EndDrags()
    {
        dragable = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        rt2 = gameObject.GetComponent<RectTransform>();
        animat = gameObject.GetComponent<Animator>();
        trans = rt.transform.position;
        gta3 = GameObject.FindGameObjectWithTag("AnswerManager").GetComponent<GetAllAnswer3>();
        jumlahjawaban = 0;
        bocol = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (masuk)
        {
            if (gameObject.name == "Tanda Baca Atas")
            {
                jawaban1 = gameObject.GetComponentInChildren<Text>().text;
            }
            else if (gameObject.name == "Tanda Baca Tengah")
            {
                jawaban1 = gameObject.GetComponentInChildren<Text>().text;
            }
            else if (gameObject.name == "Tanda Baca Bawah")
            {
                jawaban1 = gameObject.GetComponentInChildren<Text>().text;
            }
            else if (gameObject.name == "Huruf Atas")
            {
                jawaban2 = gameObject.GetComponentInChildren<Text>().text;
            }
            else if (gameObject.name == "Huruf Tengah")
            {
                jawaban2 = gameObject.GetComponentInChildren<Text>().text;
            }
            else if (gameObject.name == "Huruf Bawah")
            {
                jawaban2 = gameObject.GetComponentInChildren<Text>().text;
            }
            gta3.GetJawaban();
        }
        else
        {
            if (gameObject.name == "Tanda Baca Atas")
            {
                jawaban1 = "";
            }
            else if (gameObject.name == "Tanda Baca Tengah")
            {
                jawaban1 = "";
            }
            else if (gameObject.name == "Tanda Baca Bawah")
            {
                jawaban1 = "";
            }
            else if (gameObject.name == "Huruf Atas")
            {
                jawaban2 = "";
            }
            else if (gameObject.name == "Huruf Tengah")
            {
                jawaban2 = "";
            }
            else if (gameObject.name == "Huruf Bawah")
            {
                jawaban2 = "";
            }
        }

        if (selesai)
        {
            //bocol.enabled = false;
            rt.transform.position = trans;
            animat.enabled = true;
            animat.Play(0);
            selesai = false;
            dragable = false;
            masuk = false;
        }
        else
        {
            //bocol.enabled = true;

        }
    }
}
