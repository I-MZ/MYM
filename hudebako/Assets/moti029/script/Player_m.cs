using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	

	// �I�u�W�F�N�g�E�R���|�[�l���g�Q��
	private Rigidbody2D rigidbody2D; // Rigidbody2D�R���|�[�l���g�ւ̎Q��

	// �ړ��֘A�ϐ�
	private float xSpeed; // X�����ړ����x

	// Start�i�I�u�W�F�N�g�L��������1�x���s�j
	void Start()
	{
		// �R���|�[�l���g�Q�Ǝ擾
		rigidbody2D = GetComponent<Rigidbody2D>();

		//S�������ƃA�N�e�B�u(true)�E��A�N�e�B�u(false)��؂�ւ���
		//�ʏ펞��true�Ȃ�ό`��false

		//S�������Ă��̃I�u�W�F�N�g��true�Ȃ�false�ɂ���
		if (Input.GetKeyDown(KeyCode.S) && this.gameObject ==true)
		{
			this.gameObject.SetActive(false);
		}
        else
        {
			this.gameObject.SetActive(true);
		}
		
		 //�ʏ펞��false�Ȃ�ό`��true


}

	// Update�i1�t���[�����Ƃ�1�x�����s�j
	void Update()
	{
		// ���E�ړ�����
		MoveUpdate();
	}


    /// <summary>
    /// Update����Ăяo����鍶�E�ړ����͏���
    /// </summary>
    private void MoveUpdate()
	{
		// X�����ړ�����
		if (Input.GetKey(KeyCode.D))
		{// �E�����̈ړ�����
		 // X�����ړ����x���v���X�ɐݒ�
			xSpeed = 6.0f;
		}
		else if (Input.GetKey(KeyCode.A))
		{// �������̈ړ�����
		 // X�����ړ����x���}�C�i�X�ɐݒ�
			xSpeed = -6.0f;
		}
		else
		{// ���͂Ȃ�
		 // X�����̈ړ����~
			xSpeed = 0.0f;
		}

	}




	// FixedUpdate�i��莞�Ԃ��Ƃ�1�x�����s�E�������Z�p�j
	private void FixedUpdate()
	{
		// �ړ����x�x�N�g�������ݒl����擾
		Vector2 velocity = rigidbody2D.velocity;
		// X�����̑��x����͂��猈��
		velocity.x = xSpeed;

		// �v�Z�����ړ����x�x�N�g����Rigidbody2D�ɔ��f
		rigidbody2D.velocity = velocity;
	}


}
