using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        RectTransform myRectTransform = GetComponent<RectTransform>();
        myRectTransform.localPosition += Vector3.right * 10;

    }


    public void Derle(GameObject kod)
    {
       StartCoroutine(Derlex(kod));
    }


    IEnumerator Derlex(GameObject kod)
    {
        foreach (Transform kodObjesi in kod.transform)
        {

            if (kodObjesi.CompareTag("solaDon"))
            {

                SolDon();
            }
            if (kodObjesi.CompareTag("sagaDon"))
            {
                SagDon();
            }
            if (kodObjesi.CompareTag("yukariDon"))
            {
                YukariDon();
            }
            if (kodObjesi.CompareTag("asagiDon"))
            {
                AsagiDon();
            }
            yield return new WaitForSeconds(1);


        }
    }




    public void SolDon()
    {
        anim.Play("SolaDon");
        print("Deneme");
    }
    public void SagDon()
    {
        anim.Play("sag");
        print("Deneme");
    }
    public void AsagiDon()
    {
        anim.Play("asagi");
        print("Deneme");
    }
    public void YukariDon()
    {
        anim.Play("yukari");
        print("Deneme");
    }
    public void Yuruf()
    {
        anim.Play("SolaDon");
        print("Deneme");
    }
}
