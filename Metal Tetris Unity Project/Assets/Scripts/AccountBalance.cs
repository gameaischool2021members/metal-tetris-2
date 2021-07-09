using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AccountBalance : MonoBehaviour
{
    [SerializeField] TMP_Text _balanceText;
    int _actualBalance = 0;

    private void Start() => _balanceText.text = "0";
    public void AddToBalance(int sum)
    {
        _actualBalance += sum;
        UpdateBalance();
    }
    private void UpdateBalance() => _balanceText.text = _actualBalance.ToString();
}
