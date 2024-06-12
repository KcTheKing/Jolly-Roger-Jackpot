using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AppControl : MonoBehaviour
{
    public static AppControl appControl;
    public Sprite[] itemSprite;
    public item[] itemManageChild;
    public GameObject[] detectStop;
    public GameObject[] detectCheck;
    public GameObject[] Scenes;
    public Text txtBSlot, txtBSpin,txtBet,txtWin,txtOP;
    public GameObject panelWin;
    public int Balance,bet;
    public string res1, res2, res3;
    public GameObject panelOP;
    int win;
    float time;
    bool isStart;
    void Start()
    {
        Balance = PlayerPrefs.GetInt("DBControl");
        if (Balance == 0)
        {
            Balance = 10000;
        }
        FindAnyObjectByType<DBBaller>().dataGame();
        ChecngSprite();
        appControl = this;
        checkScenes();
        bet = 1000;
    }
    private void ChecngSprite()
    {
        List<int> lists = new List<int>();
        foreach(var obj in itemManageChild)
        {
            foreach(var Obj in obj.childItem)
            {
                int K = Random.Range(0, 8);
                while(lists.Contains(K))
                    K = Random.Range(0, 8);
                lists.Add(K);
                Obj.GetComponent<Image>().sprite = itemSprite[K];
            }
            lists.Clear();
        }
    }
    public void checkScenes()
    {
        if (Scenes[0].gameObject.active == true)
        {
            FindAnyObjectByType<buttonControl>().btnSlotpa.GetComponent<Button>().enabled = false;
            FindAnyObjectByType<buttonControl>().btnSlotpa.GetComponent<Button>().image.color = Color.gray;
        }
        else if (Scenes[0].gameObject.active == false)
        {
            FindAnyObjectByType<buttonControl>().btnSlotpa.GetComponent<Button>().enabled = true;
            FindAnyObjectByType<buttonControl>().btnSlotpa.GetComponent<Button>().image.color = new Color(1,1,1,1);
        }
        if (Scenes[1].gameObject.active == true)
        {
            FindAnyObjectByType<buttonControl>().btnSpinpa.GetComponent<Button>().enabled = false;
            FindAnyObjectByType<buttonControl>().btnSpinpa.GetComponent<Button>().image.color = Color.gray;
        }
        else if (Scenes[1].gameObject.active == false)
        {
            FindAnyObjectByType<buttonControl>().btnSpinpa.GetComponent<Button>().enabled = true;
            FindAnyObjectByType<buttonControl>().btnSpinpa.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
        }
    }
    void Update()
    {
        if (isStart)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                
                openDS();
                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(2.5f);
                    openDC();
                    yield return new WaitForSeconds(.5f);
                    checkWin();
                    FindAnyObjectByType<buttonControl>().btnSlot.GetComponent<Button>().enabled = true;
                    FindAnyObjectByType<buttonControl>().btnSlot.GetComponent<Button>().image.color = new Color(1,1,1,1);
                    FindAnyObjectByType<buttonControl>().btnEnableSpined();
                    //checkScenes();
                    checkBalance();

                    if(bet>Balance)
                    {
                        Balance = 10000;
                        checkBalance();
                    }
                }
                isStart = false;

            }
            
        }
        txtBSlot.text = Balance.ToString();
        txtBSpin.text = Balance.ToString();
        txtBet.text = bet.ToString();

       // checkScenes();
    }

    private void checkBalance()
    {
        if (Balance > 1000)
        {
            bet = Balance / 10;
        }
        else
        {
            bet = 50;
        }
    }

    public void openDC()
    {
        foreach (var obj in detectCheck)
        {
            obj.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    public void closeDC()
    {
        foreach (var obj in detectCheck)
        {
            obj.GetComponent<BoxCollider2D>().enabled = false;
        }
        Balance -= bet;
        win = 0;
        FindAnyObjectByType<DBBaller>().dataGame();
        res1 = "";
        res2 = "";
        res3 = "";
    }
    public async void openDS()
    {
        foreach (var obj in detectStop)
        {
            await Task.Delay(500);
            obj.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    public void closeDS()
    {
        time = Random.Range(1.5f, 3f);
        isStart = true;
        foreach (var obj in detectStop)
        {
            obj.GetComponent<BoxCollider2D>().enabled = false;
        }
        closeDC();
    }

    private void checkWin()
    {
        if(res1 == res2 && res1== res3)
        {
            win = bet * 10;
            Win3();
        }
        else if(res1 == res2 || res1 == res3 || res2 == res3)
        {
            win = bet * 5;
            Win2();
        }
        Balance += win;
    } 
    private void Win3()
    {
        panelWin.SetActive(true);
        txtWin.text = "Congreats! Three! You won " + win + "! please pick done for play again!";
    }
    private void Win2()
    {
        panelWin.SetActive(true);
        txtWin.text = "Congreats! Two! You won " + win + "! please pick done for play again!";
    }

}
