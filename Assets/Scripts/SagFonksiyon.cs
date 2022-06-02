using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SagFonksiyon : MonoBehaviour, IPointerClickHandler
{

    public GameObject prefabs;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameObject metinYazdirma = GameObject.Instantiate(prefabs);
            metinYazdirma.transform.SetParent(this.transform.parent);
            metinYazdirma.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
            Destroy(this.gameObject);
        }


    }
}


