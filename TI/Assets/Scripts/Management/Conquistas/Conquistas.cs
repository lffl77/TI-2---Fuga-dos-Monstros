using UnityEngine;
using System.Collections.Generic;

public class Conquistas : MonoBehaviour 
{
    public static Conquistas cInstance;

    private GameObject conquistas;
    public GameObject conquistasPainel
    {
        get { return conquistas; }
        set { conquistas = value; }
    }

    private Dictionary<string, string> conquistasDict = new Dictionary<string, string>
    {
        { "De seus primeiros passos", "PC1" },
        { "Corredor de bairro", "PC2" },
        { "Maratonista", "PC3" },
        { "Run Forrest, Run!", "PC4" }
    };

    private void Awake()
    {
        // Implementação do Singleton
        if (cInstance == null)
        {
            cInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        conquistas = GameObject.FindGameObjectWithTag("Painel Conquistas");
        if (conquistas != null)
        {
            conquistas.SetActive(false);
        }
        else
        {
            Debug.LogError("Painel Conquistas não encontrado!");
        }

        // Inicializar todos os objetos de conquistas
        foreach (var conquistaTag in conquistasDict.Values)
        {
            GameObject conquistaObj = GameObject.FindGameObjectWithTag(conquistaTag);
            if (conquistaObj == null)
            {
                Debug.LogWarning($"Objeto com a tag {conquistaTag} não encontrado!");
            }
        }
    }

    private void Update() 
    {
        DesbloquearConquistas();
    }

    public void AbrirConquistas()
    {
        if (conquistas != null)
        {
            conquistas.SetActive(true);
        }
        else
        {
            Debug.LogError("Painel Conquistas não encontrado!");
        }
    }

    private void DesbloquearConquistas()
    {
        if (conquistas != null && conquistas.activeSelf)
        {
            foreach (var conquista in conquistasDict)
            {
                GameObject conquistaObj = GameObject.FindGameObjectWithTag(conquista.Value);
                if (conquistaObj != null)
                {
                    bool isCompleted = GameManager.Instance.IsAchievementCompleted(conquista.Key);
                    Debug.Log($"Conquista {conquista.Key}: {(isCompleted ? "Incompleta" : "Completa")}");
                    conquistaObj.SetActive(isCompleted);
                }
            }
        }
    }
}
