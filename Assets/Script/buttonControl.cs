using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AppControl;
using static ManagerSpin;

public class buttonControl : MonoBehaviour
{
    public Button btnSlot,btnSpin;
    public Button btnHomepa, btnSpinpa, btnSlotpa;
    //buttonGameSlot
    
    public void btnSpinSlot()
    {
        
        btnEnableSpining();
        appControl.closeDS();
        btnSlot.GetComponent<Button>().enabled = false;
        btnSlot.GetComponent<Button>().image.color = Color.gray;
    }
    public void btnEnableSpining()
    {

        btnHomepa.GetComponent<Button>().enabled = false;
        btnHomepa.GetComponent<Button>().image.color = Color.gray;
        btnSpinpa.GetComponent<Button>().enabled = false;
        btnSpinpa.GetComponent<Button>().image.color = Color.gray;
        btnSlotpa.GetComponent<Button>().enabled = false;
        btnSlotpa.GetComponent<Button>().image.color = Color.gray;
    }
    public void btnEnableSpined()
    {

        btnHomepa.GetComponent<Button>().enabled = true;
        btnHomepa.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
        btnSpinpa.GetComponent<Button>().enabled = true;
        btnSpinpa.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
        //btnSlotpa.GetComponent<Button>().enabled = true;
        //btnSlotpa.GetComponent<Button>().image.color = new Color(1,1,1,1);
    } 
    public void btnEnableSpined1()
    {

        btnHomepa.GetComponent<Button>().enabled = true;
        btnHomepa.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
        //btnSpinpa.GetComponent<Button>().enabled = true;
        //btnSpinpa.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
        btnSlotpa.GetComponent<Button>().enabled = true;
        btnSlotpa.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
    }

    //buttonGameSpin

    public void btnSpinReels()
    {
        btnSpin.GetComponent<Button>().enabled = false;
        btnSpin.GetComponent<Button>().image.color = Color.gray;
        managerSpin.spin();
        btnEnableSpining();
        FindAnyObjectByType<DBBaller>().dataGame();
    }

    //bottomNevegationBar
    public void btnHome()
    {
        appControl.Scenes[0].SetActive(false);
        appControl.Scenes[1].SetActive(false);
        appControl.Scenes[2].SetActive(true);
        FindAnyObjectByType<DBBaller>().dataGame();
        // btnEnableSpined();
    }
    public void btnScenesSpin()
    {
        appControl.Scenes[0].SetActive(false);
        appControl.Scenes[1].SetActive(true);
        appControl.checkScenes(); FindAnyObjectByType<DBBaller>().dataGame();
    }
    public void btnScencesSlot()
    {
        appControl.Scenes[0].SetActive(true);
        appControl.Scenes[1].SetActive(false);
        appControl.checkScenes(); FindAnyObjectByType<DBBaller>().dataGame();

    }

    public void btnDone()
    {
        appControl.panelWin.SetActive(false);
        FindAnyObjectByType<DBBaller>().dataGame();
    }
    public void btnStart()
    {
        appControl.Scenes[2].SetActive(false);
        appControl.Scenes[1].SetActive(false);
        appControl.Scenes[0].SetActive(true);
        appControl.checkScenes();
    }
    public void btnExit()
    {
        Application.Quit();
    }
    public void btnOP()
    {
        appControl.panelOP.SetActive(true);
    }
    int count = 0;
    public void btnContioue()
    {
        count++;
        if(count == 1)
        {
            appControl.txtOP.text = "With every spin, you have the chance to land identical symbols and win exciting rewards.";
        }
        if(count == 2)
        {
            appControl.txtOP.text = "Whether you match two or three symbols, the bounties are yours for the taking!";
        }
        if(count == 3)
        {
            appControl.txtOP.text = "Ahoy, matey! Welcome to Jolly Roger Jackpot, the ultimate slot game adventure!";
            count = 0;
            btnStart();
            appControl.panelOP.SetActive(false);
        }
    }
}
