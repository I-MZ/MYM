using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2Då^ÇÃïœêî
    public float fallspead = 1.0f;  //óéâ∫ë¨ìx
    public int gravity = 0;         //èdóÕÇÃå¸Ç´(0=â∫,1=è„,2=âE,3=ç∂)
    bool onWall = false;            //è∞(ï«)Ç…èÊÇ¡ÇƒÇ¢ÇÈÇ©

    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2DÇéÊÇ¡ÇƒÇ≠ÇÈ
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall)
        {
            gravity = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall)
        {
            gravity = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall)
        {
            gravity = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall)
        {
            gravity = 3;
        }


    }

    void FixedUpdate()
    {
        if (gravity == 0)
        {
             onWall = Physics2D.CircleCast(transform.position,
                                               0.1f,
                                               Vector2.down,
                                               0.5f,
                                               wallLayer);
            if (!onWall)
            {
                rbody.velocity = new Vector2(0, fallspead * -1);
            }
        }
        if (gravity == 1)
        {
            onWall = Physics2D.CircleCast(transform.position,
                                               0.1f,
                                               Vector2.up,
                                               0.5f,
                                               wallLayer);
            if (!onWall)
            {
                rbody.velocity = new Vector2(0, fallspead);
            }
        }
        if (gravity == 2)
        {
            onWall = Physics2D.CircleCast(transform.position,
                                               0.1f,
                                               Vector2.right,
                                               0.5f,
                                               wallLayer);
            if (!onWall)
            {
                rbody.velocity = new Vector2(fallspead, 0);
            }
        }
        if (gravity == 3)
        {
             onWall = Physics2D.CircleCast(transform.position,
                                               0.1f,
                                               Vector2.left,
                                               0.5f,
                                               wallLayer);
            if (!onWall)
            {
                rbody.velocity = new Vector2(fallspead * -1, 0);
            }
        }
    }
}