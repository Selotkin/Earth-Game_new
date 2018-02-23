using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetShrinking : MonoBehaviour {

	public float scale = 1;
	// Use this for initialization
	void Start () {
		StartCoroutine (Shrink ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.GameOver) {
			Vector3 newScale = transform.localScale / scale;
			transform.localScale = Vector3.Slerp (transform.localScale, newScale, Time.deltaTime);
		}

	}

	private IEnumerator Shrink()
	{	
		scale += 0.01f;
		yield return new WaitForSeconds (5.0f);
		StartCoroutine (Shrink ());
	}
}
