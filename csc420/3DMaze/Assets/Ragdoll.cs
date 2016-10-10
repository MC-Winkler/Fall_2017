using UnityEngine;
using System.Collections;

public class Ragdoll : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Wait());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
