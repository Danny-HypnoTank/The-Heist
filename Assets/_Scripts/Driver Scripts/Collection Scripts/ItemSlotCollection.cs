using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotCollection : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private CollectionController collectionController;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<ValuableMover>().IsInSlot = true;
            collectionController.Score = collectionController.Score + eventData.pointerDrag.GetComponent<ValuableMover>().Value;
        }
    }
}
