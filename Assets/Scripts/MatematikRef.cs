using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatematikRef : MonoBehaviour
{
     public void DegiskenPanelineEris(TextMeshProUGUI butonunTexti)
    {
       DeginkenPaneli[] components = Resources.FindObjectsOfTypeAll<DeginkenPaneli>();
       components[0].PaneliGoster();
       components[0].degiskenAtama = butonunTexti;
    }

}
