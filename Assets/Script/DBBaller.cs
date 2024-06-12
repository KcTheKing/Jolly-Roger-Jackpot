using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBBaller : MonoBehaviour
{
    int Store;

    public void dataGame()
    {
        Store = FindAnyObjectByType<AppControl>().Balance;
        PlayerPrefs.SetInt("DBControl", Store);
        //print("game-->"+  game);
    }
}
