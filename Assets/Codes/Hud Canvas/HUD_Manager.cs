using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD_Manager : MonoBehaviour
{
   public static HUD_Manager instance;

   void Awake() => instance = this;

   [Header("Money Settings")]
   public TMP_Text moneyText;

   [Header("Upgrade Settings")]
   public TMP_Text upgradeCostText;

   [Header("Stack Settings")]
   public TMP_Text limitStackText;
}
