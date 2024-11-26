using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject clearpanel;
    public GameObject menupanel;
    public GameObject resetButton;
    public GameObject menuButton;

    public GameObject timer;
    public GameObject timeText;
    TimeController timeCnt;

    float time_s = 0;
    int time_m = 0;

    public GameObject stagenum;

    private AudioSource audioSource = null;

    [Header("決定時に鳴らすSE")] public AudioClip KETTEI;
    [Header("キャンセル時に鳴らすSE")] public AudioClip KYANSERU;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        clearpanel.SetActive(false);
        menupanel.SetActive(false);

        timeCnt = GetComponent<TimeController>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f)
            {
                timer.SetActive(false);
            }
        }

        stagenum.GetComponent<Text>().text = "ステージ" + SceneManager.GetActiveScene().buildIndex;

        instance = GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerController.gameState == "clear")
        {
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
        {

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

            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                if (!menupanel.activeInHierarchy)
                    PauseGame();
                else
                    ResumeGame();
            }
        }

        
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void PauseGame()
    {
        PlaySE(KETTEI);
        Time.timeScale = 0;
        menupanel.SetActive(true);
        Button rbt = resetButton.GetComponent<Button>();
        rbt.interactable = false;
        Button mbt = menuButton.GetComponent<Button>();
        mbt.interactable = false;
    }

    public void ResumeGame()
    {
        PlaySE(KYANSERU);
        Time.timeScale = 1;
        clearpanel.SetActive(false);
        menupanel.SetActive(false);
        Button rbt = resetButton.GetComponent<Button>();
        rbt.interactable = true;
        Button mbt = menuButton.GetComponent<Button>();
        mbt.interactable = true;
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

    public void Restart()
    {
        PlaySE(KETTEI);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
