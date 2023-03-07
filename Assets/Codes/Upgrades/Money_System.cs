using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_System : MonoBehaviour
{
    [Header("Money Variables")]
    int money;

    [Header("Outside References")]
    [SerializeField] UpgradesSystem upgrades;
    [SerializeField] ContainerSettings containerUpgradeCapacity;

    public void ChangeAmountOfMoney(int amount)
    {
        money += amount;
        HUD_Manager.instance.moneyText.text = "Money: " + money;
    }

    public void BuyUpgrade()
    {
        if (money >= upgrades.cost)  
        {
            int cost = upgrades.cost;
            ChangeAmountOfMoney(-cost);
            containerUpgradeCapacity.UpgradeLimitStack();
            upgrades.IncreaseUpgradeCost();
        }
    }

   
}
