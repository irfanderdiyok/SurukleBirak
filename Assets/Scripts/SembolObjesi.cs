using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SembolObjesi : MonoBehaviour
{
    public TMPro.TextMeshProUGUI sembol;


   

    public void SembolBastir(int sira)
    {
        if (sira == 1)
        {
            sembol.text = "<";

        }
        else if (sira == 2)
        {
            sembol.text = ">";
        }
        else if (sira == 3)
        {
            sembol.text = "≤";
        }
        else if (sira == 4)
        {
            sembol.text = "≥";
        }
        else if (sira == 5)
        {
            sembol.text = "=";
        }
        else if (sira == 6)
        {
            sembol.text = "≠";
        }
        this.gameObject.SetActive(false);

    }
}
