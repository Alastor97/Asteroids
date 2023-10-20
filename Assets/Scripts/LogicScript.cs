using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerMoney;
    public Text moneyText;
    public float addRate;
    private float timer = 0;
    public GameObject gameOverScreen;
    public Image healthBar;
    public float healthAmount = 100f;
    public void addMoney(int rewardMoney)
    {
        playerMoney += rewardMoney;
        moneyText.text = playerMoney.ToString();

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
}
