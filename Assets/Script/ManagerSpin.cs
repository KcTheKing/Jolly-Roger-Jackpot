using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AppControl;

public class ManagerSpin : MonoBehaviour
{
    public static ManagerSpin managerSpin;
    public Transform cycleSpin;
    public GameObject spinCheck;
    private float Speed,subTra;
    public string res;
    public Text txtBet;
    int win;
    bool isStart;
    void Start()
    {
        Speed = 1200;
        managerSpin = this;
    }


    void Update()
    {
        if(isStart)
        {
            cycleSpin.Rotate(0, 0, Speed * Time.deltaTime);
            Speed -= subTra *Time.deltaTime;
            if(Speed <= 0)
            {
                isStart = false;
                spinCheck.GetComponent<PolygonCollider2D>().enabled = true;
                FindAnyObjectByType<buttonControl>().btnSpin.GetComponent<Button>().enabled = true;
                FindAnyObjectByType<buttonControl>().btnSpin.GetComponent<Button>().image.color = new Color(1,1,1,1);
                checkSpinWin();
                FindAnyObjectByType<buttonControl>().btnEnableSpined1();
                
                //appControl.checkScenes();
            }
        }
        txtBet.text = appControl.bet.ToString();
        
    }

    public void spin()
    {
        res = "";
        isStart = true;
        Speed = 1200;
        subTra = Random.Range(150, 200);
        spinCheck.GetComponent<PolygonCollider2D>().enabled = false;
        appControl.Balance -= appControl.bet;
    }

    public void checkSpinWin()
    {
        if(res == "e1" || res == "e2" || res == "e3" || res == "e4")
        {
            win = appControl.bet * 2;
        }
        else
        {
            win = appControl.bet * 2;
        }
        appControl.Balance += win; 
    }
}
