using System.Collections;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed;
    private Vector3 startPosition;

    public float ScrollSpeed { get => scrollSpeed; set => scrollSpeed = value; }

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(translation: Vector3.down * scrollSpeed * Time.deltaTime);

        if (transform.position.y < -59.33f)
        {
            transform.position = startPosition;
        }
    }
}
