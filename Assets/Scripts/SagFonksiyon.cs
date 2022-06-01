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


// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class SagFonksiyon : MonoBehaviour, IPointerClickHandler {

//     public void OnPointerClick(PointerEventData eventData)
//     {
//         if (eventData.button == PointerEventData.InputButton.Left)
//             Debug.Log("Left click");
//         else if (eventData.button == PointerEventData.InputButton.Middle)
//             Debug.Log("Middle click");
//         else if (eventData.button == PointerEventData.InputButton.Right)
//             Debug.Log("Right click");
//     }
// }