using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Slider gameobject")]
    private Slider slider;

    [SerializeField]
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

    [SerializeField]
    [Tooltip("Price text")]
    private Text priceText;    
    
    [SerializeField]
    [Tooltip("Level text")]
    private Text levelText;

    [Tooltip("Price of the upgrade")]
    private float upgradePrice;

    private float nbCoins;

    private float maxLevelReached;

    private void Start()
    {
        nbCoins = PlayerPrefs.GetFloat("nbCoins", 0);                       //Number of coins earned by the player
        //nbCoins = 500;
        coinText.text = nbCoins.ToString();                                 //Set the coin text as the number of coins of the player

        maxLevelReached = PlayerPrefs.GetFloat("maxUpgrade", 0);            //Maximum upgrade bought by the player
        slider_maxLevel.value = maxLevelReached;                            //Update the maximum level reached by the player

        upgradePrice = slider.value * 100;                                  //Set the upgrade price as the last level value
        priceText.text = upgradePrice.ToString();                           //Set the price text as the upgrade price value
        levelText.text = "Niv. " + slider.value.ToString();                 //Set the level text as the value of the last level value

        slider.value = PlayerPrefs.GetFloat("lastUpgrade", 0);              //Last level choose
    }

    private void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            nbCoins += 50;
            coinText.text = nbCoins.ToString();
        }

        if (slider.value < slider.maxValue)                                 //If the slider value is less than it maximum
        {
            MoreSpeedButton.interactable = true;                            //We can interact with the + button
        }
        else                                                                //Else
            MoreSpeedButton.interactable = false;                           //We can't

        if (slider.value > 1)                                               //If the slider value is upper than 0
            LessSpeedButton.interactable = true;                            //We can interact with the - button
        else                                                                //Else
            LessSpeedButton.interactable = false;                           //We can't

        upgradePrice = slider.value * 100;                                  //Upgrade the price text with the maximum level reached
        if (slider.value < maxLevelReached)
            priceText.text = "Out of stock";
        else if (slider.value == slider.maxValue)
            priceText.text = "Completed";
        else
            priceText.text = upgradePrice.ToString();                       //Update the price text with this value
        levelText.text = "Niv. " + slider.value.ToString();                 //Update the level text
    }

    public void MoreSpeed()
    {
        if (slider.value < slider.maxValue && nbCoins >= upgradePrice && slider.value >= maxLevelReached)      //If the slider value is less than it maximum
        {
            slider.value += 1;                                              //Update it value
            PlayerPrefs.SetFloat("lastUpgrade", slider.value);              //Set the number of update in the PlayerPrefs
            nbCoins -= upgradePrice;
            coinText.text = nbCoins.ToString();
            PlayerPrefs.SetFloat("nbCoins", nbCoins);
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerLoic>().UpgradeSpeed();
            PlayerPrefs.SetFloat("UpgradeSpeed", slider.value * 20);
        }
        else if (slider.value < slider_maxLevel.maxValue && slider.value < maxLevelReached)
        {
            slider.value++;
            PlayerPrefs.SetFloat("lastUpgrade", slider.value);
        }

        if (slider.value > maxLevelReached)                                 //If the slider value is greater than the maximum level reached
        {
            maxLevelReached = slider.value;                                 //Set the maximum level reached as the slider value
            PlayerPrefs.SetFloat("maxUpgrade", maxLevelReached);            //Update the PlayerPrefs with this value
            slider_maxLevel.value = maxLevelReached;
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
        PlayerPrefs.SetFloat("lastUpgrade", 0);
        PlayerPrefs.SetFloat("maxUpgrade", 0);
        PlayerPrefs.SetFloat("nbCoins", 0);
    }
}