using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReturnRuler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�v���C���[�ƂԂ�������
        if (collision.gameObject.name == "Player")
        {
            //���݂̈ʒu���擾
            Vector3 Repos = this.gameObject.transform.position;
        }
        
    }
    


}
