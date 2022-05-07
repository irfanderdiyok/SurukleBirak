using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    public bool aktif = false;
    public GameObject prefabObjesi;

     GameObject CanvasGameobject;
    GameObject placeholder = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        CanvasGameobject = GameObject.Find("Canvas");

        if (placeholderParent == null && parentToReturnTo == null && aktif )
        {
            //! Butonun yok olmasını engellemek için
            GameObject eski = GameObject.Instantiate(this.gameObject);
            eski.transform.SetParent(this.transform.parent);
            eski.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        }
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(CanvasGameobject.transform);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;
        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.y > placeholderParent.GetChild(i).position.y)
            {
                newSiblingIndex = i;
                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }
        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }
    public void OnEndDrag(PointerEventData eventData)
    {

        if (prefabObjesi != null)
        {
            prefabObjesi = GameObject.Instantiate(prefabObjesi);
            prefabObjesi.transform.SetParent(parentToReturnTo);
            prefabObjesi.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            Destroy(this.gameObject);
        }
        else
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);


        
    }
}