using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour 
{
    public Text coinsTxt;
    public Text[] buttonTxt;
    private int[] price;
    private int coins;

    private void Start()
    {
        if(PlayerPrefs.GetInt("0") == 0)
        {
            PlayerPrefs.SetInt("0", 1);
        }
        coins = PlayerPrefs.GetInt("ScorePoints");
    }

    private void Update()
    {
        for(int i = 0; i < buttonTxt.Length; i++)
        {
            if(PlayerPrefs.GetInt(i.ToString()) == 0)
            {
                buttonTxt[i].text = price[i].ToString();
            }
            else
            {
                buttonTxt[i].text = "Adquirido";
            }
        }

        coinsTxt.text = PlayerPrefs.GetInt("ScorePoints").ToString();
    }
    public void SelectFase(int buttonNumber)
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
            print("Bloqueado");
        }
        else
        {
            //Selecionar fase
            buttonTxt[buttonNumber].text = "Selecionado";
            print("Selecionado");
            PlayerPrefs.GetInt("faseSelect", buttonNumber);
            PlayerPrefs.Save();
        }
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
            print("Bloqueado");
        }
        else
        {
            //Selecionar personagem
            buttonTxt[buttonNumber].text = "Selecionado";
            print("Selecionado");
            PlayerPrefs.GetInt("characterSelect", buttonNumber);
            PlayerPrefs.Save();
        }
    }
}
