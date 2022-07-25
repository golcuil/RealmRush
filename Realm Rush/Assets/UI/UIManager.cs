using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;

    public static UIManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        ShowCurrentBalance();
    }

    public void ShowCurrentBalance()
    {
        goldText.text = "Gold: " + Bank.Instance.CurrentBalance.ToString();
    }
}
