using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject UI;

    public GameObject clearpanel;
    public GameObject menupanel;
    public GameObject resetButton;
    public GameObject menuButton;

    public GameObject timer;
    public GameObject timeText;


    public GameObject Explanation;


    TimeController timeCnt;

    float time_s = 0;
    int time_m = 0;

    public GameObject fade;
    private SceneChenger ScCanger;

    public GameObject stagenum;

    private AudioSource audioSource = null;

    [Header("決定時に鳴らすSE")] public AudioClip Decide;
    [Header("キャンセル時に鳴らすSE")] public AudioClip Cancel;

    private bool Uihidden;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        clearpanel.SetActive(false);
        menupanel.SetActive(false);

        Uihidden = false;

        timeCnt = GetComponent<TimeController>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f || SceneManager.GetActiveScene().buildIndex > StageClearManager.clearlevel)
            {
                timer.SetActive(false);
            }
        }

        ScCanger = fade.GetComponent<SceneChenger>();

        stagenum.GetComponent<Text>().text = "ステージ" + SceneManager.GetActiveScene().buildIndex;

        instance = GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerController.gameState == "clear")
        {//ステージクリア
            clearpanel.SetActive(true);
            Button rbt = resetButton.GetComponent<Button>();
            rbt.interactable = false;
            Button mbt = menuButton.GetComponent<Button>();
            mbt.interactable = false;

            if (StageClearManager.clearlevel < SceneManager.GetActiveScene().buildIndex)
            {
                StageClearManager.clearlevel = SceneManager.GetActiveScene().buildIndex;
                Debug.Log("clearlevel = " + StageClearManager.clearlevel);

            }

            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;
            }
        }
        else if (PlayerController.gameState == "playing" || PlayerController.gameState == "respawn") 
        {//プレイ中

            if (timeCnt != null)
            {
                if (timeCnt.gameTime > 0.0f)
                {
                    time_s += timeCnt.f_time;
                    
                    if (time_s >= 60.0f)
                    {
                        time_m++;
                        time_s -= 60.0f;
                    }
                    timeText.GetComponent<Text>().text = time_m.ToString() + ":" + time_s.ToString("00.00");
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && SceneChenger.gameState != "pause")
            {
                ScCanger.ReloadScene();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (MenuManager.instance.Menu.activeInHierarchy)
                {
                    ResumeGame();
                }
                else if (!menupanel.activeInHierarchy)
                {
                    PauseGame();
                }
            }

            
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (!Uihidden)
                UiHidden();
            else
                UiDisplay();
        }

        if (Input.GetKeyDown(KeyCode.F10))
        {
            DebugMode();
        }
        
       
        
       
    }

    public void PauseGame()
    {
        if (SceneChenger.gameState != "loading")
        {
            PlaySE(Decide);
            Time.timeScale = 0;
            menupanel.SetActive(true);
            Button rbt = resetButton.GetComponent<Button>();
            rbt.interactable = false;
            Button mbt = menuButton.GetComponent<Button>();
            mbt.interactable = false;
            SceneChenger.gameState = "pause";
        }
        
    }

    public void ResumeGame()
    {
        PlaySE(Cancel);

        if(CursorController.instance.select1!=null&& CursorController.instance.select1.activeInHierarchy)
        {
            CursorController.instance.SetCursorPos(CursorController.instance.select1);

            CursorController.instance.cursor_num = 1;
        }
        else
        {
            CursorController.instance.SetCursorPos(CursorController.instance.select5);

            CursorController.instance.cursor_num = 5;
        }

        Time.timeScale = 1;
        clearpanel.SetActive(false);
        menupanel.SetActive(false);
        Button rbt = resetButton.GetComponent<Button>();
        rbt.interactable = true;
        Button mbt = menuButton.GetComponent<Button>();
        mbt.interactable = true;
        SceneChenger.gameState = "playing";
    }

    //SEを鳴らす
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

    private void UiHidden()
    {
        UI.SetActive(false);

        Uihidden = true;
    }

    private void UiDisplay()
    {
        UI.SetActive(true);

        Uihidden = false;
    }

    private void DebugMode()
    {
        StageClearManager.clearlevel = 10;
    }
}
