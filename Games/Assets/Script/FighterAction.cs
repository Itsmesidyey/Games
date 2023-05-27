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

    [SerializeField]
    private GameObject faceIcon;

    private GameObject currentAttack;
    private GameObject CounterPunchAttack;
    private GameObject BlockAttack;
    private GameObject BodyshotAttack;
    private GameObject ClinchAttack;
    private GameObject CrossAttack;
    private GameObject FootworkAttack;
    private GameObject HookAttack;
    private GameObject JabAttack;
    private GameObject SlipAttack;
    private GameObject UppercutAttack;

    public void SelectAttack(string btn)
    {
        GameObject victim = tag == "Hero" ? enemy : hero;
        if (tag == "Hero")
        {
            victim = enemy;
        }
        if (btn.CompareTo("CounterPunch") == 0)
        {
            CounterPunchAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Block") == 0)
        {
            BlockAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("BodyShot") == 0)
        {
            BodyshotAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Clinch") == 0)
        {
            ClinchAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Cross") == 0)
        {
            CrossAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("FootWork") == 0)
        {
            FootworkAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Hook") == 0)
        {
            HookAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Jab") == 0)
        {
            JabAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Slip") == 0)
        {
            SlipAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            UppercutAttack.GetComponent<AttackScript>().Attack(victim);
        }
    }
}
