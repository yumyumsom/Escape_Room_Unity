using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Exit_GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject Cube;
    private List<Player> All_User = new List<Player>();
    private PhotonView PV;

    private void Awake()
    {

        PV = GetComponent<PhotonView>();
        
        //CubeChild = Cube.GetComponentsInChildren<GameObject>();
    }

    // Start is called before the first frame update

    private void Start()
    {
        //GameObject p = PhotonNetwork.Instantiate(Path.Combine("user",PlayerPrefs.GetString("selectedCharacter")), Cube.transform.position, Quaternion.identity, 0);
        print("=================");
      

        print("=================");
        //PV.RPC("Set_User",RpcTarget.All);
        //PV.RPC("setLastTime",RpcTarget.All);

    }

    // Update is called once per frame
    void Update()
    {
        PV.RPC("Get_User", RpcTarget.All);
        foreach (Player p in All_User)
        {
            print(p.NickName);
        }
    }

    void LastDance()
    {
        playerPrefab.GetComponent<Animator>().SetTrigger("happy_dance_2");
    }

    [PunRPC]
    void setLastTime()
    {
        string endgameMSG = GameObject.Find("Timer").GetComponent<TimerTest>().TimerForMat();
        GameObject.Find("Result_Time").GetComponent<Text>().text = endgameMSG;
    }

    [PunRPC]
    void Get_User()
    {
        All_User.Add(PhotonNetwork.LocalPlayer);
    }

    [PunRPC]
    void Set_User()
    {
        for (int i = 0; i < All_User.Count; i++)
        {
            GameObject temp = Resources.Load<GameObject>(Path.Combine("user", All_User[i].GetPlayerForm()));
            GameObject p = Instantiate(temp, Cube.transform.GetChild(i).position, Quaternion.identity);
            p.GetComponent<character_Ctrl>().enabled = false;
            p.GetComponent<Inventory>().enabled = false;
            p.transform.localScale = Cube.transform.localScale;
            p.transform.rotation = Cube.transform.rotation;
        }
    }

}
