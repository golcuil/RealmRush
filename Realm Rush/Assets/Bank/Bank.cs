using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int _currentBalance;
    public int CurrentBalance { get => _currentBalance;}

    public static Bank Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        _currentBalance = startingBalance;
    }
    public void Deposit(int amount)
    {
        _currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        _currentBalance -= Mathf.Abs(amount);
        if(_currentBalance < 0)
        {
            _currentBalance = 0;
        }
    }
}
