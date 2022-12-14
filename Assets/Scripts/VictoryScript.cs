using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryScript : MonoBehaviour
{
    public TextMeshProUGUI remainingEnemiesText;
    public GameObject victoryText;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        victoryText.SetActive(false);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        remainingEnemiesText.text = ("Enemies Remaining: " + enemies.Length.ToString());

        if (enemies.Length == 0)
        {
            victoryText.SetActive(true);
            remainingEnemiesText.gameObject.SetActive(false);
        }
    }
}
