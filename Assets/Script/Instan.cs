using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instan : MonoBehaviour
{
    public Transform startPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "g")
        {
            collision.gameObject.transform.position = startPos.position;
        }
    }
}
