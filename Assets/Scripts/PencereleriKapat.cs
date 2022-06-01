using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PencereleriKapat : MonoBehaviour
{
    public DeginkenPaneli xrefx;
    public void DegiskenAtaVePencereKapa(){
        xrefx = this.transform.parent.GetComponent<DeginkenPaneli>();
        xrefx.degiskenAtama.text = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        xrefx.PaneliKapa();
    }
}
