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

        //�E�����ʒ����܂œ�����
        if (rect.anchoredPosition.x > 0)
        {
            Move();
            Debug.Log("����������!");
        }

        //��ʒ����ŏ����Ƃǂ߂�
        if (rect.anchoredPosition.x == 0)
        {
            if (!DoCheck)
            {
                Invoke(nameof(Move), Stoptime);
                DoCheck = true;
            }
        }

        //��ʒ������獶�ɓ�����
        if (rect.anchoredPosition.x < 0)
        {
            Move();
        }

        //��ʊO�ɍs���������
        if (rect.anchoredPosition.x < -700 || SceneChenger.doRetry)
        {
            Movefinish = true;
            Destroy(ClearImage);
        }
    }

    //���ɏ����������֐�
    void Move()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - Movespeed,
                                            rect.anchoredPosition.y);
    }
}
