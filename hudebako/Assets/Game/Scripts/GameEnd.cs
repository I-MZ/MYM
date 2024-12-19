using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject endpanel;

    [Header("���莞�ɖ炷SE")] public AudioClip enter;
    [Header("�L�����Z�����ɖ炷SE")] public AudioClip cancel;


    // Start is called before the first frame update
    void Start()
    {
        endpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PanelActivation();
        }
    }

    public void PanelActivation()
    {

        SceneChenger.instance.PlaySE(enter);
        endpanel.SetActive(true);

    }

    public void PanelDisabling()
    {

        SceneChenger.instance.PlaySE(cancel);
        endpanel.SetActive(false);

    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
