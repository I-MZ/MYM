using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearManager : MonoBehaviour
{

    public static int clearlevel;
    public static bool CheckStart = false;
   

    // Start is called before the first frame update
    void Start()
    {
        //�ŏ�����������
        if (!CheckStart)
        {
            CheckStart = true;  //�������Ȃ��悤�ɂ���
            clearlevel = 0;     //�N���A��񏉊���
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
