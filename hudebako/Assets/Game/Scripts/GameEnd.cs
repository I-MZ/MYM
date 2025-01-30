using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject endpanel;

    public static string GameState = "";

    [Header("���莞�ɖ炷SE")] public AudioClip enter;
    [Header("�L�����Z�����ɖ炷SE")] public AudioClip cancel;


    // Start is called before the first frame update
    void Start()
    {
        GameState = "playing";

        endpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!endpanel.activeSelf)
            {
                PanelActivation();
            }
            else
            {
                PanelDisabling();
            }

        }
    }

    public void PanelActivation()
    {

        SceneChenger.instance.PlaySE(enter);
        endpanel.SetActive(true);

        GameState = "endmode";

    }

    public void PanelDisabling()
    {

        SceneChenger.instance.PlaySE(cancel);
        endpanel.SetActive(false);

        GameState = "playing";

    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
