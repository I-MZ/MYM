using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneName;    //�ǂݍ��ރV�[����

    public void Lord()
    {
        SceneManager.LoadScene(sceneName);
    }
}
