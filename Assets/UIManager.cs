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
	    if(Input.GetKeyDown(KeyCode.Space))
	    {
	    	mm.FadeOut();
	    }
    }
    
	public void SetDummyCameraActive(bool active)
	{
		_dummyCamera.gameObject.SetActive(active);
	}
}
