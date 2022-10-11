using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public struct Data
{
	public string Name;
	public long Score;
	public string ImgSrc;
}

public class DriveTest : MonoBehaviour
{
	/*--- Public Fields ---*/


	/*--- Private Fields ---*/
	[SerializeField]
	TextMeshProUGUI uiNameTMP;
	[SerializeField]
	TextMeshProUGUI uiScoreTMP;
	[SerializeField]
	Image uiImage;

	string jsonURL = "https://drive.google.com/uc?export=download&id=1dXwlvntgmkvv-NMV6GvkkviRDMNbiIss";
	string imgURL = "https://drive.google.com/uc?export=download&id=18f0Ql4uJvVo7DZxr-cCeGDB0v5n5fze5";

	/*--- MonoBehaviour Callbacks ---*/
	void Start()
	{
		StartCoroutine(GetData(jsonURL));
	}
	void Update()
	{
		
	}


	/*--- Public Methods ---*/


	/*--- Protected Methods ---*/


	/*--- Private Methods ---*/
	IEnumerator GetData(string url)
    {
		UnityWebRequest request = UnityWebRequest.Get(url);
		yield return request.SendWebRequest();

		if(request.isDone)
        {
			Data data = JsonUtility.FromJson<Data>(request.downloadHandler.text);

			uiNameTMP.text = data.Name;
			uiScoreTMP.text = data.Score.ToString();

			//StartCoroutine(GetImage(imgURL));
        }

		request.Dispose();
    }
	//IEnumerator GetImage(string url)
	//{
	//	UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
	//	yield return request.SendWebRequest();

	//	if (request.isDone)
	//	{
	//		uiImage.sprite = Sprite.Create()
	//	}
	//	request.Dispose();
	//}
}