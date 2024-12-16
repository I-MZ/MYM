using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityChecker : MonoBehaviour
{
    Image Img;

    public Sprite ArrowDown;
    public Sprite ArrowUp;
    public Sprite ArrowRight;
    public Sprite ArrowLeft;

    // Start is called before the first frame update
    void Start()
    {
        Img = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance != null)
        {
            switch (PlayerController.instance.gravity) 
            {
                case 0://â∫
                    Img.sprite = ArrowDown;
                    break;
                case 1://è„
                    Img.sprite = ArrowUp;
                    break;
                case 2://âE
                    Img.sprite = ArrowRight;
                    break;
                case 3://ç∂
                    Img.sprite = ArrowLeft;
                    break;
            }

            if (PlayerController.instance.forcepower)
            {
                Img.color = new Color(0.7f, 0.7f, 0.7f);
            }
            else
            {
                Img.color = new Color(1, 1, 1);
            }
        }
    }
}
