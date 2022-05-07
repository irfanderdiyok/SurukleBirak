using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fonksiyon : MonoBehaviour
{

    private void Start()
    {
        if (this.gameObject.transform.parent.CompareTag("Kodyeri"))
        {
            Destroy(this.gameObject);
        }
    }
    public void YokEt()
    {
        Destroy(this.gameObject);
    }




}
