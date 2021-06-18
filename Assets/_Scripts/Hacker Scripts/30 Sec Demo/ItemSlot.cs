using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public GameObject inventoryKey;
    public GameObject wallKey;


    private void Start()
    {
        inventoryKey.SetActive(false);
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            inventoryKey.SetActive(true);
            wallKey.SetActive(false);
            PuzzleManager.gotKey = true;
        }
    }
}
