using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    public GameObject StartImage;
    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rect.anchoredPosition.x > 0)
        {
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - 1, rect.anchoredPosition.y);
        }
    }
}
