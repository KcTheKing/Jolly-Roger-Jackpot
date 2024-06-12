using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkSpin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "j")
        {
            FindAnyObjectByType<ManagerSpin>().res = collision.gameObject.GetComponent<Image>().sprite.name;
        }
    }
}
