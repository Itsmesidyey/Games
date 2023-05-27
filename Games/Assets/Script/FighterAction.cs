using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject hero;

    [SerializeField]
    private GameObject CounterPunchPrefab;

    [SerializeField]
    private GameObject BlockPrefab;

    [SerializeField]
    private GameObject BodyshotPrefab;

    [SerializeField]
    private GameObject ClinchPrefab;

    [SerializeField]
    private GameObject CrossPrefab;

    [SerializeField]
    private GameObject FootworkPrefab;

    [SerializeField]
    private GameObject HookPrefab;

    [SerializeField]
    private GameObject JabPrefab;

    [SerializeField]
    private GameObject SlipPrefab;

    [SerializeField]
    private GameObject UppercutPrefab;

    private GameObject currentAttack;
    /*private GameObject CounterPunchAttack;
    private GameObject BlockAttack;
    private GameObject BodyshotAttack;
    private GameObject ClinchAttack;
    private GameObject CrossAttack;
    private GameObject FootworkAttack;
    private GameObject HookAttack;
    private GameObject JabAttack;
    private GameObject SlipAttack;
    private GameObject UppercutAttack;*/

    void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        if (tag == "Hero")
        {
            victim = enemy;
        }
        if (btn.CompareTo("CounterPunch") == 0)
        {
            CounterPunchPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Block") == 0)
        {
            BlockPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("BodyShot") == 0)
        {
            BodyshotPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Clinch") == 0)
        {
            ClinchPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Cross") == 0)
        {
            CrossPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("FootWork") == 0)
        {
            FootworkPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Hook") == 0)
        {
            HookPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Jab") == 0)
        {
            JabPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Slip") == 0)
        {
            SlipPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            UppercutPrefab.GetComponent<AttackScript>().Attack(victim);
        }
    }
}
