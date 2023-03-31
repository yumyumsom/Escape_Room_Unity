using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions; //text정규표현 사용을 위해 선언
public class NetworkManager : MonoBehaviourPunCallbacks
{

    [Header("DisconnectPanel")] 
    public InputField NickNameInput;

    public GameObject error;
    
    [Header("LobbyPanel")] public GameObject LobbyPanel;
    public InputField RoomInput;
    public Text WelcomeText;
    public Text LobbyInfoText;
    public Button[] CellBtn;
    public Button PreviousBtn;
    public Button NextBtn;

    [Header("RoomPanel")] public GameObject RoomPanel;
    public Text ListText;
    public Text RoomInfoText;
    public Text[] ChatText;
    public InputField ChatInput;
    public Button ReadyBtn;

    [Header("ETC")] public Text StatusText;
    public PhotonView PV;

    List<RoomInfo> myList = new List<RoomInfo>();
    int currentPage = 1, maxPage, multiple;

    public List<Photon.Realtime.Player> readyPlayerList;



    #region 방리스트 갱신

    // ◀버튼 -2 , ▶버튼 -1 , 셀 숫자
    public void MyListClick(int num)
    {
        if (num == -2) --currentPage;
        else if (num == -1) ++currentPage;
        else PhotonNetwork.JoinRoom(myList[multiple + num].Name);
        MyListRenewal();
    }

    void MyListRenewal()
    {
        // 최대페이지
        maxPage = (myList.Count % CellBtn.Length == 0)
            ? myList.Count / CellBtn.Length
            : myList.Count / CellBtn.Length + 1;

        // 이전, 다음버튼
        PreviousBtn.interactable = (currentPage <= 1) ? false : true;
        NextBtn.interactable = (currentPage >= maxPage) ? false : true;

        // 페이지에 맞는 리스트 대입
        multiple = (currentPage - 1) * CellBtn.Length;
        for (int i = 0; i < CellBtn.Length; i++)
        {
            CellBtn[i].interactable = (multiple + i < myList.Count) ? true : false;
            CellBtn[i].transform.GetChild(0).GetComponent<Text>().text =
                (multiple + i < myList.Count) ? myList[multiple + i].Name : "";
            CellBtn[i].transform.GetChild(1).GetComponent<Text>().text = (multiple + i < myList.Count)
                ? myList[multiple + i].PlayerCount + "/" + myList[multiple + i].MaxPlayers
                : "";
        }
    }

    void PlayingRoomInfo()
    {
        
        for (int i = 0; i < CellBtn.Length; i++)
        {
            if (CellBtn[i].transform.GetChild(0).GetComponent<Text>().text == PhotonNetwork.CurrentRoom.Name)
            {
               CellBtn[i].transform.GetChild(0).GetComponent<Text>().text = myList[multiple + i].Name+"(게임 진행중)" ; 
            }
            
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int roomCount = roomList.Count;
        for (int i = 0; i < roomCount; i++)
        {
            if (!roomList[i].RemovedFromList)
            {
                if (!myList.Contains(roomList[i])) myList.Add(roomList[i]);
                else myList[myList.IndexOf(roomList[i])] = roomList[i];
            }
            else if (myList.IndexOf(roomList[i]) != -1) myList.RemoveAt(myList.IndexOf(roomList[i]));
        }

        MyListRenewal();
    }

    #endregion


    #region 서버연결
    void Awake()
    {
        Screen.SetResolution(960, 540, false);
    }
    public void Start() 
    {
        readyPlayerList = new List<Photon.Realtime.Player>();
    }
    void Update()
    {
        StatusText.text = PhotonNetwork.NetworkClientState.ToString();
        LobbyInfoText.text = (PhotonNetwork.CountOfPlayers - PhotonNetwork.CountOfPlayersInRooms) + "로비 / " +PhotonNetwork.CountOfPlayers + "접속";
       
        if (!PhotonNetwork.InRoom)
            return;
        if (PhotonNetwork.CurrentRoom.PlayerCount == readyPlayerList.Count){
            PlayingRoomInfo();
            SceneManager.LoadScene("Stage1");
        } 
    }

    public void CheckNickname()
    {
        if (Condition_Nickname(NickNameInput.text.ToString()))
        {
            Debug.Log("캐릭`터 생성완료");
            GameObject.Find("tempPlayer").GetComponent<Choice>().Pick_Me();
            PlayerPrefs.SetString("selectedCharacter", GameObject.Find("tempPlayer").GetComponent<Choice>().CurrentCharacter.name.ToString().Replace("(Clone)",""));
            PlayerPrefs.SetString("nickName",NickNameInput.text.ToString());
            Invoke("Connect", 2f);

        }
        else
        {
            NickNameInput.text = "";
            return;
        }
    }


    public void Connect()
    {
        Destroy(GameObject.Find("tempPlayer").GetComponent<Choice>().CurrentCharacter);
        PhotonNetwork.ConnectUsingSettings();
    }
    private bool Condition_Nickname(string str)
    {
        if ((str.Length > 0 && str.Length < 7))
        {
            return true;
        }

        else
        {
            print("7자 내로 입력하시오");
            error.SetActive(true);
            return false;
        }

    }

    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        LobbyPanel.SetActive(true);
        RoomPanel.SetActive(false);
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
        WelcomeText.text = PhotonNetwork.LocalPlayer.NickName + "님 환영합니다";
        myList.Clear();
    }

