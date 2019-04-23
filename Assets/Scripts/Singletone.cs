using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletone
{
	private static Singletone _instance;

	public static Singletone Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = new Singletone();
			}

			return _instance;
		}
	}
}
