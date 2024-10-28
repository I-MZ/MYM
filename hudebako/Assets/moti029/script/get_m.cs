using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (gameObject.CompareTag("Goal"))
        //{
        //    Destroy(gameObject);
        //}

        //ÉSÅ[ÉãÇÃä¯Ç…êGÇÍÇΩÇ∆Ç´
        if (collision.gameObject.tag == "Goal")
        {
            Destroy(collision.gameObject);

        }

        
    }


}