    public void Disconnect() => PhotonNetwork.Disconnect();

    public override void OnDisconnected(DisconnectCause cause)
    {
        LobbyPanel.SetActive(false);
        RoomPanel.SetActive(false);
    }

    #endregion


    #region 방

    public void CreateRoom()
    {

            PhotonNetwork.CreateRoom(RoomInput.text == "" ? "Room" + Random.Range(0, 100) : RoomInput.text,
            new RoomOptions { MaxPlayers = 4 });
    }


    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

    public void LeaveRoom() => PhotonNetwork.LeaveRoom();

    public override void OnJoinedRoom()
    {
        RoomPanel.SetActive(true);
        RoomRenewal();
        ChatInput.text = "";
        for (int i = 0; i < ChatText.Length; i++) ChatText[i].text = "";
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        RoomInput.text = "";
        CreateRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomInput.text = "";
        CreateRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        RoomRenewal();
        ChatRPC("<color=yellow>" + newPlayer.NickName + "님이 참가하셨습니다</color>");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RoomRenewal();
        ChatRPC("<color=yellow>" + otherPlayer.NickName + "님이 퇴장하셨습니다</color>");
    }

    void RoomRenewal()
    {
        ListText.text = "";
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            ListText.text += PhotonNetwork.PlayerList[i].NickName +
                             ((i + 1 == PhotonNetwork.PlayerList.Length) ? "" : ", ");
        RoomInfoText.text = PhotonNetwork.CurrentRoom.Name + " / " + PhotonNetwork.CurrentRoom.PlayerCount + "명 / " +
                            PhotonNetwork.CurrentRoom.MaxPlayers + "최대";
    }

    public void Ready()    //플레이어가 레디 할때
    {
        Debug.Log("Ready()");
        //모든 유저의 readyPlayerList를 변경해야하므로 RPC사용
        PV.RPC("AddReadyPlayer", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber); 
        //채팅창에 표시
        PV.RPC("ChatRPC", RpcTarget.All, "<color=Blue>" + PhotonNetwork.NickName + "님이 레디를 했습니다</color>"); 
        
    }

 
    [PunRPC]
    public void AddReadyPlayer(int actornumber) //플레이어가 레디 할때 RPC로 전달되는 함수
    {
        //Debug.Log("AddReadyPlayerList()");
        
        //현재 룸에 접속해 있는 플레이어중 현재 플레이어가 있는지확인
        var player = System.Array.Find(PhotonNetwork.PlayerList, p => p.ActorNumber == actornumber);    
        if (player == null)
        {
            Debug.LogError($"{actornumber} 플레이어가 존재하지 않음");
            return;
        }
        //플레이어가 정상적으로 접속해 있다는 뜻으로 레디한 플레이어목록에 현재 플레이어추가
        if (readyPlayerList.Find(p => p.ActorNumber == actornumber) == null)    
        {
            readyPlayerList.Add(player);
        }
    }




    #endregion


    #region 채팅

    public void Send()
    {

        PV.RPC("ChatRPC", RpcTarget.All, PhotonNetwork.NickName + " : " + ChatInput.text);
        ChatInput.text = "";
    }


    [PunRPC] // RPC는 플레이어가 속해있는 방 모든 인원에게 전달한다
    void ChatRPC(string msg)
    {

        bool isInput = false;
        for (int i = 0; i < ChatText.Length; i++)
        {
            if (ChatText[i].text == "")
            {
                isInput = true;
                ChatText[i].text = msg;
                break;
            }
        }

        if (!isInput) // 꽉차면 한칸씩 위로 올림
        {
            for (int i = 1; i < ChatText.Length; i++) ChatText[i - 1].text = ChatText[i].text;
            ChatText[ChatText.Length - 1].text = msg;
        }
    }

    #endregion
}