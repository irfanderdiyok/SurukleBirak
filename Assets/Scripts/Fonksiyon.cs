using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fonksiyon : MonoBehaviour
{
    //!degiskenTuru == true string   false int
    public bool degiskenTuru = true;
    private Color mavi = new Color(100f / 255f, 200f / 255f, 250f / 255f);
    private Color sari = new Color(233f / 255f, 236f / 255f, 103f / 255f);

    public void degiskenTurDegistir()
    {
        degiskenTuru = !degiskenTuru;

        if (!degiskenTuru)
        {
            this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = mavi;
            this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = mavi;
            this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Image>().color = mavi;


            this.gameObject.transform.GetChild(0).GetChild(2).GetComponentInChildren<TMP_InputField>().contentType = TMP_InputField.ContentType.IntegerNumber;
        }
        else
        {
            this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = sari;
            this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = sari;
            this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Image>().color = sari;


            this.gameObject.transform.GetChild(0).GetChild(2).GetComponentInChildren<TMP_InputField>().contentType = TMP_InputField.ContentType.Standard;


            this.gameObject.transform.GetChild(0).GetChild(2).GetComponentInChildren<TMP_InputField>().lineType = TMP_InputField.LineType.MultiLineNewline;

        }

        this.gameObject.transform.GetChild(0).GetChild(2).GetComponentInChildren<TMP_InputField>().text = "";


    }





    public GameObject semboller;

    public GameObject semboltext;

    private void Start()
    {
        semboller = GameObject.Find("GameMaster");
        semboller = semboller.GetComponent<SembolReferans>().sembolReferanlari;
        if (this.gameObject.transform.parent.CompareTag("Kodyeri"))
        {
            Destroy(this.gameObject);
        }
    }
    public void YokEt()
    {
        Destroy(this.gameObject);
    }



    public void SembolDegis()
    {
        semboller.SetActive(true);
        semboller.GetComponent<SembolObjesi>().sembol = semboltext.GetComponent<TMPro.TextMeshProUGUI>();
    }





}
