using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Lock_Set : MonoBehaviour
{
    [SerializeField] public GameObject stage_lock_UL;//左上
    [SerializeField] public GameObject stage_lock_UR;//右上
    [SerializeField] public GameObject stage_lock_DL;//左下
    [SerializeField] public GameObject stage_lock_DR;//右下


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

        //ロックを表示しておく
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


        //クリアした所と挑戦できるようになった所はロックを非表示にする
        //ステージ1～4まで
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 0)
            stage_lock_UL.SetActive(false);
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 1)
            stage_lock_UR.SetActive(false);
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 2)
            stage_lock_DL.SetActive(false);
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 3)
            stage_lock_DR.SetActive(false); 
        
        //ステージ4～8まで
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 4)
            stage_lock_UL.SetActive(false);
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 5)
            stage_lock_UR.SetActive(false);
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 6)
            stage_lock_DL.SetActive(false);
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 7)
            stage_lock_DR.SetActive(false); 
        
        //ステージ9～10まで
        if (Panel_Manager_m.page_num == 2 && nowclearlevel >= 8)
            stage_lock_UL.SetActive(false);
        if (Panel_Manager_m.page_num == 2 && nowclearlevel >= 9)
            stage_lock_UR.SetActive(false);
       

       
    }
}
