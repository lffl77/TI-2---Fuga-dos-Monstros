using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectFases : MonoBehaviour 
{
    public Button[] mapButtons;  // Array de botões de mapa
    public string[] mapSceneNames;  // Nomes das cenas dos mapas correspondentes

    private void Start()
    {
        AssignButtonListeners();
    }

    private void AssignButtonListeners()
    {
        for(int i = 0; i < mapButtons.Length; i++)
        {
            int index = i;  // Necessário para evitar a captura de variáveis no loop
            mapButtons[i].onClick.AddListener(() => SelectMap(index));
        }
    }

    public void SelectMap(int buttonNumber)
    {
        if(PlayerPrefs.GetInt(buttonNumber.ToString()) == 1)
        {
            // Se o mapa estiver desbloqueado, permite a seleção
            for(int i = 0; i < mapButtons.Length; i++)
            {
                if(PlayerPrefs.GetInt(i.ToString()) == 1)
                {
                    mapButtons[i].GetComponentInChildren<Text>().text = "Selecionar";  // Reseta todos os botões desbloqueados para "Selecionar"
                }
            }
            
            PlayerPrefs.SetInt("selectedMap", buttonNumber);  // Salva o mapa selecionado
            PlayerPrefs.Save();
            LoadMapScene(buttonNumber);  // Carrega a cena do mapa
        }
        else
        {
            print("Mapa Bloqueado");
        }
    }

    private void LoadMapScene(int buttonNumber)
    {
        string sceneName = mapSceneNames[buttonNumber];
        SceneManager.LoadScene(sceneName);
    }
}
