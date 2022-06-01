using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DeginkenPaneli : MonoBehaviour
{
    [SerializeField] GameObject butonPrefab;


    public TextMeshProUGUI degiskenAtama;

   


    private Color mavi = new Color(100f / 255f, 200f / 255f, 250f / 255f);
    private Color sari = new Color(233f / 255f, 236f / 255f, 103f / 255f);


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

            if (degisken.isString)
            {
                temp.GetComponent<Image>().color = sari;
            }
            else
            {
                temp.GetComponent<Image>().color = mavi;
            }
            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = degisken.degiskenAdi;
            temp.transform.SetParent(this.transform);



        }

    }

   


}
