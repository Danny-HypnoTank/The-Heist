using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ValuableMover : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [SerializeField]
    private int value;
    private bool isInSlot = false;

    [SerializeField]
    private CollectionController collectionController;

    public bool IsInSlot { get => isInSlot; set => isInSlot = value; }
    public int Value { get => value; set => this.value = value; }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (collectionController.LevelOver != true)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            if (isInSlot == true)
            {
                collectionController.Score = collectionController.Score - value;
                isInSlot = false;
            }
            else
            {
                isInSlot = false;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (collectionController.LevelOver != true)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (collectionController.LevelOver != true)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (collectionController.LevelOver != true)
        {
            Debug.Log("OnPointerDown");
        }
    }
}
