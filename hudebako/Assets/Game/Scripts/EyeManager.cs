using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManager : MonoBehaviour
{

    public Sprite Default_Eye;
    public Sprite HighPower_Eye;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Default_Eye;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.forcepower)
        {
            GetComponent<SpriteRenderer>().sprite = HighPower_Eye;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Default_Eye;
        }
    }
}
