using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 15;
    
    public bool CreateTower(Tower prefab, Transform pos)
    {
        if(Bank.Instance.CurrentBalance >= cost)
        {
            Instantiate(prefab, pos.position, Quaternion.identity);
            Bank.Instance.Withdraw(cost);
            return true;
        }
        if(Bank.Instance.CurrentBalance < cost || Bank.Instance == null)
        {
            return false;
        }
        
        return false;
    }
}
