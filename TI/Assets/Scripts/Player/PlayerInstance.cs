using UnityEngine;

public class PlayerInstance : MonoBehaviour {
    public GameObject[] player;

    private void Start() 
    {
        Instantiate(player[PlayerPrefs.GetInt("characterSelect")], gameObject.transform.position, Quaternion.identity);
    }
}
