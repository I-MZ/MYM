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
			DontDestroyOnLoad(this.gameObject);//�V�[���ύX�ŃI�u�W�F�N�g�������Ȃ�
		}
		else
		{
			Destroy(this.gameObject);
		}

		//�����܂�

	if (SceneManager.GetActiveScene().name == "Title" ||
		SceneManager.GetActiveScene().name == "StageSelect")
			{
				TitleBGM.Play();
				StageBGM.Stop();
				Debug.Log("�^�C�g��BGM������Ă��܂��B");
			}
	if (SceneManager.GetActiveScene().name != "Title" ||
		SceneManager.GetActiveScene().name != "StageSelect")
		{
				StageBGM.Play();
				TitleBGM.Stop();
				Debug.Log("�X�e�[�WBGM������Ă��܂��B");
			}
	}

	
	public AudioSource TitleBGM;
	public AudioSource StageBGM;



    private void Update()
    {

		

	}
}
