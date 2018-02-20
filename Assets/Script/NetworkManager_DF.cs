/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.NetworkSystem;
using TMPro;

public class NetworkManager_DF : NetworkManager {

	private string ipAddress;
	private string mapSelected = "Map 1";
	private int port = 7777;
	private int characterSelected = 0;
	private short playerControllerID = 0;

	public Text textConnectionInfo;
	//public Text ipAddressTextField;
	public Text matchRoomNameText;
	public TextMeshProUGUI mapSelectedText;
	public TextMeshProUGUI characterSelectedText;

	private Scene currentScene;

	public GameObject[] panelsUI;
	public GameObject roomButtonPrefab;
	public GameObject[] characterPrefab;

	private MatchInfo hostInfo;

	public Transform contentRoomList;

	#region Unity Methods
	private void OnEnable()
	{
		RegisterCharacterPrefab();
		SceneManager.sceneLoaded += OnMySceneLoaded;
	}
	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnMySceneLoaded;
	}

	public override void OnClientDisconnect(NetworkConnection conn)
	{
		base.OnClientDisconnect(conn);
		if (textConnectionInfo.text != null)
		{
			textConnectionInfo.text = "Disconnected or timed out.";
			ActivatePanel("PanelMainMenu");
		}
	}

	public override void OnClientConnect(NetworkConnection conn)
	{

	}

	public override void OnClientSceneChanged(NetworkConnection conn)
	{
		IntegerMessage msg = new IntegerMessage(characterSelected);
		ClientScene.AddPlayer(conn, playerControllerID, msg);
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
	{
		int id = 0;

		if (extraMessageReader != null)
		{
			var i = extraMessageReader.ReadMessage<IntegerMessage>();
			id = i.value;
		}

		Transform chosenSpawnPoint = NetworkManager.singleton.startPositions[Random.Range(0, NetworkManager.singleton.startPositions.Count)];
		GameObject player = Instantiate(characterPrefab[id], chosenSpawnPoint.position, chosenSpawnPoint.rotation) as GameObject;
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
	#endregion

	#region Farhan's Region

	void RegisterCharacterPrefab()
	{
		foreach (GameObject character in characterPrefab)
		{
			ClientScene.RegisterPrefab(character);
		}
	}

	public void OnClickSelectCharacter(int charNum)
	{
		characterSelected = charNum;
		characterSelectedText.text = "Character " + charNum + " Selected";
	}


	public void OnClickSelectMap(string mapName)
	{
		mapSelected = mapName;
		mapSelectedText.text = mapName + " SELECTED";
	}

	public void LoadMap()
	{
		NetworkManager.singleton.ServerChangeScene(mapSelected);
	}

	void OnMySceneLoaded(Scene scene, LoadSceneMode mode)
	{
		SetInitialReferences();
	}

	void SetInitialReferences()
	{
		currentScene = SceneManager.GetActiveScene();

		if (currentScene.name == "NetworkMenu")
		{
			ActivatePanel("PanelMainMenu");
		}
		else
		{
			ActivatePanel("PanelInGame");
			OnClickClearConnectionTextInfo();
		}
	}


	public void ActivatePanel(string panelName)
	{
		foreach (GameObject panelGO in panelsUI)
		{
			if (panelGO.name.Equals(panelName))
			{
				panelGO.SetActive(true);
			}
			else
			{
				panelGO.SetActive(false);
			}
		}
	}

	/*void GetIPAddress()
	{
		ipAddress = ipAddressTextField.text;
	}*/

	void SetPort()
	{
		NetworkManager.singleton.networkPort = port;
	}

	/*void SetIPAddress()
	{
		NetworkManager.singleton.networkAddress = ipAddress;
	}*/

	public void OnClickClearConnectionTextInfo()
	{
		textConnectionInfo.text = string.Empty;
	}

	public void OnClickStartLANHost()
	{
		SetPort();
		NetworkManager.singleton.StartHost();
		LoadMap();
	}

	public void OnClickStartServerOnly()
	{
		SetPort();
		NetworkManager.singleton.StartServer();
		LoadMap();
	}

	public void OnClickJoinLANGame()
	{
		SetPort();
		//GetIPAddress();
		//SetIPAddress();
		NetworkManager.singleton.StartClient();
	}

	public void OnClickDisconnectFromNetwork()
	{
		NetworkManager.singleton.StopHost();
		NetworkManager.singleton.StopServer();
		NetworkManager.singleton.StopClient();
	}

	public void OnClickExitGame()
	{
		Application.Quit();
	}

	public void OnClickDisableMatchMaker()
	{
		NetworkManager.singleton.StopMatchMaker();
	}

	public void OnClickEnableMatchMaker()
	{
		OnClickDisableMatchMaker();
		SetPort();
		NetworkManager.singleton.StartMatchMaker();
	}

	public void OnClickCreateMatch()
	{
		NetworkManager.singleton.matchMaker.CreateMatch(matchRoomNameText.text, 4, true, "", "", "", 0, 0, OnInternetCreateMatch);
	}

	void OnInternetCreateMatch(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		if (success)
		{
			textConnectionInfo.text = "Create Match Succeeded.";
			hostInfo = matchInfo;
			NetworkServer.Listen(hostInfo, NetworkManager.singleton.matchPort);
			NetworkManager.singleton.StartHost(hostInfo);
			LoadMap();
		}
		else
		{
			textConnectionInfo.text = "Create Match Failed.";
		}
	}

	void ClearContentRoomList()
	{
		foreach (Transform child in contentRoomList)
		{
			DestroyImmediate(child.gameObject, true);
		}
	}

	public void OnClickFindInternetMatch()
	{
		ClearContentRoomList();
		NetworkManager.singleton.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnInternetMatchList);
	}

	void OnInternetMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
	{
		if (success)
		{
			if (matches.Count != 0)
			{
				foreach (MatchInfoSnapshot matchesAvailable in matches)
				{
					GameObject rButton = Instantiate(roomButtonPrefab) as GameObject;
					rButton.GetComponentInChildren<Text>().text = matchesAvailable.name;
					rButton.GetComponent<Button>().onClick.AddListener(delegate
					{ JoinInternetMatch(matchesAvailable.networkId, "", "", "", 0, 0, OnJoinInternetMatch); });
					rButton.GetComponent<Button>().onClick.AddListener(delegate
					{ ActivatePanel("PanelAttemptingToConnect"); });
					rButton.transform.SetParent(contentRoomList, false);
				}
			}

			else
			{
				textConnectionInfo.text = "No matches available.";
			}
		}

		else
		{
			textConnectionInfo.text = "Couldn't connect to match maker.";
		}

	}

	public void JoinInternetMatch(NetworkID netID,
	string password, string pubClientAddress, string privClientAddress, int eloScore, int reqDomain, NetworkMatch.DataResponseDelegate<MatchInfo> callback)
	{
		NetworkManager.singleton.matchMaker.JoinMatch(netID, password, pubClientAddress, privClientAddress, eloScore, reqDomain, OnJoinInternetMatch);
	}


	void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		if (success)
		{
			hostInfo = matchInfo;
			NetworkManager.singleton.StartClient(hostInfo);
		}
		else
		{
			textConnectionInfo.text = "Join Match Failed";
		}
	}


	#endregion

}
