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
		_mainMenuAnimaton.Stop();
		_mainMenuAnimaton.clip = _fadeInAnimiation;
		_mainMenuAnimaton.Play();
		UIManager.Instance.SetDummyCameraActive(true);
	}
	public void FadeOut()
	{
		UIManager.Instance.SetDummyCameraActive(false);
		_mainMenuAnimaton.Stop();
		_mainMenuAnimaton.clip = _fadeOutAnimation;
		_mainMenuAnimaton.Play();
	}
}
