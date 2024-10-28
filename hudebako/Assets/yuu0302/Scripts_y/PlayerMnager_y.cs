using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMnager_y : MonoBehaviour
{
    [SerializeField] public GameObject PlayerObject; //�ʏ�I�u�W�F�N�g������
    [SerializeField] public GameObject MiniPlayerObject; //�ό`�I�u�W�F�N�g������

    PlayerController_y P_script;
    MiniPlayerController_y MP_script;


    public static string gameState = "gravity_down";

    //bool onWall = false;            //��(��)�ɏ���Ă��邩

    // Start is called before the first frame update
    void Start()
    {
        P_script = PlayerObject.GetComponent<PlayerController_y>();
        MP_script = MiniPlayerObject.GetComponent<MiniPlayerController_y>();

        MiniPlayerObject.SetActive(false);//�ό`�I�u�W�F�N�g�͏����Ă���
        gameState = "gravity_down";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow) && gameState == "gravity_down" && (P_script.onWall || MP_script.onWall))
        {
            Deformation();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && gameState == "gravity_up" && (P_script.onWall || MP_script.onWall))
        {
            Deformation();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && gameState == "gravity_right" && (P_script.onWall || MP_script.onWall))
        {
            Deformation();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameState == "gravity_left" && (P_script.onWall || MP_script.onWall))
        {
            Deformation();
        }



       

        if (PlayerObject.activeInHierarchy)
        {
            MiniPlayerObject.transform.position = PlayerObject.transform.position;
        }
        if (MiniPlayerObject.activeInHierarchy)
        {
            PlayerObject.transform.position = MiniPlayerObject.transform.position;
        }

        ChangeGravity();




    }

    void ChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && (P_script.onWall || MP_script.onWall))
        {
            gameState = "gravity_down";
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (P_script.onWall || MP_script.onWall))
        {
            gameState = "gravity_up";
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && (P_script.onWall || MP_script.onWall))
        {
            gameState = "gravity_right";
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (P_script.onWall || MP_script.onWall))
        {
            gameState = "gravity_left";
        }

        if(PlayerController_y.gameState == "respawn" || MiniPlayerController_y.gameState == "respawn")
        {
            gameState = "gravity_down";
        }

    }

    void Deformation()//�ό`
    { 
    //���������Ă���ǂ̉����Ɍ������Ė��L�[������
        //player��active�Ȃ̂����ׂ�
        if (PlayerObject.activeInHierarchy)
        {
            MP_script.onWall = true;
            MiniPlayerObject.SetActive(true);
            PlayerObject.SetActive(false);
            P_script.onWall = false;

        }
        else if (MiniPlayerObject.activeInHierarchy)
        {
            P_script.onWall = true;
            PlayerObject.SetActive(true);
            MiniPlayerObject.SetActive(false);
            MP_script.onWall = false;
        }
           
    }
}
