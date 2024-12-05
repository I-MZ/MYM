using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChenger : MonoBehaviour
{
    Image sr;
    private float cla;                   //透明度
    private float clarespeed = 0.02f;    //変化速度

    private bool fadein = true;

    private int scenenum;
    private int selectscene;

    [Header("決定時に鳴らすSE")] public AudioClip enter;

    // Start is called before the first frame update
    void Start()
    {
        selectscene = 11;
        sr = GetComponent<Image>();
        cla = sr.color.a;
        StartCoroutine(FadeIn());
    }

    public void NextScene()
    {
        StartCoroutine(FadeOut((SceneManager.GetActiveScene().buildIndex) + 1));
    }

    public void ChangeScene(int n)
    {
        if (n <= StageClearManager.clearlevel + 1)
            StartCoroutine(FadeOut(n));
    }

    public void ReloadScene()
    {
        if (PlayerController.gameState != "retry")
            StartCoroutine(FadeOut(SceneManager.GetActiveScene().buildIndex));
    }

    public void ReturnSelect()
    {
        if (PlayerController.gameState != "retry")
            StartCoroutine(FadeOut(selectscene));
    }

    public IEnumerator FadeIn()
    {
        cla = sr.color.a;
        while (cla > 0f && fadein)
        {
            cla -= clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            Debug.Log("sr.color = " + sr.color.a);
            yield return null;
        }

        Time.timeScale = 1;
    }

    public IEnumerator FadeOut(int i)
    {
        fadein = false;
        Time.timeScale = 0;

        if (PlayerController.gameState != null)
            PlayerController.gameState = "retry";

        if (GameManager.instance != null)
            GameManager.instance.PlaySE(enter);

        scenenum = i;

        cla = sr.color.a;
        while (cla < 1f)
        {
            cla += clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }

        SceneManager.LoadScene(scenenum);
    }
}
