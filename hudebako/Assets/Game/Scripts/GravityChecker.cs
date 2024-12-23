using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityChecker : MonoBehaviour
{
    Image Img;

    public Sprite ArrowDown;    //�����
    public Sprite ArrowUp;      //����
    public Sprite ArrowRight;   //�E���
    public Sprite ArrowLeft;    //�����

    // Start is called before the first frame update
    void Start()
    {
        Img = GetComponent<Image>();    //Image�R���|�[�l���g���擾

    }

    // Update is called once per frame
    void Update()
    {
        //PleyerController��null����Ȃ����m�F
        if (PlayerController.instance != null)
        {
            switch (PlayerController.instance.gravity) 
            {//PlayerController��gravity(�d�͂̌���)���`�F�b�N

                case 0://���̂Ƃ�
                    Img.sprite = ArrowDown; //������
                    break;
                case 1://��̂Ƃ�
                    Img.sprite = ArrowUp;   //�����
                    break;
                case 2://�E�̂Ƃ�
                    Img.sprite = ArrowRight;//�E����
                    break;
                case 3://���̂Ƃ�
                    Img.sprite = ArrowLeft; //������
                    break;
            }

            //PlayerController��forcepower(�d�͂̋���)���`�F�b�N
            if (PlayerController.instance.forcepower)
            {//true(�������)
                //�F���Â�����
                Img.color = new Color(0.7f, 0.7f, 0.7f);
            }
            else
            {//false(�ア���)
                //�F��߂�
                Img.color = new Color(1, 1, 1);
            }
        }
    }
}
