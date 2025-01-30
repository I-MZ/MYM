using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject endpanel;

    public static string GameState = "";

    [Header("Œˆ’èŽž‚É–Â‚ç‚·SE")] public AudioClip enter;
    [Header("ƒLƒƒƒ“ƒZƒ‹Žž‚É–Â‚ç‚·SE")] public AudioClip cancel;


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
