
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private Button resume;
	[SerializeField] private Button restart;
	[SerializeField] private Button quit;
    // Start is called before the first frame update
    void Start()
    {
	    resume.onClick.AddListener(HandleResume);
	    restart.onClick.AddListener(HandleRestart);
	    quit.onClick.AddListener(HandleQuit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	void HandleResume()
	{
		GameManager.Instance.TogglePause();
	}
	void HandleQuit(){
		GameManager.Instance.QuitGame();
	}
	void HandleRestart()
	{
		GameManager.Instance.RestartGame();
	}
}
