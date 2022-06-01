using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SembolObjesi : MonoBehaviour
{

    public static SembolObjesi init;
    public TMPro.TextMeshProUGUI sembol;
    int acikOlan;

    private void Awake()
    {
        init = this;

    }


    public void semboluGoster(int hangisi)
    {
        this.transform.GetChild(hangisi).gameObject.SetActive(true);
        acikOlan = hangisi;
    }


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
        else if (sira == 7)
        {
            sembol.text = "+";
        }
        else if (sira == 8)
        {
            sembol.text = "-";
        }
        else if (sira == 9)
        {
            sembol.text = "/";
        }
        else if (sira == 10)
        {
            sembol.text = "x";
        }
        else if (sira == 11)
        {
            sembol.text = "%";
        }
        else if (sira == 12)
        {
            sembol.text = "?";
        }
        
        this.transform.GetChild(acikOlan).gameObject.SetActive(false);

    }
}
