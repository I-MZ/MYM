using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrowMove : MonoBehaviour
{
    [SerializeField] public GameObject UpSelectObject;//è„ÇÃñÓàÛ
    [SerializeField] public GameObject DownSelectObject;//â∫ÇÃéläp

    private float MY = 0.0f;//è„â∫íl

    void UpSelectObject_Move()//è„ñÓàÛ
    {
        UpSelectObject.SetActive(true);
    }

    void DownSelectObject_Move()//â∫éläp
    {
        DownSelectObject.SetActive(true);
    }

}
