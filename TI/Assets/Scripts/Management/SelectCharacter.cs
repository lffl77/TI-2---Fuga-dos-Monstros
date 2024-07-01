using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour 
{
    public Button[] buttons;
    public void SelectChar(int buttonNumber)
    {
        if(PlayerPrefs.GetInt(buttonNumber.ToString()) == 0)
        {
            PlayerPrefs.SetInt(buttonNumber.ToString(), 1);
            PlayerPrefs.Save();

            print("Selecionado");
            PlayerPrefs.SetInt("characterSelect", buttonNumber);
            PlayerPrefs.Save();
        }
    }
}