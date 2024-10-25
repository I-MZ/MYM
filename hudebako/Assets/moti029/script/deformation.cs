using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deformation : MonoBehaviour
{
    [SerializeField] public GameObject targetGameObject1; //�ʏ�I�u�W�F�N�g������
    [SerializeField] public GameObject targetGameObject2; //�ό`�I�u�W�F�N�g������

    //bool onWall = false;            //��(��)�ɏ���Ă��邩

    // Start is called before the first frame update
    void Start()
    {
        targetGameObject2.SetActive(false);//�ό`�I�u�W�F�N�g�͏����Ă���
    }

    // Update is called once per frame
    void Update()
    {
        Deformation();

        if (targetGameObject1.activeInHierarchy)
        {
            targetGameObject2.transform.position = targetGameObject1.transform.position;
        }
        if (targetGameObject2.activeInHierarchy)
        {
            targetGameObject1.transform.position = targetGameObject2.transform.position;
        }

    }

    void main()
    {
       
    }


    void Deformation()//�ό`
    { 
    //���������Ă���ǂ̉����Ɍ������Ė��L�[������
        //player��active�Ȃ̂����ׂ�
        if (Input.GetKeyDown(KeyCode.DownArrow) && targetGameObject1.activeInHierarchy)
        {
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && targetGameObject2.activeInHierarchy)
        {
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
            return;
        }
           
    }
}
