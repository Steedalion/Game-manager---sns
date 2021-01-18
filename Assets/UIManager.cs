using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	private MainMenu mm;
	private Camera _dummyCamera;
    // Start is called before the first frame update
    void Start()
    {
	    mm = GetComponentInChildren<MainMenu>();
	    _dummyCamera = GetComponentInChildren<Camera>();
	   
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
	    	//mm.FadeOut();
	    }
    }
    

	public void SetDummyCameraActive(bool active)
	{
		_dummyCamera.gameObject.SetActive(active);
	}
}
