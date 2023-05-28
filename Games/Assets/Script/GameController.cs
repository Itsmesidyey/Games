using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Transactions;
using UnityEngine.SocialPlatforms;
using TMPro;

public class GameController : MonoBehaviour
{
    private List<FighterStats> fighterStats;
    private GameObject battleMenu;
    public TMP_Text battleText;

    private void Awake()
    {
        battleMenu = GameObject.Find("ActionMenu");
    }

    void Start()
    {
        fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        fighterStats.Sort();

        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        GameObject currentUnit = currentFighterStats.gameObject;  // define currentUnit here

        if (!currentFighterStats.GetDead())
        {
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if (currentUnit.tag == "Hero")
            {
                this.battleMenu.SetActive(true);
            }
            else
            {
                this.battleMenu.SetActive(false);
                int attackIndex = Random.Range(0, 9);
                string attackType;
                switch (attackIndex)
                {
                    case 0:
                        attackType = "CounterPunch";
                        break;
                    case 1:
                        attackType = "Block";
                        break;
                    case 2:
                        attackType = "Bodyshot";
                        break;
                    case 3:
                        attackType = "Clinch";
                        break;
                    case 4:
                        attackType = "Cross";
                        break;
                    case 5:
                        attackType = "Footwork";
                        break;
                    case 6:
                        attackType = "Hook";
                        break;
                    case 7:
                        attackType = "Jab";
                        break;
                    case 8:
                        attackType = "Slip";
                        break;
                    default:
                        attackType = "Uppercut";
                        break;
                }
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);
            }
        }
        else
        {
            MCTSScript mcts = new MCTSScript();
            string selectedMove = mcts.SelectMove(currentUnit);
            // Invoke the selected move
            // ...
        }
    }
}
