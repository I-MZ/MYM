using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneName;    //�ǂݍ��ރV�[����
    [Header("���莞�ɖ炷SE")] public AudioClip KETTEI;


    public void Lord()
    {
        Time.timeScale = 1;
        GameManager.instance.PlaySE(KETTEI);
        SceneManager.LoadScene(sceneName);
    }
}
