using UnityEngine;
using System.Collections;

public class Network1 : MonoBehaviour
{
	private const string typeName = "BlockPush2015";
	private const string gameName = "Room1";
	
	private bool isRefreshingHostList = false;
	private HostData[] hostList;
	
	public GameObject playerPrefab;
	
	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				StartServer();
			
			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
				RefreshHostList();
			
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++)
				{
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						JoinServer(hostList[i]);
				}
			}
		}
	}
	
	private void StartServer()
	{
		Network.InitializeServer(5, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}
	
	void OnServerInitialized()
	{
		SpawnPlayer();
	}
	
	
	void Update()
	{
		if (isRefreshingHostList && MasterServer.PollHostList().Length > 0)
		{
			isRefreshingHostList = false;
			hostList = MasterServer.PollHostList();
		}
	}
	
	private void RefreshHostList()
	{
		if (!isRefreshingHostList)
		{
			isRefreshingHostList = true;
			MasterServer.RequestHostList(typeName);
		}
	}
	
	
	private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
		//playerPrefab.tag = "Player" + Network.connections.Length;
		//playerPrefab.color = new Color (.5f, 0, 0);
	}
	
	void OnConnectedToServer()
	{
		SpawnPlayer();
	}
	
	
	private void SpawnPlayer()
	{
		Network.Instantiate(playerPrefab, Vector3.up * 5, Quaternion.identity, 0);
		//Debug.Log ("test" + Network.player.ToString);
	}
}
