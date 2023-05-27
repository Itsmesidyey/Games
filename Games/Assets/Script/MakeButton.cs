using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;

    private GameObject hero;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallback(string btn)
    {
        if(btn.CompareTo("CounterPunchbtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("CounterPunch");
        } 
        else if (btn.CompareTo("Blockbtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("Block");
        }
        else if (btn.CompareTo("Bodyshotbtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("BodyShot");
        }
        else if (btn.CompareTo("Clinchbtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("Clinch");
        }
        else if (btn.CompareTo("Crossbtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("Cross");
        }
        else if (btn.CompareTo("Footworkbtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("FootWork");
        }
        else if (btn.CompareTo("Hookbtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("Hook");
        }
        else if (btn.CompareTo("Jabbtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("Jab");
        }
        else if (btn.CompareTo("Slipbtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("Slip");
        }
        else
        {
            hero.GetComponent<FighterAction>().SelectAttack("UpperCut");
        }
    }
}

