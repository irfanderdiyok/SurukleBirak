using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeginkenPaneli : MonoBehaviour
{
    [SerializeField] GameObject butonPrefab;


    public TextMeshProUGUI degiskenAtama;



    

    public void PaneliGoster()
    {
       
        this.transform.parent.parent.gameObject.SetActive(true);
    }
    public void PaneliKapa()
    {
        this.transform.parent.parent.gameObject.SetActive(false);
    }

    public void DegiskenleriGuncelle(List<DegiskenOlusturma> degiskenOlusturma)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
        foreach (DegiskenOlusturma degisken in degiskenOlusturma)
        {
            GameObject temp = GameObject.Instantiate(butonPrefab);
            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = degisken.degiskenAdi;
            temp.transform.SetParent(this.transform);

        }

    }



}
