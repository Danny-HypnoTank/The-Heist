using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;
    private bool finish;


    private float startPosY;
    private float startPosX;

    private Vector3 resetPos;

    public GameObject objective;
    public GameObject endScreen;

    void Start()
    {
        resetPos = this.transform.localPosition;
        objective.SetActive(true);
        endScreen.SetActive(false);
    }

   
    void Update()
    {
        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;

                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            }
        }
      
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x = this.transform.localPosition.x;
            startPosY = mousePos.y = this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f)
        {
            this.transform.localPosition = new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
            finish = true;
            objective.SetActive(false);
            endScreen.SetActive(true);
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPos.x, resetPos.y, resetPos.z);
        }
    }
}
