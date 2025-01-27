using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��K
public class Penetration : MonoBehaviour
{
    public GameObject PlayerObject;
    PlayerController Pcnt;
    public int CkopenGravity;
    public int CkcloseGravity;

    private BoxCollider2D BC;

    Animator animator;
     string open  = "Ruler_Open";
     string close = "Ruler_Close";

    string nowanime = "";
    string oldanime = "";

    //�X�^�[�g�֐�
    //����
    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�擾
        Pcnt     = PlayerObject.GetComponent<PlayerController>();
        BC       = this.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //��K�̊J��
        if (CkopenGravity == Pcnt.gravity) 
        {
            Debug.Log("�J���H");
            
            //�J����
            if (nowanime != open)
            {
                Debug.Log("�J����");
            }

            BC.enabled = false;//�����蔻��𖳌�������
            nowanime   = open; //�J����A�j���[�V�����ɕύX
        }
        else if(CkcloseGravity==Pcnt.gravity||PlayerController.gameState=="respawn")
        {

            if (nowanime != close)//�߂�
            {
                Debug.Log("����");
            }

            BC.enabled = true; //�����蔻���L��������
            nowanime   = close;//�߂�A�j���[�V�����ɕύX
        }

        //�A�j���[�V�����̕ύX�̏���
        if (nowanime != oldanime)   //�A�j���[�V�������������m�F����
        {
            oldanime = nowanime;    //oldanime�ɐV�����A�j���[�V������ݒ肷��
            animator.Play(nowanime);//nowanime�ɓ����Ă���A�j���[�V�����𗬂�
            Debug.Log("anime = " + nowanime);
        }
    }

}
