using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ԓn�_�̌����ڂ̂ӂ�܂��𐧌䂷��N���X
/// </summary>
public class CheckPoint : MonoBehaviour
{
    public Sprite img;  //�擾���image
    SpriteRenderer sr;

    public AudioClip GetSE;

    private bool Get;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();    //SpriteRenderer�擾
        Get = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {//�v���C���[���G�ꂽ��
            //SpriteRenderer��image��ύX
            sr.sprite = img;
            if (!Get)
            {
                SceneChenger.instance.PlaySE(GetSE);
                Get = true;
            }
        }
    }
}
