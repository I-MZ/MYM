using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMove : MonoBehaviour
{

    public GameObject ClearImage;
    RectTransform rect;

    private float Movespeed = 10.0f;
    private float Stoptime = 0.5f;

    public static bool Movefinish = false;
    private bool DoCheck;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        DoCheck = false;
        Movefinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameState != "clear")
        {
            return;
        }

        //âEÇ©ÇÁâÊñ íÜâõÇ‹Ç≈ìÆÇ©Ç∑
        if (rect.anchoredPosition.x > 0)
        {
            Move();
            Debug.Log("ìÆÇ©ÇµÇΩÇÊ!");
        }

        //âÊñ íÜâõÇ≈è≠ÇµÇ∆Ç«ÇﬂÇÈ
        if (rect.anchoredPosition.x == 0)
        {
            if (!DoCheck)
            {
                Invoke(nameof(Move), Stoptime);
                DoCheck = true;
            }
        }

        //âÊñ íÜâõÇ©ÇÁç∂Ç…ìÆÇ©Ç∑
        if (rect.anchoredPosition.x < 0)
        {
            Move();
        }

        //âÊñ äOÇ…çsÇ¡ÇΩÇÁè¡Ç∑
        if (rect.anchoredPosition.x < -700 || SceneChenger.doRetry)
        {
            Movefinish = true;
            Destroy(ClearImage);
        }
    }

    //ç∂Ç…è≠ÇµìÆÇ©Ç∑ä÷êî
    void Move()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - Movespeed,
                                            rect.anchoredPosition.y);
    }
}
