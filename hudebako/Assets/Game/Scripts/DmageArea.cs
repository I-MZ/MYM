using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmageArea : MonoBehaviour
{

    public GameObject DefaultImg;
    public GameObject AnotherImg;

    // Start is called before the first frame update
    void Start()
    {
        AnotherImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.instance.forcepower)
        {
            DefaultImg.SetActive(true);
            AnotherImg.SetActive(false);
        }
        else
        {
            DefaultImg.SetActive(false);
            AnotherImg.SetActive(true);
        }
    }
}
