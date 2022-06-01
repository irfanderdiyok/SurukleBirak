using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiled : MonoBehaviour
{
    public GameObject cimen;




   
    public int imin;
    public int imax;
    public int jmin;
    public int jmax;


   


    public void HaritaOlustur()
    {
        
        for (int i = imin; i < imax; i++)
        {
            for (int j = jmin; j < jmax; j++)
            {

                GameObject temp = Instantiate(cimen, new Vector3((i * 108) + 1272, (-j * 108) + 1080, 0), Quaternion.identity);

                temp.transform.parent = this.gameObject.transform;

            }
        }
    }
   
}

