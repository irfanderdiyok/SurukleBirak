using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;





public class GameMaster : MonoBehaviour
{
    public TextMeshProUGUI sonuc;
    int hanlemSayisi = 0;



    public GameObject kod;


    public DeginkenPaneli deginkenPaneliRef;


    public string GorevIcerigi;
    public Missions gorev;
    public int istenenHamleSayisi;


    List<DegiskenOlusturma> degiskenler = new List<DegiskenOlusturma>();




    public void Derle(GameObject kod)
    {

        sonuc.text = "";
        degiskenler.Clear();
        hanlemSayisi = 0;
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
            hanlemSayisi++;
        }
        Debug.Log(sonuc.text);
        Debug.Log(hanlemSayisi);
        if (sonuc.text == GorevIcerigi && istenenHamleSayisi >= hanlemSayisi)
        {

            gorev.Zafer();
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
            hanlemSayisi++;
        }

    }

    public void yazFonksiyon(GameObject metin)
    {
        Transform temp = metin.transform.GetChild(1).GetChild(0);
        if (temp.CompareTag("textkutusu"))
        {
            sonuc.text = sonuc.text + temp.GetComponent<TMP_InputField>().text + " ";
        }
        else
        {
            String tempVar = temp.GetChild(0).GetComponent<TextMeshProUGUI>().text;

            foreach (DegiskenOlusturma degisken in degiskenler)
            {
                if (tempVar == degisken.degiskenAdi)
                {
                    sonuc.text = sonuc.text + degisken.degiskenDegeri;
                }

            }


        }

        int elemanSayisi = metin.transform.GetChild(1).childCount;
        for (int i = 1; i < elemanSayisi; i++)
        {
            Transform temp2 = metin.transform.GetChild(1).GetChild(i).GetChild(0);
            if (temp2.CompareTag("textkutusu"))
            {
                sonuc.text = sonuc.text + temp2.GetComponent<TMP_InputField>().text + " ";
            }
            else
            {
                String tempVar = temp2.GetChild(0).GetComponent<TextMeshProUGUI>().text;

                foreach (DegiskenOlusturma degisken in degiskenler)
                {
                    if (tempVar == degisken.degiskenAdi)
                    {
                        sonuc.text = sonuc.text + degisken.degiskenDegeri;
                    }

                }

            }

        }
    }

    public void degiskenFonksiyon(GameObject veri)
    {

        String geciciDegiskenAdi = veri.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>().text;
        String geciciDegiskenDegeri = veri.transform.GetChild(0).GetChild(2).GetComponent<TMP_InputField>().text;
        bool geciciDegiskenTuru = veri.GetComponent<Fonksiyon>().degiskenTuru;

        bool islemTamamlandi = false;
        foreach (DegiskenOlusturma degisken in degiskenler)
        {
            if (degisken.degiskenAdi == geciciDegiskenAdi)
            {
                degisken.degiskenDegeri = geciciDegiskenDegeri;
                degisken.isString = geciciDegiskenTuru;
                islemTamamlandi = true;
                break;
            }

        }

        if (!islemTamamlandi)
        {
            DegiskenOlusturma yeniDegisken = new DegiskenOlusturma();
            yeniDegisken.degiskenAdi = geciciDegiskenAdi;
            yeniDegisken.degiskenDegeri = geciciDegiskenDegeri;
            yeniDegisken.isString = geciciDegiskenTuru;
            degiskenler.Add(yeniDegisken);
            deginkenPaneliRef.DegiskenleriGuncelle(degiskenler);

        }

    }

    public void kosulFonksiyon(GameObject kosul)
    {
        string kosul1 = kosul.transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_InputField>().text;
        string isaret = kosul.transform.GetChild(0).GetChild(2).GetComponentInChildren<TMP_Text>().text;
        string kosul2 = kosul.transform.GetChild(0).GetChild(3).GetComponentInChildren<TMP_InputField>().text;
        print(kosul1 + isaret + kosul2);

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

        if (isaret == "<")
        {
            if (kosulSayi1 < kosulSayi2)
            {

                Derlex(kosul.transform.GetChild(1).gameObject);
            }

        }
        else if (isaret == ">")
        {
            if (kosulSayi1 > kosulSayi2)
            {

                Derlex(kosul.transform.GetChild(1).gameObject);
            }
        }
        else if (isaret == "≤")
        {
            if (kosulSayi1 <= kosulSayi2)
            {

                Derlex(kosul.transform.GetChild(1).gameObject);
            }
        }
        else if (isaret == "≥")
        {
            if (kosulSayi1 >= kosulSayi2)
            {

                Derlex(kosul.transform.GetChild(1).gameObject);
            }
        }
        else if (isaret == "=")
        {
            if (kosulSayi1 == kosulSayi2)
            {

                Derlex(kosul.transform.GetChild(1).gameObject);
            }
        }

        else if (isaret == "≠")
        {
            if (kosulSayi1 != kosulSayi2)
            {

                Derlex(kosul.transform.GetChild(1).gameObject);
            }
        }






    }

    public void donguFonksiyon(GameObject dongu)
    {
        string dongu1 = dongu.transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_InputField>().text;
        string dongu2 = dongu.transform.GetChild(0).GetChild(3).GetComponentInChildren<TMP_InputField>().text;
        string isaret = dongu.transform.GetChild(0).GetChild(2).GetComponentInChildren<TMP_Text>().text;
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


        hanlemSayisi = (hanlemSayisi + 1) - (donguSayi2 - donguSayi1);

        if (isaret == "<")
        {
            for (int i = 0; donguSayi1 < donguSayi2; donguSayi1++)
            {
                print(i);
                Derlex(dongu.transform.GetChild(1).gameObject);
            }

        }
        else if (isaret == ">")
        {
            for (int i = 0; donguSayi1 > donguSayi2; donguSayi2++)
            {
                print(i);
                Derlex(dongu.transform.GetChild(1).gameObject);
            }
        }
        else if (isaret == "≤")
        {
            for (int i = 0; donguSayi1 <= donguSayi2; donguSayi1++)
            {
                print(i);
                Derlex(dongu.transform.GetChild(1).gameObject);
            }
        }
        else if (isaret == "≥")
        {
            for (int i = 0; donguSayi1 >= donguSayi2; donguSayi2++)
            {
                print(i);
                Derlex(dongu.transform.GetChild(1).gameObject);
            }
        }




    }






}
