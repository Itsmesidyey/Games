using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCTSScript : MonoBehaviour
{
    private const int maxIterations = 1000;
    private const double sqrt2 = 1.4142136;

    private class Node
    {
        public int visits = 0;
        public double reward = 0.0;
        public List<Node> children;
        public Node parent;
        public string action;

        public Node(Node parent, string action)
        {
            this.parent = parent;
            this.action = action;
            this.children = new List<Node>();
        }
    }

    private Node rootNode;

    public string SelectMove(GameObject currentUnit)
    {
        rootNode = new Node(null, null);
        for (int i = 0; i < maxIterations; ++i)
        {
            Node leaf = Traverse(rootNode); // selection
            double reward = Simulate(currentUnit, leaf.action); // simulation
            Backpropagate(leaf, reward); // backpropagation
        }

        Node bestChild = BestChild(rootNode, 0.0);
        return bestChild.action;
    }

    private Node Traverse(Node node)
    {
        while (node.children.Count != 0)
        {
            if (node.children.Count < 10) // 10 is the number of actions
            {
                return Expand(node);
            }
            else
            {
                node = BestChild(node, sqrt2);
            }
        }
        return Expand(node);
    }

    private Node Expand(Node node)
    {
        string newAction = "AttackType" + (node.children.Count + 1).ToString(); // change this to reflect your actual actions
        Node child = new Node(node, newAction);
        node.children.Add(child);
        return child;
    }

    private double Simulate(GameObject currentUnit, string action)
    {
        // Simulate a game until its end to get the reward of the node
        // You will have to implement the SimulateGame method to simulate the game until its end and return the result
        // The result should be a double representing the reward of the node, for example: the score of the game.
        return SimulateGame(currentUnit, action);
    }

    private void Backpropagate(Node node, double reward)
    {
        while (node != null)
        {
            node.visits += 1;
            node.reward += reward;
            node = node.parent;
        }
    }

    private Node BestChild(Node node, double c)
    {
        Node bestChild = null;
        double bestValue = double.NegativeInfinity;

        foreach (Node child in node.children)
        {
            double uctValue = child.reward / child.visits + c * Math.Sqrt(2 * Math.Log(node.visits) / child.visits);
            if (uctValue > bestValue)
            {
                bestChild = child;
                bestValue = uctValue;
            }
        }

        return bestChild;
    }

    public float SimulateGame(GameObject unit, string action)
    {
        // Extract the stats of the unit
        FighterStats unitStats = unit.GetComponent<FighterStats>();

        // Find the enemy
        GameObject enemy = GameObject.FindGameObjectWithTag(unit.tag == "Hero" ? "Enemy" : "Hero");

        // Extract the stats of the enemy
        FighterStats enemyStats = enemy.GetComponent<FighterStats>();

        // Compute the expected damage of the action
        float expectedDamage;
        switch (action)
        {
            case "CounterPunch":
                expectedDamage = unitStats.attack * unitStats.CounterPunch - enemyStats.defense;
                break;
            case "Block":
                // Assuming that blocking does no damage but reduces incoming damage
                expectedDamage = -0.5f * enemyStats.attack;
                break;
            // Add more cases for other actions...
            default:
                expectedDamage = 0f;
                break;
        }

        // Return a reward based on the expected damage
        // Here we simply return the expected damage, but you could also use a more complex function
        return expectedDamage;
    }
}
