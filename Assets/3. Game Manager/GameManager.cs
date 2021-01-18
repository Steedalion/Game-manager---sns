using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]
public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> {};

public class GameManager : Singleton<GameManager>
{
	//Todo
	/// <summary>
	/// 
	/// Trigger method via escape key
	/// Trigger method via pause menu
	/// Pause simulation
	/// modify cursor when paused.
	/// </summary>
	
	public GameObject[] systemPrefabs;
	List<GameObject> _systems;
	public EventGameState OnGameStateChange;
	
	# region gameState
	public GameState currentGamestate {get; private set;}= GameState.PREGAME;
	
	public enum GameState{
		PREGAME,
		RUNNING,
		PAUSED
	}
	
	void UpdateGamestate(GameState state)
	{
		GameState previousState = currentGamestate;
		currentGamestate = state;
		
		switch (currentGamestate)
		{
			
		case GameState.PREGAME:
			Time.timeScale = 1;
			break;
			
		case GameState.RUNNING:
			Time.timeScale = 1;
			break;
				
		case GameState.PAUSED:
			Time.timeScale = 0;
			break;
		
		default:
			break;
		}
		
		OnGameStateChange.Invoke(currentGamestate, previousState);
	}
	
	public void TogglePause()
	{
		UpdateGamestate(currentGamestate == GameState.RUNNING? GameState.PAUSED : GameState.RUNNING);
	}
	
	#endregion
	
	#region level control
	private string _currentScene = string.Empty;
	private List<AsyncOperation> _loadOperationComplete;
	private void OnLoadLevelComplete(AsyncOperation ao)
	{
		if(_loadOperationComplete.Contains(ao))
		{
			_loadOperationComplete.Remove(ao);
			if (_loadOperationComplete.Count == 0)
			{
				UpdateGamestate(GameState.RUNNING);
			}
		}
		Debug.Log("Load level Complete");
	}
	private void OnUnloadLevelComplete(AsyncOperation ao)
	{
		Debug.Log("Unloadlevel Complete");
	}
	
	void LoadLevel(string levelName)
	{
		AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
		
		if(ao == null)
		{
			Debug.LogError(this.name+": Could not load level "+levelName);
			return;
		}
		_loadOperationComplete.Add(ao);
		ao.completed += OnLoadLevelComplete;
	}
	
	void UnloadLevel(string levelName)
	{
		AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
		ao.completed += OnUnloadLevelComplete;
		
		if(ao == null)
		{
			Debug.LogError(this.name+": Could not load level "+levelName);
			return;
		}
		
	}
	# endregion level control
	
	# region Systems
	void InstantiateSystems()
	{
		GameObject system;
		for (int i = 0; i < systemPrefabs.Length; i++) {
			system = Instantiate(systemPrefabs[i]);
			_systems.Add(system);
		}
		
	}
	
	void DestroySystems()
	{
		foreach (var item in _systems)
		{
			Destroy(item);
		}
		_systems.Clear();
	}
	# endregion 
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		DontDestroyOnLoad(gameObject);
		
		_systems  = new List<GameObject>();
		_loadOperationComplete = new List<AsyncOperation>();
		
		InstantiateSystems();
		

	}
	
	// Update is called once per frame
	void Update()
	{
		if(GameManager.Instance.currentGamestate == GameManager.GameState.PREGAME)
		{
			return;
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			GameManager.Instance.TogglePause();

		}
	}
	
	// This function is called when the MonoBehaviour will be destroyed.
	protected override void OnDestroy()
	{
		base.OnDestroy();
		DestroySystems();
	}
	
	
	public void StartGame()
	{
		LoadLevel("Main");
	}
}
