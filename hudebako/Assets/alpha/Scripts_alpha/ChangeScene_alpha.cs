using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_alpha : MonoBehaviour
{

    public string sceneName;    //読み込むシーン名

    public void Lord()
    {
        SceneManager.LoadScene(sceneName);
    }
}
