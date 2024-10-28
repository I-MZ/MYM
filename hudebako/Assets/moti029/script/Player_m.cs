using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	

	// オブジェクト・コンポーネント参照
	private Rigidbody2D rigidbody2D; // Rigidbody2Dコンポーネントへの参照

	// 移動関連変数
	private float xSpeed; // X方向移動速度

	// Start（オブジェクト有効化時に1度実行）
	void Start()
	{
		// コンポーネント参照取得
		rigidbody2D = GetComponent<Rigidbody2D>();

		//Sを押すとアクティブ(true)・非アクティブ(false)を切り替える
		//通常時がtrueなら変形はfalse

		//Sを押してこのオブジェクトがtrueならfalseにする
		if (Input.GetKeyDown(KeyCode.S) && this.gameObject ==true)
		{
			this.gameObject.SetActive(false);
		}
        else
        {
			this.gameObject.SetActive(true);
		}
		
		 //通常時がfalseなら変形はtrue


}

	// Update（1フレームごとに1度ずつ実行）
	void Update()
	{
		// 左右移動処理
		MoveUpdate();
	}


    /// <summary>
    /// Updateから呼び出される左右移動入力処理
    /// </summary>
    private void MoveUpdate()
	{
		// X方向移動入力
		if (Input.GetKey(KeyCode.D))
		{// 右方向の移動入力
		 // X方向移動速度をプラスに設定
			xSpeed = 6.0f;
		}
		else if (Input.GetKey(KeyCode.A))
		{// 左方向の移動入力
		 // X方向移動速度をマイナスに設定
			xSpeed = -6.0f;
		}
		else
		{// 入力なし
		 // X方向の移動を停止
			xSpeed = 0.0f;
		}

	}




	// FixedUpdate（一定時間ごとに1度ずつ実行・物理演算用）
	private void FixedUpdate()
	{
		// 移動速度ベクトルを現在値から取得
		Vector2 velocity = rigidbody2D.velocity;
		// X方向の速度を入力から決定
		velocity.x = xSpeed;

		// 計算した移動速度ベクトルをRigidbody2Dに反映
		rigidbody2D.velocity = velocity;
	}


}
