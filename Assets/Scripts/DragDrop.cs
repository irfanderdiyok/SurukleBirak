using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Transform bosObjeParent = null;
    public bool aktif = false;
    public GameObject prefabObjesi;

    GameObject CanvasGameobject;
    GameObject bosObje = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        CanvasGameobject = GameObject.Find("Canvas");

        if (bosObjeParent == null && parentToReturnTo == null && aktif)
        {
            //! Butonun yok olmasını engellemek için
            GameObject eski = GameObject.Instantiate(this.gameObject);
            eski.transform.SetParent(this.transform.parent);
            eski.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        }
        bosObje = new GameObject();
        bosObje.transform.SetParent(this.transform.parent);
        LayoutElement le = bosObje.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        // le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.preferredHeight = 63.33f;

        le.flexibleWidth = 0;
        le.flexibleHeight = 0;
        bosObje.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        parentToReturnTo = this.transform.parent;
        bosObjeParent = parentToReturnTo;
        this.transform.SetParent(CanvasGameobject.transform);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position = eventData.position;
        if (bosObje.transform.parent != bosObjeParent)
            bosObje.transform.SetParent(bosObjeParent);

        int newSiblingIndex = bosObjeParent.childCount;



        for (int i = 0; i < bosObjeParent.childCount; i++)
        {
            if (this.transform.position.y > bosObjeParent.GetChild(i).position.y)
            {
                newSiblingIndex = i;
                if (bosObje.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }
        bosObje.transform.SetSiblingIndex(newSiblingIndex);

    }
    public void OnEndDrag(PointerEventData eventData)
    {

        if (prefabObjesi != null)
        {
            prefabObjesi = GameObject.Instantiate(prefabObjesi);
            prefabObjesi.transform.SetParent(parentToReturnTo);
            prefabObjesi.transform.SetSiblingIndex(bosObje.transform.GetSiblingIndex());
            Destroy(this.gameObject);
        }
        else
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(bosObje.transform.GetSiblingIndex());

        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(bosObje);



    }
}