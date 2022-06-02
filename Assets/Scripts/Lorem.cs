using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Lorem : MonoBehaviour, IPointerClickHandler
{

    string[] kelimeler = new string[]{"tepki","koca","anne","cadde","önemli","yıldız","polis","hava","sahne","güven","içinde","an","bir","gereksinim","hayat"
   ,"sevgi","karar","insan","mermi","uçak","duygu","umutsuzluk","ev","çalı","güneş","zayıf","oran","düşünce","inanmak","lira","herkes","konuşmak","takılmak",
   "rol","toplum","ileri","orada","dünya","reklam","ilginç","karşılık","besin","süreç","gülmek","boşluk","kalem","vazo","evren","korku","müzik","koltuk"};

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

            for (int i = 0; i < 5; i++)
            {
                GetComponent<TMP_InputField>().text += kelimeler[Random.Range(0, kelimeler.Length)] + " ";
            }

        }


    }
}


