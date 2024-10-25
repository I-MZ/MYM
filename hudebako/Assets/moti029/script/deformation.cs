using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deformation : MonoBehaviour
{
    [SerializeField] public GameObject targetGameObject1; //通常オブジェクトを入れる
    [SerializeField] public GameObject targetGameObject2; //変形オブジェクトを入れる

    //bool onWall = false;            //床(壁)に乗っているか

    // Start is called before the first frame update
    void Start()
    {
        targetGameObject2.SetActive(false);//変形オブジェクトは消しておく
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


    void Deformation()//変形
    { 
    //今くっついている壁の下側に向かって矢印キーを押す
        //playerがactiveなのか調べる
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
