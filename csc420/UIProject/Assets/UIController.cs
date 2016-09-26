using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class UIController : MonoBehaviour {

	[SerializeField] private Text nameLabel;
	[SerializeField] private Popup settingsPopup; 

	// Use this for initialization
	void Start () {
		settingsPopup.Close ();
	}    
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnOpenSettings(){
		settingsPopup.Open ();
	} 

	public void OnSubmitName(string name){
		Debug.Log ("in OSN and name = " + name);
		nameLabel.text = name;
	} 


}
