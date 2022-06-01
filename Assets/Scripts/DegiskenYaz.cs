using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DegiskenYaz : MonoBehaviour
{
    [SerializeField]
    private GameObject ekYazObjesi;

    public TextMeshProUGUI butonunTexti;


    public void DegiskenPanelineEris()
    {
        DeginkenPaneli[] components = Resources.FindObjectsOfTypeAll<DeginkenPaneli>();
       
        components[0].PaneliGoster();
        components[0].degiskenAtama = butonunTexti;
    }


    public void ekObjeOlustur(bool degisken)
    {
        GameObject temp = GameObject.Instantiate(ekYazObjesi);
        temp.transform.SetParent(this.transform);

        if (degisken)
        {
            temp.transform.GetChild(1).gameObject.SetActive(true);

            Destroy(temp.transform.GetChild(0).gameObject);

        }
        else
        {
            temp.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(temp.transform.GetChild(1).gameObject);

        }
    }
    public void ekObjeyiYokEt()
    {
        Destroy(this.gameObject);
    }

    public void ekObjeyiUstteYolla()
    {

        int konum = this.gameObject.transform.GetSiblingIndex() - 1;

        if (konum > 0)
        {
            this.gameObject.transform.SetSiblingIndex(konum);

        }
        else if (konum == 0)
        {
            Transform temp = this.gameObject.transform.GetChild(0);

            Transform parentObject = this.gameObject.transform.parent;


            Transform topObject = parentObject.GetChild(0);

            topObject.SetParent(this.gameObject.transform);
            topObject.SetSiblingIndex(0);

            temp.SetParent(parentObject);
            temp.SetSiblingIndex(0);


        }




    }

}
