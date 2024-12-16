using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody2D rbody;                   //Rigidbody2D�^�̕ϐ�
    SpriteRenderer sr;
    public float movespeed = 5.0f;       //�ړ����x
    private float inputH = 0.0f;         //������
    private float inputV = 0.0f;         //�c����
    public float fallspead = 10.0f;       //�������x
    public int startgravity = 0;
    public int gravity = 0;             //�d�͂̌���(0=��,1=��,2=�E,3=��)
    public bool forcepower = false;      //�d�͋���
    private bool checkchange = false;
    bool onWall = false;                 //��(��)�ɏ���Ă��邩

    public bool crevice = false;                //�ό`���Ȃ��ƒʂ�Ȃ��ꏊ�ɂ��邩

    private float cla;                   //�����x
    private float clarespeed = 0.01f;    //�ω����x
    public float spawnpointX = 0.0f;     //�����ʒu(X��)
    public float spawnpointY = 0.0f;     //�����ʒu(Y��)
    public float CpSpawnpointX = 0.0f;
    public float CpSpawnpointY = 0.0f;
    private CircleCollider2D cc2;
    private PolygonCollider2D pc2;
    private bool hitwall = true;

    private bool returnfolm;

    private bool checkpoint;

    public static string gameState = "playing";
    public LayerMask wallLayer;

    Animator animator;
    public string henkeianime = "player-HENKEI";
    public string modorianime = "player-HUKUGEN";
    public string tuujouanime = "player-TUUZYOU";

    string nowanime = "";
    string oldanime = "";

    //SE
    [Header("�ό`���鎞�ɖ炷SE")] public AudioClip HENKEI;
    [Header("���n�������ɖ炷SE")] public AudioClip TYAKUTI;
    [Header("�_���[�W���󂯂����ɖ炷SE")] public AudioClip DAMEZI;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D������Ă���
        sr = GetComponent<SpriteRenderer>();
        cc2 = GetComponent<CircleCollider2D>();
        pc2 = GetComponent<PolygonCollider2D>();
        gameState = "playing";
        cc2.enabled = true;
        pc2.enabled = false;
        animator = GetComponent<Animator>();
        nowanime = tuujouanime;
        oldanime = tuujouanime;
        checkpoint = false;
        gravity = startgravity;
        returnfolm = false;

        instance = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing" || SceneChenger.gameState != "playing")
        {
            return;
        }

        MoveUpdate();
        ChangeGravity();

        if (Input.GetKeyDown(KeyCode.K))
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        if (gameState != "playing" || SceneChenger.gameState != "playing")
        {
            return;
        }

        if (forcepower)
        {
            pc2.enabled = true;
            nowanime = henkeianime;
            cc2.enabled = false;
            rbody.freezeRotation = true;
            returnfolm = true;
        }

        //�d�͂ɂ�闎������(���A��A�E�A��)
        switch (gravity)
        {
            case 0://��
                onWall = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.down,
                                                   0.5f,
                                                   wallLayer);

                

                rbody.velocity = new Vector2(0, fallspead * -1);

                if (forcepower)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                break;

            case 1://��
                onWall = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.up,
                                                   0.5f,
                                                   wallLayer);

                rbody.velocity = new Vector2(0, fallspead);

                if (forcepower)
                {
                    transform.eulerAngles = new Vector3(0, 0, 180);
                }

                break;

            case 2://�E
                onWall = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.right,
                                                   0.5f,
                                                   wallLayer);

                rbody.velocity = new Vector2(fallspead, 0);

                if (forcepower)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }

                break;

            case 3://��
                onWall = Physics2D.CircleCast(transform.position,
                                                  0.1f,
                                                  Vector2.left,
                                                  0.5f,
                                                  wallLayer);

                rbody.velocity = new Vector2(fallspead * -1, 0);

                if (forcepower)
                {
                    transform.eulerAngles = new Vector3(0, 0, 270);
                }

                break;
        }

        ////�����Ă�Ƃ��͉�]���Ȃ�
        //if (!onWall)
        //{
        //    rbody.freezeRotation = true;
        //}

        if (onWall)
        {
            if (gravity == 0 || gravity == 1)
            {
                rbody.velocity = new Vector2(movespeed * inputH, rbody.velocity.y);
            }
            else
            {
                rbody.velocity = new Vector2(rbody.velocity.x, movespeed * inputV);
            }


            //�ό`����
            if (!forcepower)
            {
                if (returnfolm)
                {
                    switch (gravity)
                    {
                        case 0://��
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z);
                            break;
                        case 1://��
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, this.transform.position.z);
                            break;
                        case 2://��
                            this.transform.position = new Vector3(this.transform.position.x - 0.25f, this.transform.position.y, this.transform.position.z);
                            break;
                        case 3://��
                            this.transform.position = new Vector3(this.transform.position.x + 0.25f, this.transform.position.y, this.transform.position.z);
                            break;
                    }

                    returnfolm = false;
                }

                cc2.enabled = true;
                nowanime = modorianime;
                pc2.enabled = false;
                rbody.freezeRotation = false;
                crevice = false;
            }

            if (!hitwall)
            {
                GameManager.instance.PlaySE(TYAKUTI);
                Debug.Log("���炵��");
                hitwall = true;
            }
        }
        else
        {
            hitwall = false;
        }

        if (nowanime != oldanime && checkchange)
        {
            oldanime = nowanime;
            animator.Play(nowanime);
            GameManager.instance.PlaySE(HENKEI);
        }


        if (forcepower)
        {
            switch (gravity)
            {
                case 0://��
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.up,
                                                   0.5f,
                                                   wallLayer);


                    if (crevice == true)
                    {
                        if (Input.GetKey(KeyCode.DownArrow))
                        {
                            Debug.Log("���ό`�s��");
                        }


                    }

                    break;

                case 1://��
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.down,
                                                   0.5f,
                                                   wallLayer);


                    if (crevice == true)
                    {
                        Debug.Log("��ό`�s��");
                    }

                    break;

                case 2://�E
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.left,
                                                   0.5f,
                                                   wallLayer);


                    if (crevice == true)
                    {
                        Debug.Log("�E�ό`�s��");
                    }

                    break;

                case 3://��
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.right,
                                                   0.5f,
                                                   wallLayer);

                    //rbody.velocity = new Vector2(fallspead * -1, 0);

                    if (crevice == true)
                    {
                        Debug.Log("���ό`�s��");
                    }

                    break;
            }
        }
    }

    void MoveUpdate()
    {
        // �������ړ�����
        if (Input.GetKey(KeyCode.D))
        {// �E�����̈ړ�����
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                inputH = 1.0f;
            }
            else
            {
                inputH = 0.5f;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {// �������̈ړ�����
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                inputH = -1.0f;
            }
            else
            {
                inputH = -0.5f;
            }
        }
        else
        {// ���͂Ȃ�
            inputH = 0.0f;
        }

        // �c�����ړ�����
        if (Input.GetKey(KeyCode.W))
        {// ������̈ړ�����
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                inputV = 1.0f;
            }
            else
            {
                inputV = 0.5f;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {// �������̈ړ�����
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                inputV = -1.0f;
            }
            else
            {
                inputV = -0.5f;
            }
        }
        else
        {// ���͂Ȃ�
            inputV = 0.0f;
        }
    }


    void ChangeGravity()
    {
        //�d�͂̋���؂�ւ�
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity == 0 && !crevice)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity == 1 && !crevice)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity == 2 && !crevice)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity == 3 && !crevice)
        {
            PowChange();
        }

        //�d�͂̌����؂�ւ�
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity != 0)
        {
            if (gravity == 2 || gravity == 3)
            {
                gravity = 0;
                PowDown();
            }
            else
            {
                gravity = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity != 1)
        {
            if (gravity == 2 || gravity == 3)
            {
                gravity = 1;
                PowDown();
            }
            else
            {
                gravity = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity != 2)
        {
            if (gravity == 0 || gravity == 1)
            {
                gravity = 2;
                PowDown();
            }
            else
            {
                gravity = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity != 3)
        {
            if (gravity == 0 || gravity == 1)
            {
                gravity = 3;
                PowDown();
            }
            else
            {
                gravity = 3;
            }
        }



    }

    ////�ό`�^�C���}�b�v�ƃv���C���[�̐ڐG����
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "")
    //    {

    //    }
    //}

    //�d�͂̋���؂�ւ�
    void PowChange()
    {
        if (!forcepower)
        {
            PowUp();
        }
        else
        {
            PowDown();
        }
    }

    //�d��(��)
    void PowUp()
    {
        forcepower = true;
        checkchange = true;
    }
    //�d��(��)
    void PowDown()
    {
        forcepower = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            checkpoint = true;
        }
        //���S����
        if (collision.gameObject.tag == "Dead" && gameState == "playing")
        {
            Respawn();
        }
        //�S�[������
        if (collision.gameObject.tag == "Goal")
        {
            Clear();
        }


    }

    //��������
    void Respawn()
    {
        Debug.Log("���X�|�[�������J�n");
        if (gameState == "playing")
        {
            Debug.Log("���炷");
            GameManager.instance.PlaySE(DAMEZI);
        }

        gameState = "respawn";
        MoveStop();

        cla = sr.color.a;
        StartCoroutine(Display());
    }

    //�X�e�[�W�N���A
    void Clear()
    {
        gameState = "clear";
        MoveStop();
    }

    IEnumerator Display()
    {
        //���X�ɓ����ɂȂ�
        while (cla > 0f)
        {
            cla -= clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }

        if (!checkpoint)
        {
            transform.position = new Vector2(spawnpointX, spawnpointY);
        }
        else
        {
            transform.position = new Vector2(CpSpawnpointX, CpSpawnpointY);
        }

        rbody.velocity = new Vector2(0, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
        gravity = startgravity;
        PowDown();
        cc2.enabled = true;
        if (oldanime != tuujouanime)
        {
            nowanime = modorianime;
            oldanime = modorianime;
            animator.Play(nowanime);

        }
        pc2.enabled = false;

        //���X�Ɏ��̉�����
        while (cla < 1f)
        {
            cla += clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }

        rbody.freezeRotation = false;
        gameState = "playing";
    }

    void MoveStop()
    {
        rbody.velocity = new Vector2(0, 0);
        rbody.freezeRotation = true;
        Debug.Log("�v���C���[��~");
    }
}
