using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	public static T instance;
	public bool isInitialized => instance == null;
	
	public static T Instance
	{
		get {return instance;}
		
	}
	
	
	
	protected void Awake()
	{
		if(instance != null)
		{
			Debug.Log("[Singleton] Trying to instatiant a second instance of singleton," + this);
		}
		else
		{
			instance = (T) this;
		}
	}

	// This function is called when the MonoBehaviour will be destroyed.
	protected virtual void OnDestroy()
	{
		if (instance == this)
		{
			instance = null;
		}
	}

}
