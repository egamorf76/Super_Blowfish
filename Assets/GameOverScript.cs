using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private string textLevelConst;
    private string textPrizeConst;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private TextMeshProUGUI textPrize;

    private void Start()
    {
        textLevelConst = textLevel.text;
        textPrizeConst = textPrize.text;
        gameObject.SetActive(false);
    }

    public void ShowGameOverWindow()
    {
        textLevel.text = textLevel.text.Replace("1", SceneManager.GetActiveScene().buildIndex.ToString());
        textPrize.text = textPrize.text.Replace("1", InventoryScript.PrizeEarnDuringLevel.ToString());
        if (InventoryScript.PrizeEarnDuringLevel > 1)
        {
            textPrize.text = string.Join(" ", textPrize.text.Split(" ").Select(x => x = (x.Contains("offre") ? "offres" : x)).ToList());
        }
        gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Gameplay").GetComponent<GameplayScript>().Paused();
    }
}
