using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour 
{
    public Text coinsTxt;
    public Text[] buttonTxt;
    public int[] price;
    private int coins;

    private void Start()
    {
        if(PlayerPrefs.GetInt("0") == 0 || PlayerPrefs.GetInt("3") == 0)
        {
            PlayerPrefs.SetInt("0", 1);
            PlayerPrefs.SetInt("3", 1);
        }
        coins = PlayerPrefs.GetInt("ScorePoints");
        UpdateButtonsTexts();
    }

    private void Update() {
        UpdateButtonsTexts();
    }

    private void UpdateButtonsTexts()
    {
        for(int i = 0; i < buttonTxt.Length; i++)
        {
            if(PlayerPrefs.GetInt(i.ToString()) == 0 )
            {
                buttonTxt[i].text = price[i].ToString();
            }
            else
            {
                buttonTxt[i].text = "Adquirido";
            }

            if(price[i] == 0)
            {
                buttonTxt[i].text = "Adquirido";
            }
        }

        coinsTxt.text = PlayerPrefs.GetInt("ScorePoints").ToString();
    }
}
    /*public void SelectFase(int buttonNumber)
    {
        if(PlayerPrefs.GetInt(buttonNumber.ToString()) == 0)
        {   
            if(coins >= price[buttonNumber])
            {
                PlayerPrefs.SetInt(buttonNumber.ToString(), 1);
                PlayerPrefs.Save();
                coins -= price[buttonNumber];
                PlayerPrefs.SetInt("ScorePoints", coins);
                PlayerPrefs.Save();
                print("Desbloqueado");
            }
            else
            {
                buttonTxt[buttonNumber].text= "----------";
                print("Bloqueado");
            }
        }

        buttonTxt[buttonNumber].text = "Selecionado";
        print("Selecionado");
        PlayerPrefs.SetInt("faseSelect", buttonNumber);
        PlayerPrefs.Save();
    }

    public void SelectCharacter(int buttonNumber)
    {
        if(PlayerPrefs.GetInt(buttonNumber.ToString()) == 0)
        {   
            if(coins >= price[buttonNumber])
            {
                PlayerPrefs.SetInt(buttonNumber.ToString(), 1);
                PlayerPrefs.Save();
                coins = coins - price[buttonNumber];
                PlayerPrefs.SetInt("ScorePoints", coins);
                PlayerPrefs.Save();
                print("Desbloqueado");
            }
            else
            {
                buttonTxt[buttonNumber].text= "----------";
                print("Bloqueado");
            }
        
        buttonTxt[buttonNumber].text = "Selecionado";
        print("Selecionado");
        PlayerPrefs.SetInt("characterSelect", buttonNumber);
        PlayerPrefs.Save();
        }
    }
}*/
