using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
	private static EventManager s_Instance = null;

	public static EventManager Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = GameObject.FindObjectOfType(typeof(EventManager)) as EventManager;
			}

			return s_Instance;
		}
	}

	public delegate void EventDelegate<T> (T e) where T : GameEvent;
	private delegate void EventDelegate (GameEvent e);
}
