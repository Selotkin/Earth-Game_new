using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour {

    public GameObject meteor;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}
    private IEnumerator Spawn()
    {	
		float theta = Mathf.Deg2Rad * Random.Range(0, 180);
		float phi = Mathf.Deg2Rad * Random.Range(0, 360);
        float x = 50 * Mathf.Sin(theta) * Mathf.Cos(phi);
        float y = 50 * Mathf.Sin(theta) * Mathf.Sin(phi);
        float z = 50 * Mathf.Cos(theta);
        Vector3 pos = new Vector3(x, y, z);
        GameObject newMeteor = Instantiate(meteor) as GameObject;
        newMeteor.transform.position = pos;
        yield return new WaitForSeconds(0.1f);
		if(!GameManager.instance.GameOver)
        	StartCoroutine(Spawn());
    }
}
