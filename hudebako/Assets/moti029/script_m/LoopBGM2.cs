using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoopBGM2 : MonoBehaviour
{
	static public LoopBGM2 instance;

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

		//ここまで

	if (SceneManager.GetActiveScene().name == "Title" ||
		SceneManager.GetActiveScene().name == "StageSelect")
			{
				TitleBGM.Play();
				StageBGM.Stop();
				Debug.Log("タイトルBGMが流れています。");
			}
	if (SceneManager.GetActiveScene().name != "Title" ||
		SceneManager.GetActiveScene().name != "StageSelect")
		{
				StageBGM.Play();
				TitleBGM.Stop();
				Debug.Log("ステージBGMが流れています。");
			}
	}

	
	public AudioSource TitleBGM;
	public AudioSource StageBGM;



    private void Update()
    {

		

	}
}
