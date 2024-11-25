using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearManager : MonoBehaviour
{

    public static int clearlevel;
    public static bool checkstart = false;
   

    // Start is called before the first frame update
    void Start()
    {
        if (!checkstart)
        {
            checkstart = true;
            clearlevel = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
