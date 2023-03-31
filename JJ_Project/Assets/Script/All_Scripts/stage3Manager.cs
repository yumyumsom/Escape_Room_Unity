// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Launcher.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in "PUN Basic tutorial" to handle typical game management requirements
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
namespace Photon.Pun.Demo.PunBasics
{
	#pragma warning disable 649

	/// <summary>
	/// Game manager.
	/// Connects and watch Photon Status, Instantiate Player
	/// Deals with quiting the room and the game
	/// Deals with level loading (outside the in room synchronization)
	/// </summary>
	public class stage3Manager : MonoBehaviourPunCallbacks
    {

		#region Public Fields

	
		public GameObject playerPrefab;
		#endregion

		#region Private Fields

		private GameObject instance;
		public GameObject Cube;

		void Awake()
		{
			playerPrefab =  Resources.Load<GameObject>(Path.Combine("user",PlayerPrefs.GetString("selectedCharacter")));
		}
        [SerializeField]
        void Start()
		{
			

			// in case we started this demo with the wrong scene being active, simply load the menu scene
			if (!PhotonNetwork.IsConnected)
			{
				SceneManager.LoadScene("PunBasics-Launcher");

				return;
			}

			if (playerPrefab == null) { // #Tip Never assume public properties of Components are filled up properly, always check and inform the developer of it.

				Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
			} else {


				if (PlayerManager.LocalPlayerInstance==null)
				{
				    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);

					// we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
					
					GameObject p = PhotonNetwork.Instantiate(Path.Combine("user",PlayerPrefs.GetString("selectedCharacter")), Cube.transform.position, Quaternion.identity, 0);
					//p.name = PlayerPrefs.GetString("nickName");
					//p.transform.localScale = Cube.transform.localScale; //new Vector3(0.7f, 0.7f, 0.7f);
					//DontDestroyOnLoad(p);
				}
				else{

					Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
				}


			}

		}
		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity on every frame.
		/// </summary>
		void Update()
		{
			// "back" button of phone equals "Escape". quit app if that's pressed
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				QuitApplication();
			}
		}

        #endregion

        #region Photon Callbacks

        /// <summary>
        /// Called when a Photon Player got connected. We need to then load a bigger scene.
        /// </summary>
        /// <param name="other">Other.</param>
        public override void OnPlayerEnteredRoom( Player other  )
		{
			Debug.Log( "OnPlayerEnteredRoom() " + other.NickName); // not seen if you're the player connecting

			if ( PhotonNetwork.IsMasterClient )
			{
				Debug.LogFormat( "OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient ); // called before OnPlayerLeftRoom

				LoadArena();
			}
		}

		/// <summary>
		/// Called when a Photon Player got disconnected. We need to load a smaller scene.
		/// </summary>
		/// <param name="other">Other.</param>
		public override void OnPlayerLeftRoom( Player other  )
		{
			Debug.Log( "OnPlayerLeftRoom() " + other.NickName ); // seen when other disconnects

			if ( PhotonNetwork.IsMasterClient )
			{
				Debug.LogFormat( "OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient ); // called before OnPlayerLeftRoom

				LoadArena(); 
			}
		}

		/// <summary>
		/// Called when the local player left the room. We need to load the launcher scene.
		/// </summary>
		public override void OnLeftRoom()
		{
			SceneManager.LoadScene("PunBasics-Launcher");   
		}

		#endregion

		#region Public Methods

		public void LeaveRoom()
		{
			PhotonNetwork.LeaveRoom();
		}

		public void QuitApplication()
		{
			Application.Quit();
		}

		#endregion

		#region Private Methods

		void LoadArena()
		{
			if ( ! PhotonNetwork.IsMasterClient )
			{
				Debug.LogError( "PhotonNetwork : Trying to Load a level but we are not the master Client" );
			}

			Debug.LogFormat( "PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount );

			PhotonNetwork.LoadLevel("PunBasics-Room for "+PhotonNetwork.CurrentRoom.PlayerCount);
		}

		#endregion

		public void GetRandomUser()
        {
			//user + num
			int num = Random.Range(1, 11); // 범위가 1,11 이면 1부터 10
			playerPrefab = Resources.Load("user"+num.ToString()) as GameObject;
		}


	}

}