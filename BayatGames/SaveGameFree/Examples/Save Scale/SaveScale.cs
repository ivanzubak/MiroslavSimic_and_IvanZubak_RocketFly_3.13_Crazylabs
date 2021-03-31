using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BayatGames.SaveGameFree.Types;

namespace BayatGames.SaveGameFree.Examples
{

	public class SaveScale : MonoBehaviour
	{

		public Transform target;
		public bool loadOnStart = true;
		public string identifier = "exampleSaveScale.dat";
		public float period = 5.0f;
		private float nextActionTime = 0.0f;

		void Start ()
		{
			if ( loadOnStart )
			{
				Load ();
			}
		}

		void Update ()
		{
			Vector3 scale = target.localScale;
			target.localScale = scale;
			
			if (Time.time > nextActionTime)
			{
				nextActionTime += period;
				SaveGame.Save<Vector3Save>(identifier, target.localScale, SerializerDropdown.Singleton.ActiveSerializer);
			}
		}

		void OnApplicationQuit ()
		{
			Save ();
		}

		public void Save ()
		{
			SaveGame.Save<Vector3Save> ( identifier, target.localScale, SerializerDropdown.Singleton.ActiveSerializer );
		}

		public void Load ()
		{
			target.localScale = SaveGame.Load<Vector3Save> (
				identifier,
				new Vector3Save ( 0f, 0f, 0f ),
				SerializerDropdown.Singleton.ActiveSerializer );
		}

	}

}