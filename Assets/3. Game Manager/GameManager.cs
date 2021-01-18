using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
	//TODO
	//Load unload game levels
	//keep track of game state
	//generate other persistant system.
	
	public GameObject[] systemPrefabs;
	List<GameObject> _systems;
	
	# region gameState
	public enum GameState{
		PREGAME,
		RUNNING,
		PAUSED
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
		}
		Debug.Log("Loadlevel Complete");
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
		
		LoadLevel("Main");
	}
	
	// This function is called when the MonoBehaviour will be destroyed.
	protected override void OnDestroy()
	{
		base.OnDestroy();
		DestroySystems();
	}
}
