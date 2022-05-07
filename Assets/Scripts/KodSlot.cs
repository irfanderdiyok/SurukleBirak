using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class KodSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject kodSayfasi;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragDrop d = eventData.pointerDrag.GetComponent<DragDrop>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragDrop d = eventData.pointerDrag.GetComponent<DragDrop>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragDrop d = eventData.pointerDrag.GetComponent<DragDrop>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }
}
