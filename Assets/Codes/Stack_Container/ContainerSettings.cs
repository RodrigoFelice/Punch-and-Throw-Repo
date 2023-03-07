using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerSettings : MonoBehaviour
{
    [Header("Container Attributes")]
    [SerializeField] int limitStack = 1;


    public void UpgradeLimitStack()
    {
        limitStack++;
        HUD_Manager.instance.limitStackText.text = "Limit Stack: " + limitStack;
    }

    public bool CanGetMoreEnemiesAtTheStack()
    {
        if(GetComponent<ContainerOfEnemies>().enemiesStack.Count < limitStack)  return true;

        else return false;  
    }
}
