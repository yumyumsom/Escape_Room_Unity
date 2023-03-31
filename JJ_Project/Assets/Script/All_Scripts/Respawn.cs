using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    public GameObject[] charPrefabs;

    public GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
       // player = Instantiate(Resources.Load<GameObject>("user"+PlayerPrefs.GetInt("selectedCharacter").ToString()).gameObject.transform);
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
