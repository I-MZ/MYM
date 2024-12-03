using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//別シーンに行っても音が途切れないようにする
//タイトル・ステージの音は別

public class LoopBGM : MonoBehaviour
{
	static public LoopBGM instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}

	}

	public AudioSource TitleBGM;
	public AudioSource StageBGM;

    private string beforeScene;//string型の変数beforeSceneを宣言 

    void Start()
    {
        beforeScene = "Title";//起動時のシーン名 を代入しておく
        TitleBGM.Play();//A_BGMのAudioSourceコンポーネントに割り当てたAudioClipを再生

        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }




    //シーンが切り替わった時に呼ばれるメソッド　
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //シーンがどう変わったかで判定
        //タイトル・セレクトシーンからステージシーンへ
        if (beforeScene == "Title" || beforeScene == "StageSelect" &&
            nextScene.name != "title" || nextScene.name != "StageSelect")
        {
            TitleBGM.Play();
            StageBGM.Stop();
            Debug.Log("タイトルBGMが流れています。");
        }

        // ステージシーンからタイトル・セレクトシーンへ
        if (beforeScene != "Title" || beforeScene != "StageSelect" &&
            nextScene.name == "title" || nextScene.name == "StageSelect")
        {
            StageBGM.Play();
            TitleBGM.Stop();
            Debug.Log("ステージBGMが流れています。");
        }

        //遷移後のシーン名を「１つ前のシーン名」として保持
        beforeScene = nextScene.name;
    }
}