using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesSystem : MonoBehaviour
{   
    [Header("Cost Settings")]
    public int cost;

    [Header("Player Colors")]
    [SerializeField] SkinnedMeshRenderer  thePlayer;
    [SerializeField] List<Material> allMaterialColors = new List<Material>();


    public void IncreaseUpgradeCost()
    {
        cost *= 2;
        HUD_Manager.instance.upgradeCostText.text = "Cost: " + cost;
        ChangePlayerColor();
    }

    void ChangePlayerColor()
    {
        int randomColor = Random.Range(0,allMaterialColors.Count - 1);

        thePlayer.material = allMaterialColors[randomColor];
        allMaterialColors.RemoveAt(randomColor);
    }
}
