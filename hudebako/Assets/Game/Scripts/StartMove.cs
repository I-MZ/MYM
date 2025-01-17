using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    public GameObject StartImage;
    RectTransform rect;

    [Header("ŠJŽnŽž‚É–Â‚ç‚·SE")] public AudioClip StartSE;


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
            Move();
            Debug.Log("“®‚©‚µ‚½‚æ!");
        }

        if (rect.anchoredPosition.x == 0)
        {
            Invoke("GameManager.instance.PlaySE(StartSE)", 0.25f);
            Invoke(nameof(Move), 0.5f);
        }

        if (rect.anchoredPosition.x < 0)
        {
            Move();
        }

        if (rect.anchoredPosition.x < -1000 || SceneChenger.doRetry)
        {
            Destroy(StartImage);
            PlayerController.gameState = "playing";
        }
    }

    void Move()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - 10,
                                            rect.anchoredPosition.y);
    }
}
