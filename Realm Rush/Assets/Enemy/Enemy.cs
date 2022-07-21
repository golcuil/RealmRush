using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RewardGold()
    {
        Bank.Instance.Deposit(goldReward);
    }

    public void StealGold()
    {
        Bank.Instance.Withdraw(goldPenalty);
    }
}
