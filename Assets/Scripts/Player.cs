using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Player : MonoBehaviour
{
    Animator anim;
    RectTransform playerRectTransform;

    int step = 5;

    Vector2 aralik;


    Vector3 baslangic;


    Vector2 yon = new Vector2(0, -1);


    bool hareketEt = false;



    public Transform ev;
    Vector3 evinKonumu;


    public GameObject tiled;

    public Missions gorev;


    void Start()
    {

        evinKonumu = new Vector2(ev.position.x - 6, ev.position.y + 10);

        anim = GetComponent<Animator>();
        playerRectTransform = GetComponent<RectTransform>();


        aralik = playerRectTransform.position;
        baslangic = playerRectTransform.position;


    }

    private void Update()
    {
        if (hareketEt)
        {

            playerRectTransform.position = Vector2.MoveTowards(playerRectTransform.position, aralik, step);

            if (Vector2.Distance(playerRectTransform.position, aralik) <= 0)
            {
                anim.Play("bos");
                hareketEt = false;
            }
        }


    }


    public void Derle(GameObject kod)
    {

        playerRectTransform.position = baslangic;
        yon = new Vector2(0, -1);
        aralik = baslangic;
        anim.Play("ondon");

        aranacakElmaSayisi = aranmasiIstenenElmaSayisi;
        if(elma!=null){
            elma.SetActive(true);
        }


        StartCoroutine(Derlex(kod));
    }

    string animasyondi = "yuruon";

    IEnumerator Derlex(GameObject kod)
    {
        for (int i = 0; i < kod.transform.childCount; i++)
        {
            GameObject kodObjesi = kod.transform.GetChild(i).gameObject;
            if (kodObjesi.CompareTag("yuru"))
            {
                Yuruf();

            }
            if (kodObjesi.CompareTag("sag"))
            {
                animasyondi = "yuru";
                SagDon();
            }
            if (kodObjesi.CompareTag("sol"))
            {
                animasyondi = "yurusol";
                SolDon();
            }
            if (kodObjesi.CompareTag("on"))
            {
                animasyondi = "yuruon";
                OnDon();
            }
            if (kodObjesi.CompareTag("arka"))
            {
                animasyondi = "yuruarka";
                ArkaDon();
            }
            if (kodObjesi.CompareTag("if"))
            {
                kosulFonksiyon(kodObjesi.gameObject);
            }
            if (kodObjesi.CompareTag("dongu"))
            {
                yield return StartCoroutine(donguFonksiyon(kodObjesi.gameObject));
            }
            yield return new WaitForSeconds(0.75f);

        }



        if (playerRectTransform.position == evinKonumu && aranacakElmaSayisi == 0)
        {
            Debug.Log("Başardin");
            gorev.Zafer();
        }


    }




    public void SolDon()
    {
        anim.Play("soldon");
        yon = new Vector2(-1, 0);

    }
    public void SagDon()
    {
        anim.Play("sagdon");
        yon = new Vector2(1, 0);
    }
    public void ArkaDon()
    {
        anim.Play("arkadon");
        yon = new Vector2(0, 1);
    }
    public void OnDon()
    {
        anim.Play("ondon");
        yon = new Vector2(0, -1);
    }

    public int aranacakElmaSayisi = 0;
    public int aranmasiIstenenElmaSayisi=0;
    public GameObject elma;
    public void Yuruf()
    {
        aralik = new Vector2(aralik.x + (yon.x * 108), aralik.y + (yon.y * 108));

        //!Taş kontrol
        foreach (Transform tile in tiled.transform)
        {
            if (tile.CompareTag("engel"))
            {
                Vector2 gecici = new Vector2(tile.position.x - 6, tile.position.y + 10);
                if (aralik == gecici)
                {
                    Debug.Log("Taş var");
                    aralik = playerRectTransform.position;
                }
            }
            if (tile.CompareTag("portal"))
            {
                Vector2 gecici = new Vector2(tile.position.x - 6, tile.position.y + 10);

                if (aralik == gecici)
                {
                    Debug.Log("Portal var");
                    aralik = tile.GetComponent<Portal>().otherportal.position;
                    playerRectTransform.position = tile.GetComponent<Portal>().otherportal.position;
                }

            }
            if (tile.CompareTag("elma"))
            {
                Vector2 gecici = new Vector2(tile.position.x - 6, tile.position.y + 10);

                if (aralik == gecici)
                {
                    Debug.Log("Elma var");
                    elma = tile.GetChild(0).transform.GetChild(0).gameObject;
                    elma.SetActive(false);
                    aranacakElmaSayisi--;

                }

            }
        }

        aralik.x = Mathf.Clamp(aralik.x, 1266f, 1806f);
        aralik.y = Mathf.Clamp(aralik.y, 118f, 1090f);
        anim.Play(animasyondi);
        hareketEt = true;

    }






    public void kosulFonksiyon(GameObject kosul)
    {
        string kosul1 = kosul.transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_InputField>().text;
        string kosul2 = kosul.transform.GetChild(0).GetChild(3).GetComponentInChildren<TMP_InputField>().text;
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
            StartCoroutine(Derlex(kosul.transform.GetChild(1).gameObject));

        }
    }

    IEnumerator donguFonksiyon(GameObject dongu)
    {
        string dongu1 = dongu.transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_InputField>().text;
        string dongu2 = dongu.transform.GetChild(0).GetChild(3).GetComponentInChildren<TMP_InputField>().text;
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
            i++;



            yield return StartCoroutine(Derlex(dongu.transform.GetChild(1).gameObject));

        }
    }
}
