using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_y : MonoBehaviour
{

    public string sceneName;    //�ǂݍ��ރV�[����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lord()
    {
        SceneManager.LoadScene(sceneName);
    }
}
