using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの変更などを制御する関数
/// </summary>
public class SceneChenger : MonoBehaviour
{
    public static SceneChenger instance = null;

    Image sr;
    private float cla;                      //透明度
    private float clarespeed = 0.03f;       //変化速度

    private bool fadein = true;             //フェードイン/フェードアウト切り替え

    private int scenenum;                   //切り替え先のシーンのビルドインデックス
    private int selectscene = 11;           //ステージセレクトのビルドインデックス

    public static string gameState = "";    //フェードイン/フェードアウト中かどうか

    private bool SceneChange;
    private bool Gameend;

    public static bool doRetry = false;

    private AudioSource audioSource = null; //

    public AudioClip Decide;                 //決定時に鳴らすSE

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<SceneChenger>();

        SceneChange = false;
        Gameend = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gameState = "loading";
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<Image>();
        cla = sr.color.a;
        StartCoroutine(FadeIn());
    }

    private void Update()
    {
        if (SceneChange)
        {
            SceneManager.LoadScene(scenenum);
        }
    }

    public void NextScene()
    {
        PlaySE(Decide);
        StartCoroutine(FadeOut((SceneManager.GetActiveScene().buildIndex) + 1));
    }

    public void ChangeScene(int n)
    {
        if (gameState != "loading" && n <= StageClearManager.clearlevel + 1)
        {
            PlaySE(Decide);
            StartCoroutine(FadeOut(n));
        }
        else if (n == 12 && StageClearManager.clearlevel >= 10)
        {
            StartCoroutine(FadeOut(n));
        }
        else
        {

        }
            
    }

    public void ReloadScene()
    {
        if (gameState != "loading")
        {
            doRetry = true;
            PlaySE(Decide);
            StartCoroutine(FadeOut(SceneManager.GetActiveScene().buildIndex));
        }
    }

    public void ReturnSelect()
    {
        if (gameState != "loading")
        {
            PlaySE(Decide);
            StartCoroutine(FadeOut(selectscene));
        }
            
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
        doRetry = false;
        gameState = "playing";
        Time.timeScale = 1;
    }

    public IEnumerator FadeOut(int i = -1)
    {
        fadein = false;
        Time.timeScale = 0;

        gameState = "loading";

        if (i != -1)
            scenenum = i;
        else
            Gameend = true;

        cla = sr.color.a;
        while (cla < 1f)
        {
            cla += clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }

        if (!Gameend)
            SceneChange = true;
        else
            Application.Quit();
    }

    public void Quit()
    {
        PlaySE(Decide);
        StartCoroutine(FadeOut());
    }

    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("audioSource == null");
        }
    }

    
}
