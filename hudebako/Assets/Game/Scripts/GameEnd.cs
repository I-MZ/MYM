using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject endpanel;
    public GameObject Explanation;
    private ExplanationManager ExplanationMng;

    public static string GameState = "";

    [Header("決定時に鳴らすSE")] public AudioClip enter;
    [Header("キャンセル時に鳴らすSE")] public AudioClip cancel;


    // Start is called before the first frame update
    void Start()
    {
        GameState = "playing";

        ExplanationMng = Explanation.GetComponent<ExplanationManager>();

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

        ExplanationMng.TextChange();

        GameState = "endmode";

    }

    public void PanelDisabling()
    {

        SceneChenger.instance.PlaySE(cancel);
        endpanel.SetActive(false);

        ExplanationMng.TextChange();

        GameState = "playing";

    }

}
