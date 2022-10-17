using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Slider gameobject (Active upgrade)")]
    private Slider slider;

    [SerializeField]
    [Tooltip("Slider gameobject (Max upgrade reached)")]
    private Slider slider_maxLevel;

    [SerializeField]
    [Tooltip("MoreSpeed button")]
    private Button MoreSpeedButton;

    [SerializeField]
    [Tooltip("LessSpeed button")]
    private Button LessSpeedButton;

    [SerializeField]
    [Tooltip("Coin text")]
    private Text coinText;

    [Tooltip("Coins spent")]
    private float coinsSpent;

    [SerializeField]
    [Tooltip("Price text")]
    private Text priceText;    
    
    [SerializeField]
    [Tooltip("Level text")]
    private Text levelText;

    [Tooltip("Price of the upgrade")]
    private float upgradePrice;

    [Tooltip("Amount of coins")]
    private float nbCoins;

    [Tooltip("Maximum upgrade reached bu the player")]
    private float maxLevelReached;

    private void Start()
    {
        nbCoins = PlayerPrefs.GetFloat("nbCoins", 0);                       //Number of coins earned by the player
        coinText.text = nbCoins.ToString();                                 //Set the coin text as the number of coins of the player

        maxLevelReached = PlayerPrefs.GetFloat("maxUpgrade", 0);            //Maximum upgrade bought by the player
        slider_maxLevel.value = maxLevelReached;                            //Update the maximum level reached by the player

        upgradePrice = slider.value * 100;                                  //Set the upgrade price as the last level value
        priceText.text = upgradePrice.ToString();                           //Set the price text as the upgrade price value
        levelText.text = "Niv. " + slider.value.ToString();                 //Set the level text as the value of the last level value

        slider.value = PlayerPrefs.GetFloat("lastUpgrade", 0);              //Last level choose

        coinsSpent = PlayerPrefs.GetFloat("coinsSpent");

    }

    private void Update()
    {
        if (Input.GetKeyDown("y"))                                          //If the player press Y
        {
            nbCoins += 50;                                                  //Add 50 coins
            coinText.text = nbCoins.ToString();                             //Refresh the text container
        }

        if (slider.value < slider.maxValue)                                 //If the slider value is less than it maximum
            MoreSpeedButton.interactable = true;                            //We can interact with the + button
        else                                                                //Else
            MoreSpeedButton.interactable = false;                           //We can't

        if (slider.value > slider.minValue)                                 //If the slider value is upper than it minimum
            LessSpeedButton.interactable = true;                            //We can interact with the - button
        else                                                                //Else
            LessSpeedButton.interactable = false;                           //We can't

        upgradePrice = slider.value * 100;                                  //Upgrade the price text with the maximum level reached

        if (slider.value < maxLevelReached)                                 //If the slider value is less than the maximum upgrade reached by the player
            priceText.text = "Out of stock";                                //Set the text container for the price as "Out of stock"
        else if (slider.value == slider.maxValue)                           //Else, if the slider value is equal to it maximum value
            priceText.text = "Completed";                                   //Set the text container for the price as "Completed"
        else
            priceText.text = upgradePrice.ToString();                       //Update the price text with the price value
        levelText.text = "Niv. " + slider.value.ToString();                 //Update the text container for the level
    }

    public void MoreSpeed()
    {
        if (slider.value < slider.maxValue && nbCoins >= upgradePrice && slider.value >= maxLevelReached)  //If the slider value is less than it maximum and the player have enough coins to purchase the upgrade and the slider value is upper than the maximum upgrade purchased by the player
        {
            slider.value += 1;                                                                             //Update the value of the slider
            PlayerPrefs.SetFloat("lastUpgrade", slider.value);                                             //Update the lastUpgrade value of the playerPrefs as the new upgrade
            nbCoins -= upgradePrice;                                                                       //Update the number of coins of the player depending on the price of the upgrade
            coinText.text = nbCoins.ToString();                                                            //Update the text container of the coins            
            coinsSpent += upgradePrice;
            PlayerPrefs.SetFloat("coinsSpent", coinsSpent);                                                //Add to the total amount of coins spent by the player the price of the upgrade
            PlayerPrefs.SetFloat("nbCoins", nbCoins);                                                      //Update the number of coins in the playerPrefs as the new amount of coins
            PlayerPrefs.SetFloat("UpgradeSpeed", slider.value * 20);                                       //Update the speed upgrade in the playerPrefs as the new speed upgrade
        }
        else if (slider.value < slider.maxValue && slider.value < maxLevelReached)                         //Else, if the slider value is less than it maximum and less than the maximum upgrade reached
        {
            slider.value++;                                                                                //Update the slider value
            PlayerPrefs.SetFloat("lastUpgrade", slider.value);                                             //Update the lastUpgrade value of the playerPrefs as the new upgrade
        }

        if (slider.value > maxLevelReached)                                 //If the slider value is greater than the maximum level reached
        {
            maxLevelReached = slider.value;                                 //Set the maximum level reached as the slider value
            PlayerPrefs.SetFloat("maxUpgrade", maxLevelReached);            //Update the PlayerPrefs with this value
            slider_maxLevel.value = maxLevelReached;                        //Update the maximum upgrade reached slider value as the new maximum upgrade reached
        }
    }

    public void LessSpeed()
    {
        if (slider.value > 1)                                               //If the slider value is less than 0
        {
            slider.value -= 1;                                              //Update it value
            PlayerPrefs.SetFloat("lastUpgrade", slider.value);              //Update the number of update in the PlayerPrefs
        }
    }

    public void ResetData()
    {
        PlayerPrefs.SetFloat("lastUpgrade", 0);                             //Set the lastUpgrade value of the playerPrefs to 0
        PlayerPrefs.SetFloat("maxUpgrade", 0);                              //Set the maxUpgrade value of the playerPrefs to 0
        PlayerPrefs.SetFloat("nbCoins", coinsSpent + nbCoins);              //Set the nbCoins value of the playerPrefs to the actual amount of coins + the coins spent
        PlayerPrefs.SetFloat("coinsSpent", 0);                              //Set the coinsSpent value of the playerPrefs to 0
    }
}