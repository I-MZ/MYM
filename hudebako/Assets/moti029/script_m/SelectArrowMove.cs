using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrowMove : MonoBehaviour
{
    [SerializeField] public GameObject UpSelectObject;//��̖��
    [SerializeField] public GameObject DownSelectObject;//���̎l�p

    private float MY = 0.0f;//�㉺�l

    void UpSelectObject_Move()//����
    {
        UpSelectObject.SetActive(true);
    }

    void DownSelectObject_Move()//���l�p
    {
        DownSelectObject.SetActive(true);
    }

}
