using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneName;    //読み込むシーン名
    [Header("決定時に鳴らすSE")] public AudioClip KETTEI;


    public void Lord()
    {
        Time.timeScale = 1;
        GameManager.instance.PlaySE(KETTEI);
        SceneManager.LoadScene(sceneName);
    }
}
