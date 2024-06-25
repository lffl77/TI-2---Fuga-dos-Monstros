using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Carrossel : MonoBehaviour
{
    public List<Image> images;
    private int currentIndex = 0;

    void Start()
    {
        UpdateCarousel();
    }

    public void PreviousItem()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateCarousel();
            Debug.Log("Voltar item");
        }
    }

    public void NextItem()
    {
        if (currentIndex < images.Count - 1)
        {
            currentIndex++;
            UpdateCarousel();
            Debug.Log("Proximo item");
        }
    }

    void UpdateCarousel()
    {
        // Atualizar a visibilidade dos itens com base no índice atual
        for (int i = 0; i < images.Count; i++)
        {
            images[i].gameObject.SetActive(i == currentIndex);
        }
    }

    void Update()
    {
        
    }
}
