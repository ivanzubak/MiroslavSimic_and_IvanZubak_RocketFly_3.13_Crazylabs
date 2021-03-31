using UnityEngine;
using System.Collections;

public class ChangeScale : MonoBehaviour {

	public GameObject Scale;

	public void ScaleTo0()
	{
		Scale.transform.localScale = new Vector3 (0, 0.0f, 0);
	}

	public void ScaleTo1()
	{
		Scale.transform.localScale = new Vector3 (1, 1.0f, 1);
	}
}
