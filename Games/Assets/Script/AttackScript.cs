using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string animationName;

    [SerializeField]
    private bool magicAttack;

    [SerializeField]
    private float magicCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;

    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;

    public void Attack(GameObject victim)
    {
        // This could be your default attack type.
        Attack(victim, "CounterPunch");
    }

    public void Attack(GameObject victim, string attackType)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();
        if (attackerStats.magic >= magicCost)
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
            damage = multiplier * attackerStats.CounterPunch;

            if (magicAttack) {
                if (attackType == "magicBlock")
                {
                    damage = multiplier * attackerStats.magicBlock;
                }
                else if (attackType == "magicBodyshot")
                {
                    damage = multiplier * attackerStats.magicBodyshot;
                }
                else if (attackType == "magicClinch")
                {
                    damage = multiplier * attackerStats.magicClinch;
                }
                else if (attackType == "magicCross")
                {
                    damage = multiplier * attackerStats.magicCross;
                }
                else if (attackType == "magicFootwork")
                {
                    damage = multiplier * attackerStats.magicCross;
                }
                else if (attackType == "magicHook")
                {
                    damage = multiplier * attackerStats.magicHook;
                }
                else if (attackType == "magicJab")
                {
                    damage = multiplier * attackerStats.magicJab;
                }
                else if (attackType == "magicSlip")
                {
                    damage = multiplier * attackerStats.magicSlip;
                }
                else
                {
                    damage = multiplier * attackerStats.magicUppercut;
                }
            }

            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.updateMagicFill(magicCost);
        }
        else
        {
            Invoke("SkipTurnContinueGame", 2);
        }
    }

    void SkipTurnContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
}