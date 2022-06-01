using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Missions : MonoBehaviour
{
    

    public void SonrakiBolum(string levelAdi)
    {
        SceneManager.LoadScene(levelAdi);
    }

    public void Kapat()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Zafer()
    {
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

}