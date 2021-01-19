
using UnityEngine.Events;

public class GameEvents 
{
	[System.Serializable] public class EventMenuFade : UnityEvent<bool> {};
	[System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> {};
}
