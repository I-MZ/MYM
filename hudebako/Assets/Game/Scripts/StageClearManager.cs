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
        //Å‰‚¾‚¯“®‚©‚·
        if (!CheckStart)
        {
            CheckStart = true;  //Ÿ“®‚©‚È‚¢‚æ‚¤‚É‚·‚é
            clearlevel = 0;     //ƒNƒŠƒAî•ñ‰Šú‰»
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
