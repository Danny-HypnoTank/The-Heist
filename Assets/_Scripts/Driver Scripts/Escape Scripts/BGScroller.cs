using System.Collections;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(translation: Vector3.down * scrollSpeed * Time.deltaTime);

        if (transform.position.y < -20.79783f)
        {
            transform.position = startPosition;
        }
    }
}
