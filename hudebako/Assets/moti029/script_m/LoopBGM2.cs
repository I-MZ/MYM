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

	public int NewBGM=0;
	public int OldBGM=0;

	public int BGMnum;//0:タイトルBGM　1:ステージBGM
	public int index;

	private void Start()//最初の一回のみ
	{
		BGMPlay();
		//SceneManager.activeSceneChanged += ActiveSceneChanged;

		
		//0:タイトル 1～10:ステージ 11:ステージセレクト

		// アクティブシーンの切り替え
		//Scene scene = SceneManager.GetSceneByName("Scene_B");
		// SceneManager.SetActiveScene(scene);
	}
    void BGMSerect()
    {
		//タイトルかステージシーンのどちらかにいる時
		if (index == 0 || index == 11)
        {
			NewBGM = 0;
        }

		//ステージシーンにいる時
		if (index == 1 || index == 2||
			index == 3 || index == 4||
			index == 5 || index == 6||
			index == 7 || index == 8||
			index == 9 || index == 10)
		{
			NewBGM = 1;
		}

        if (OldBGM != NewBGM)
        {
			OldBGM = NewBGM;
			BGMPlay();
		}
			
    }

		private void Update()//毎フレーム呼び出される
	{
		index = SceneManager.GetActiveScene().buildIndex;

		BGMSerect();
		//if (SceneManager.GetActiveScene().name == "Title" ||
		//	SceneManager.GetActiveScene().name == "StageSelect")
		//{
		//	BGMnum = 0;
		//}

		//if (SceneManager.GetActiveScene().name == "Stage1" ||
		//	SceneManager.GetActiveScene().name == "Stage2" ||
		//	SceneManager.GetActiveScene().name == "Stage3" ||
		//	SceneManager.GetActiveScene().name == "Stage4" ||
		//	SceneManager.GetActiveScene().name == "Stage5" ||
		//	SceneManager.GetActiveScene().name == "Stage6" ||
		//	SceneManager.GetActiveScene().name == "Stage7" ||
		//	SceneManager.GetActiveScene().name == "Stage8" ||
		//	SceneManager.GetActiveScene().name == "Stage9" ||
		//	SceneManager.GetActiveScene().name == "Stage10")
		//{
		//	BGMnum = 1;
		//}


	}
	private void Awake()//最初の一回のみ
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
	}

	public void BGMPlay()
    {
		if (NewBGM == 0)
		{
			TitleBGM.Play();
			StageBGM.Stop();
			Debug.Log("タイトルBGMが流れています。");
		}
		if (NewBGM == 1)
		{
			StageBGM.Play();
			TitleBGM.Stop();
			Debug.Log("ステージBGMが流れています。");
		}

    }

	

}

	