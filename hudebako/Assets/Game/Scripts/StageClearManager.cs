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
        //最初だけ動かす
        if (!CheckStart)
        {
            CheckStart = true;  //次動かないようにする
            clearlevel = 0;     //クリア情報初期化
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
