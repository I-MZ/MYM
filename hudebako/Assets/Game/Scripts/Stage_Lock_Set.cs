using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Lock_Set : MonoBehaviour
{
    [SerializeField] public GameObject stage_lock_UL;//����
    [SerializeField] public GameObject stage_lock_UR;//�E��
    [SerializeField] public GameObject stage_lock_DL;//����
    [SerializeField] public GameObject stage_lock_DR;//�E��


    // Start is called before the first frame update
    void Start()
    {
        stage_lock_UL.SetActive(true);
        stage_lock_UR.SetActive(true);
        stage_lock_DL.SetActive(true);
        stage_lock_DR.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        LockSetAcvive();
    }

    public void LockSetAcvive()
    {
        int nowclearlevel = StageClearManager.clearlevel;

        //���b�N��\�����Ă���
        if (Panel_Manager_m.page_num == 0)
        {
            stage_lock_UL.SetActive(true);
            stage_lock_UR.SetActive(true);
            stage_lock_DL.SetActive(true);
            stage_lock_DR.SetActive(true);
        }
        if (Panel_Manager_m.page_num == 1)
        {
            stage_lock_UL.SetActive(true);
            stage_lock_UR.SetActive(true);
            stage_lock_DL.SetActive(true);
            stage_lock_DR.SetActive(true);
        }
        if (Panel_Manager_m.page_num == 2)
        {
            stage_lock_UL.SetActive(true);
            stage_lock_UR.SetActive(true);
            stage_lock_DL.SetActive(false);
            stage_lock_DR.SetActive(false);
        }


        //�N���A�������ƒ���ł���悤�ɂȂ������̓��b�N���\���ɂ���
        //�X�e�[�W1�`4�܂�
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 0)
            stage_lock_UL.SetActive(false);
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 1)
            stage_lock_UR.SetActive(false);
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 2)
            stage_lock_DL.SetActive(false);
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 3)
            stage_lock_DR.SetActive(false); 
        
        //�X�e�[�W4�`8�܂�
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 4)
            stage_lock_UL.SetActive(false);
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 5)
            stage_lock_UR.SetActive(false);
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 6)
            stage_lock_DL.SetActive(false);
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 7)
            stage_lock_DR.SetActive(false); 
        
        //�X�e�[�W9�`10�܂�
        if (Panel_Manager_m.page_num == 2 && nowclearlevel >= 8)
            stage_lock_UL.SetActive(false);
        if (Panel_Manager_m.page_num == 2 && nowclearlevel >= 9)
            stage_lock_UR.SetActive(false);
       

       
    }
}
