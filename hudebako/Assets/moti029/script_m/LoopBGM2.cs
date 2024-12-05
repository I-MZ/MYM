using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoopBGM2 : MonoBehaviour
{

	public AudioSource TitleBGM;
	public AudioSource StageBGM;
	static public LoopBGM2 instance;
	public int BGMnum;
	public int BeforBGMnum;

	private void Start()
	{

	}
	private void Update()
	{
		if (SceneManager.GetActiveScene().name == "Title" ||
			SceneManager.GetActiveScene().name == "StageSelect")
		{
			BGMnum = 0;
		}

		if (SceneManager.GetActiveScene().name == "Stage1" ||
			SceneManager.GetActiveScene().name == "Stage2" ||
			SceneManager.GetActiveScene().name == "Stage3" ||
			SceneManager.GetActiveScene().name == "Stage4" ||
			SceneManager.GetActiveScene().name == "Stage5" ||
			SceneManager.GetActiveScene().name == "Stage6" ||
			SceneManager.GetActiveScene().name == "Stage7" ||
			SceneManager.GetActiveScene().name == "Stage8" ||
			SceneManager.GetActiveScene().name == "Stage9" ||
			SceneManager.GetActiveScene().name == "Stage10"  )
		{
			BGMnum = 1;
		}
		

	}
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);//シーン変更でオブジェクトが消えない
		}
		else
		{
			Destroy(this.gameObject);
		}

			if (BGMnum == 0)
			{
				TitleBGM.Play();
				StageBGM.Stop();
				Debug.Log("タイトルBGMが流れています。");
			}
			if (BGMnum == 1)
			{
				TitleBGM.Stop();
				StageBGM.Play();
				Debug.Log("ステージBGMが流れています。");
			}

	}
}

	