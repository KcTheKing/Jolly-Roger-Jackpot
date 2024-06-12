using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static AppControl;

public class check : MonoBehaviour
{
    public bool isRow1, isRow2, isRow3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "g")
        {
            if (isRow1)
            {
                appControl.res1 = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if(isRow2)
            {
                appControl.res2 = collision.gameObject.GetComponent<Image>().sprite.name;

            }
            if(isRow3)
            {
                appControl.res3 = collision.gameObject.GetComponent<Image>().sprite.name;
            }
        }
        //print($"res1->{appControl.res1} res2-> {appControl.res2} res3-> {appControl.res3}");
    }
}
