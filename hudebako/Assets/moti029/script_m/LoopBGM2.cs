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

	public int BGMnum;//0:�^�C�g��BGM�@1:�X�e�[�WBGM
	public int index;

	private void Start()//�ŏ��̈��̂�
	{
		BGMPlay();
		//SceneManager.activeSceneChanged += ActiveSceneChanged;

		
		//0:�^�C�g�� 1�`10:�X�e�[�W 11:�X�e�[�W�Z���N�g

		// �A�N�e�B�u�V�[���̐؂�ւ�
		//Scene scene = SceneManager.GetSceneByName("Scene_B");
		// SceneManager.SetActiveScene(scene);
	}
    void BGMSerect()
    {
		//�^�C�g�����X�e�[�W�V�[���̂ǂ��炩�ɂ��鎞
		if (index == 0 || index == 11)
        {
			NewBGM = 0;
        }

		//�X�e�[�W�V�[���ɂ��鎞
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

		private void Update()//���t���[���Ăяo�����
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
	private void Awake()//�ŏ��̈��̂�
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);//�V�[���ύX�ŃI�u�W�F�N�g�������Ȃ�
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
			Debug.Log("�^�C�g��BGM������Ă��܂��B");
		}
		if (NewBGM == 1)
		{
			StageBGM.Play();
			TitleBGM.Stop();
			Debug.Log("�X�e�[�WBGM������Ă��܂��B");
		}

    }

	

}

	