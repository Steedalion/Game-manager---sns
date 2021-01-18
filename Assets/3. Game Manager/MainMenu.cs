using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	// Track animation component;
	// track animation clips;
	//Recieve animation effects
	// play animation effects
	[SerializeField] private Animation _mainMenuAnimaton; 
	[SerializeField] private AnimationClip _fadeOutAnimation;
	[SerializeField] private AnimationClip _fadeInAnimiation;
	
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
	}
	
	public void OnFadeOutComplete()
	{
		Debug.LogWarning("Fading out complete");
		
	}
	
	public void OnFadeinComplete()
	{
		Debug.LogWarning("Fading in complete");
		
	}
	
	public void FadeIn()
	{
		UIManager.Instance.SetDummyCameraActive(true);
		_mainMenuAnimaton.Stop();
		_mainMenuAnimaton.clip = _fadeInAnimiation;
		_mainMenuAnimaton.Play();
	}
	public void FadeOut()
	{
		UIManager.Instance.SetDummyCameraActive(false);
		_mainMenuAnimaton.Stop();
		_mainMenuAnimaton.clip = _fadeOutAnimation;
		_mainMenuAnimaton.Play();
	}
	
	public void HandleGameStateChange(GameManager.GameState current, GameManager.GameState previous)
	{
		if(current == GameManager.GameState.RUNNING && previous == GameManager.GameState.PREGAME)
		{
			FadeOut();
		}
	}
}
