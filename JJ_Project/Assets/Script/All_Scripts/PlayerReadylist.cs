using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReadylist : MonoBehaviour
{   
    // Start is called before the first frame update
    public List<Photon.Realtime.Player> readyPlayerListCopy;
    void Start()
    {
       // DontDestroyOnLoad(gameObject);
    }

    public void setReadyPlayerList(List<Photon.Realtime.Player> readyPlayerList)
    {
        this.readyPlayerListCopy = readyPlayerList;
    }

}
