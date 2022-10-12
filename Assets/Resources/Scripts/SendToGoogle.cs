using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{
	/*--- Public Fields ---*/
	public InputField IdInputField;
	public InputField PasswordInputField;

	/*--- Protected Fields ---*/


	/*--- Private Fields ---*/
	[SerializeField]
	string baseURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdZ5h8CbQTdJQSjIP41NJex-Tksj8V6MNr84Q5xuIrO040q6A/formResponse";
	string Id;
	string Password;

	/*--- MonoBehaviour Callbacks ---*/



	/*--- Public Methods ---*/
	public void Send()
    {
		Id = IdInputField.text;
		Password = PasswordInputField.text;
    }

	/*--- Protected Methods ---*/


	/*--- Private Methods ---*/
	IEnumerator Post(string id, string password)
    {
		WWWForm form = new WWWForm();
		form.AddField( "", id );
		form.AddField( "", password );
		byte[] rawData = form.data;
		WWW www = new WWW( baseURL, rawData );
		yield return www;
    }
}