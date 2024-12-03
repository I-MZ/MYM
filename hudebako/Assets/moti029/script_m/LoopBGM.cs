using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�ʃV�[���ɍs���Ă������r�؂�Ȃ��悤�ɂ���
//�^�C�g���E�X�e�[�W�̉��͕�

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

    private string beforeScene;//string�^�̕ϐ�beforeScene��錾 

    void Start()
    {
        beforeScene = "Title";//�N�����̃V�[���� �������Ă���
        TitleBGM.Play();//A_BGM��AudioSource�R���|�[�l���g�Ɋ��蓖�Ă�AudioClip���Đ�

        //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h��o�^
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }




    //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h�@
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //�V�[�����ǂ��ς�������Ŕ���
        //�^�C�g���E�Z���N�g�V�[������X�e�[�W�V�[����
        if (beforeScene == "Title" || beforeScene == "StageSelect" &&
            nextScene.name != "title" || nextScene.name != "StageSelect")
        {
            TitleBGM.Play();
            StageBGM.Stop();
            Debug.Log("�^�C�g��BGM������Ă��܂��B");
        }

        // �X�e�[�W�V�[������^�C�g���E�Z���N�g�V�[����
        if (beforeScene != "Title" || beforeScene != "StageSelect" &&
            nextScene.name == "title" || nextScene.name == "StageSelect")
        {
            StageBGM.Play();
            TitleBGM.Stop();
            Debug.Log("�X�e�[�WBGM������Ă��܂��B");
        }

        //�J�ڌ�̃V�[�������u�P�O�̃V�[�����v�Ƃ��ĕێ�
        beforeScene = nextScene.name;
    }
}