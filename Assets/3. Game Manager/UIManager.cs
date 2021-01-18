using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	private MainMenu mm;
	private PauseMenu pause;
	private Camera _dummyCamera;
    // Start is called before the first frame update
    void Start()
	{
		pause = GetComponentInChildren<PauseMenu>();
	    mm = GetComponentInChildren<MainMenu>();
	    _dummyCamera = GetComponentInChildren<Camera>();
		
		
		GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    // Update is called once per frame
    void Update()
	{
		if(GameManager.Instance.currentGamestate != GameManager.GameState.PREGAME)
		{
			return;
		}
	    if(Input.GetKeyDown(KeyCode.Space))
	    {
	    	GameManager.Instance.StartGame();

	    }
    }
    

	public void SetDummyCameraActive(bool active)
	{
		_dummyCamera.gameObject.SetActive(active);
	}
	
	public void HandleGameStateChange(GameManager.GameState current, GameManager.GameState previous)
	{
		//pause.gameObject.SetActive(current == GameManager.GameState.PAUSED);
		
	}
}
