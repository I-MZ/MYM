using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_y : MonoBehaviour
{

    public string sceneName;    //ì«Ç›çûÇﬁÉVÅ[Éìñº

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
