using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ԓn�_�̌����ڂ̂ӂ�܂��𐧌䂷��N���X
/// </summary>
public class CheckPoint : MonoBehaviour
{
    public static CheckPoint instance;

    public Sprite img;  //�擾���image
    SpriteRenderer sr;
    Transform tf;
    public Vector2 Position;

    public AudioClip GetSE;

    private bool Get;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();    //SpriteRenderer�擾
        tf = GetComponent<Transform>();         //Transfoam�擾
        Position = tf.position;
        Get = false;
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {//�v���C���[���G�ꂽ��
            //SpriteRenderer��image��ύX
            sr.sprite = img;

            //�܂�����Ă��Ȃ����
            if (!Get)
            {
                //�擾����炷
                SceneChenger.instance.PlaySE(GetSE);
                //��������Ƃɂ���
                Get = true;
            }
        }
    }
}
