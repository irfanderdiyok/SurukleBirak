using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;





public class GameMaster : MonoBehaviour
{
    public TextMeshProUGUI sonuc;
   

    string oruntu = "";



    public GameObject kod;


    public DeginkenPaneli deginkenPaneliRef;

    public Missions gorev;
    public string GorevIcerigi;
    public string istenenOruntu;

   


    List<DegiskenOlusturma> degiskenler = new List<DegiskenOlusturma>();



    public void OrunutIncele(Transform kod)
    {
        foreach (Transform kodObjesi in kod)
        {
            if (kodObjesi.CompareTag("print"))
            {
                oruntu += "p";


            }
            if (kodObjesi.CompareTag("degisken"))
            {
                oruntu += "v";

            }
            if (kodObjesi.CompareTag("if"))
            {

                oruntu += "i<";
                OrunutIncele(kodObjesi.GetChild(1));
                oruntu+=">";

            }
            if (kodObjesi.CompareTag("dongu"))
            {
                oruntu += "l<";
                OrunutIncele(kodObjesi.GetChild(1));
                oruntu+=">";

            }
            if (kodObjesi.CompareTag("matematik"))
            {
                oruntu += "m";

            }

        }

    }

    public void Derle(GameObject kod)
    {

        sonuc.text = "";
        degiskenler.Clear();
        oruntu = "";
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
            if (kodObjesi.CompareTag("matematik"))
            {
                matematikFonksiyon(kodObjesi.gameObject);

            }
            
        }
        OrunutIncele(kod.transform);
        Debug.Log(sonuc.text);
       
        Debug.Log(oruntu);
        if (sonuc.text == GorevIcerigi && oruntu ==istenenOruntu)
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
            if (kodObjesi.CompareTag("matematik"))
            {

                matematikFonksiyon(kodObjesi.gameObject);
            }
           
        }

    }


    public void matematikFonksiyon(GameObject matematik)
    {


        String degisken1 = matematik.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        String hesap1 = matematik.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        String islem = matematik.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        String hesap2 = matematik.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text;

        float deger1 = 0;
        float deger2 = 0;

        foreach (DegiskenOlusturma degisken in degiskenler)
        {
            if (degisken1 == degisken.degiskenAdi)
            {
                if (degisken.isString)
                {
                    matematik.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                    matematik.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                    matematik.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                    return;
                }
                else
                {
                    deger1 = float.Parse(degisken.degiskenDegeri);
                }

            }

            if (hesap1 == degisken.degiskenAdi)
            {
                if (degisken.isString)
                {
                    matematik.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                    matematik.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                    matematik.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                    return;
                }
                else
                {
                    deger1 = float.Parse(degisken.degiskenDegeri);
                }

            }
            if (hesap2 == degisken.degiskenAdi)
            {
                if (degisken.isString)
                {
                    matematik.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                    matematik.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                    matematik.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                    return;
                }
                else
                {
                    deger2 = float.Parse(degisken.degiskenDegeri);
                }

            }

        }
        float araIslem = 0;
        if (islem == "+")
        {
            araIslem = deger1 + deger2;
        }
        else if (islem == "-")
        {
            araIslem = deger1 - deger2;
        }
        else if (islem == "/")
        {
            araIslem = deger1 / deger2;
        }
        else if (islem == "x")
        {
            araIslem = deger1 * deger2;
        }
        else if (islem == "%")
        {
            araIslem = deger1 % deger2;
        }
        else if (islem == "?")
        {
            if (deger1 >= deger2)
            {
                araIslem = deger1;
            }
            else
            {
                araIslem = deger2;
            }

        }

        for (int i = 0; i < degiskenler.Count; i++)
        {
            if (degiskenler[i].degiskenAdi == degisken1)
            {
                degiskenler[i].degiskenDegeri = araIslem.ToString();
            }

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
        string kosul1 = "";
        string kosul2 = "";

        if (kosul.transform.GetChild(0).GetChild(1).CompareTag("textkutusu"))
        {
            kosul1 = kosul.transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_InputField>().text;
        }
        else
        {
            String gecici = kosul.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
            foreach (DegiskenOlusturma degisken in degiskenler)
            {
                if (gecici == degisken.degiskenAdi)
                {
                    if (degisken.isString)
                    {
                        kosul.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                        return;
                    }
                    else
                    {
                        // deger1 = float.Parse(degisken.degiskenDegeri);
                        kosul1 = degisken.degiskenDegeri;
                    }

                }


            }
        }


        if (kosul.transform.GetChild(0).GetChild(3).CompareTag("textkutusu"))
        {
            kosul2 = kosul.transform.GetChild(0).GetChild(3).GetComponentInChildren<TMP_InputField>().text;
        }
        else
        {
            String gecici = kosul.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text;
            foreach (DegiskenOlusturma degisken in degiskenler)
            {
                if (gecici == degisken.degiskenAdi)
                {
                    if (degisken.isString)
                    {
                        kosul.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                        return;
                    }
                    else
                    {
                        // deger1 = float.Parse(degisken.degiskenDegeri);
                        kosul2 = degisken.degiskenDegeri;
                    }

                }


            }

        }



        string isaret = kosul.transform.GetChild(0).GetChild(2).GetComponentInChildren<TMP_Text>().text;
        int kosulSayi1;
        int kosulSayi2;

        try
        {
            kosulSayi1 = int.Parse(kosul1);
            kosulSayi2 = int.Parse(kosul2);

        }
        catch (Exception e)
        {
            Debug.Log("Hata Oluştu:"+e.Data);
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
        string dongu1 = "";
        string dongu2 = "";

        if (dongu.transform.GetChild(0).GetChild(1).CompareTag("textkutusu"))
        {
            dongu1 = dongu.transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_InputField>().text;
        }
        else
        {
            String gecici = dongu.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
            foreach (DegiskenOlusturma degisken in degiskenler)
            {
                if (gecici == degisken.degiskenAdi)
                {
                    if (degisken.isString)
                    {
                        dongu.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                        return;
                    }
                    else
                    {
                        // deger1 = float.Parse(degisken.degiskenDegeri);
                        dongu1 = degisken.degiskenDegeri;
                    }

                }


            }
        }


        if (dongu.transform.GetChild(0).GetChild(3).CompareTag("textkutusu"))
        {
            dongu2 = dongu.transform.GetChild(0).GetChild(3).GetComponentInChildren<TMP_InputField>().text;
        }
        else
        {
            String gecici = dongu.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text;
            foreach (DegiskenOlusturma degisken in degiskenler)
            {
                if (gecici == degisken.degiskenAdi)
                {
                    if (degisken.isString)
                    {
                        dongu.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                        return;
                    }
                    else
                    {
                        // deger1 = float.Parse(degisken.degiskenDegeri);
                        dongu2 = degisken.degiskenDegeri;
                    }

                }


            }

        }


        string isaret = dongu.transform.GetChild(0).GetChild(2).GetComponentInChildren<TMP_Text>().text;


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
