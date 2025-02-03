using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Clear_Set : MonoBehaviour
{
    [SerializeField] public GameObject stage_Clear_UL;//左上
    [SerializeField] public GameObject stage_Clear_UR;//右上
    [SerializeField] public GameObject stage_Clear_DL;//左下
    [SerializeField] public GameObject stage_Clear_DR;//右下


    // Start is called before the first frame update
    void Start()
    {
        stage_Clear_UL.SetActive(false);
        stage_Clear_UR.SetActive(false);
        stage_Clear_DL.SetActive(false);
        stage_Clear_DR.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        ClearSetAcvive();
    }

    public void ClearSetAcvive()
    {
        int nowclearlevel = StageClearManager.clearlevel;

        //文字は非表示にしておく
        if (Panel_Manager_m.page_num == 0)
        {
            stage_Clear_UL.SetActive(false);
            stage_Clear_UR.SetActive(false);
            stage_Clear_DL.SetActive(false);
            stage_Clear_DR.SetActive(false);
        }
        if (Panel_Manager_m.page_num == 1)
        {
            stage_Clear_UL.SetActive(false);
            stage_Clear_UR.SetActive(false);
            stage_Clear_DL.SetActive(false);
            stage_Clear_DR.SetActive(false);
        }
        if (Panel_Manager_m.page_num == 2)
        {
            stage_Clear_UL.SetActive(false);
            stage_Clear_UR.SetActive(false);
            stage_Clear_DL.SetActive(false);
            stage_Clear_DR.SetActive(false);
        }


        //クリアしたステージCLEARの文字を表示する
        //ステージ1～4まで
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 1)
            stage_Clear_UL.SetActive(true);
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 2)
            stage_Clear_UR.SetActive(true);
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 3)
            stage_Clear_DL.SetActive(true);
        if (Panel_Manager_m.page_num == 0 && nowclearlevel >= 4)
            stage_Clear_DR.SetActive(true);

        //ステージ4～8まで
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 5)
            stage_Clear_UL.SetActive(true);
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 6)
            stage_Clear_UR.SetActive(true);
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 7)
            stage_Clear_DL.SetActive(true);
        if (Panel_Manager_m.page_num == 1 && nowclearlevel >= 8)
            stage_Clear_DR.SetActive(true);

        //ステージ9～10まで
        if (Panel_Manager_m.page_num == 2 && nowclearlevel >= 9)
            stage_Clear_UL.SetActive(true);
        if (Panel_Manager_m.page_num == 2 && nowclearlevel >= 10)
            stage_Clear_UR.SetActive(true);



    }
}
