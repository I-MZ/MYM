using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite img;  //�擾���image
    SpriteRenderer sr;  

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();    //SuriteRenderer�擾
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {//�v���C���[���G�ꂽ��
            //SpriteRenderer��image��ύX
            sr.sprite = img;
        }
    }
}
