using System;
using UnityEngine;

public class PlayerInstance : MonoBehaviour {
    public GameObject[] player;

    private void Start() 
    {
        GameObject instance = Instantiate(player[PlayerPrefs.GetInt("characterSelect")], gameObject.transform.position, Quaternion.identity);
        if(PlayerPrefs.GetInt("characterSelect") == 1)
            instance.transform.rotation = Quaternion.Euler(0, -90, 0);
        else
            instance.transform.rotation = Quaternion.Euler(0, 90, 0);
    }
}
