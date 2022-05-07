using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;





public class GameMaster : MonoBehaviour
{
    public TextMeshProUGUI sonuc;



    public GameObject kod;




    List<DegiskenOlusturma> degiskenler = new List<DegiskenOlusturma>();

    bool sifirla = true;


    public void Derle(GameObject kod)
    {
       
         sonuc.text="";
        foreach (Transform kodObjesi in kod.transform)
        {

            if (kodObjesi.CompareTag("print"))
            {

                yazFonksiyon(kodObjesi.gameObject);
            }
            if (kodObjesi.CompareTag("degisken"))
            {
                degiskenFonksiyon(kodObjesi.gameObject);
            }
            if (kodObjesi.CompareTag("if"))
            {
                kosulFonksiyon(kodObjesi.gameObject);
            }
            if (kodObjesi.CompareTag("dongu"))
            {
                donguFonksiyon(kodObjesi.gameObject);
            }
        }

    }




     public void Derlex(GameObject kod)
    {
       
        foreach (Transform kodObjesi in kod.transform)
        {

            if (kodObjesi.CompareTag("print"))
            {

                yazFonksiyon(kodObjesi.gameObject);
            }
            if (kodObjesi.CompareTag("degisken"))
            {
                degiskenFonksiyon(kodObjesi.gameObject);
            }
            if (kodObjesi.CompareTag("if"))
            {
                kosulFonksiyon(kodObjesi.gameObject);
            }
            if (kodObjesi.CompareTag("dongu"))
            {
                donguFonksiyon(kodObjesi.gameObject);
            }
        }

    }

    public void yazFonksiyon(GameObject metin)
    {
        sonuc.text = sonuc.text + metin.GetComponentInChildren<TMP_InputField>().text + " ";
    }

    public void degiskenFonksiyon(GameObject veri)
    {

        DegiskenOlusturma yeniDegisken = new DegiskenOlusturma();
        yeniDegisken.degiskenAdi = veri.transform.GetChild(0).GetComponentInChildren<TMP_InputField>().text;
        yeniDegisken.degiskenDegeri = veri.transform.GetChild(1).GetComponentInChildren<TMP_InputField>().text;

        degiskenler.Add(yeniDegisken);

        // sonuc.text += gameObject.transform.GetChild(0).GetComponentInChildren<TMP_InputField>().text + " = ";
        // sonuc.text += gameObject.transform.GetChild(1).GetComponentInChildren<TMP_InputField>().text;

        // foreach (DegiskenOlusturma isim in degiskenler)
        // {
        //     Debug.Log(isim.degiskenAdi);
        //     Debug.Log(isim.degiskenDegeri);
        // }



    }

    public void kosulFonksiyon(GameObject kosul)
    {
        string kosul1 = kosul.transform.GetChild(0).GetChild(0).GetComponentInChildren<TMP_InputField>().text;
        string kosul2 = kosul.transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_InputField>().text;
        //   print(kosul1 + " < " + kosul2);

        int kosulSayi1;
        int kosulSayi2;

        try
        {
            kosulSayi1 = int.Parse(kosul1);
            kosulSayi2 = int.Parse(kosul2);

        }
        catch (Exception e)
        {
            Debug.Log(e.Data);
            kosulSayi1 = 0;
            kosulSayi2 = 0;

        }

        if (kosulSayi1 < kosulSayi2)
        {

            Derlex(kosul.transform.GetChild(1).gameObject);
        }
    }

    public void donguFonksiyon(GameObject dongu)
    {
        string dongu1 = dongu.transform.GetChild(0).GetChild(0).GetComponentInChildren<TMP_InputField>().text;
        string dongu2 = dongu.transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_InputField>().text;
        //   print(kosul1 + " < " + kosul2);

        int donguSayi1;
        int donguSayi2;

        try
        {
            donguSayi1 = int.Parse(dongu1);
            donguSayi2 = int.Parse(dongu2);

        }
        catch (Exception e)
        {
            Debug.Log(e.Data);
            donguSayi1 = 0;
            donguSayi2 = 0;

        }

        for (int i = 0; donguSayi1 < donguSayi2; donguSayi1++)
        {
            print(i);
            Derlex(dongu.transform.GetChild(1).gameObject);
        }
    }






}
