using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	[SerializeField] private MainMenu mm;
	[SerializeField] private PauseMenu pause;
	[SerializeField] private Camera _dummyCamera;
	public GameEvents.EventMenuFade OnMainMenuFadeComplete;
    // Start is called before the first frame update
    void Start()
	{
		pause = GetComponentInChildren<PauseMenu>(true);
	    mm = GetComponentInChildren<MainMenu>();
	    _dummyCamera = GetComponentInChildren<Camera>();
		mm.OnMainMenuFadeComplete.AddListener(HandleMainMenuFade);
		
		GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
	}
    
	void HandleMainMenuFade(bool fadeout)
	{
		OnMainMenuFadeComplete.Invoke(fadeout);
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
		pause.gameObject.SetActive(current == GameManager.GameState.PAUSED);
		
	}
}
