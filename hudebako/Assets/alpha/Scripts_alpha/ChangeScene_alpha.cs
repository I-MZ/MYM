using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_alpha : MonoBehaviour
{

    public string sceneName;    //ì«Ç›çûÇﬁÉVÅ[Éìñº

    public void Lord()
    {
        SceneManager.LoadScene(sceneName);
    }
}
