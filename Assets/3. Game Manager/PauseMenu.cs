
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	void HandleResume()
	{
		GameManager.Instance.TogglePause();
	}
}
