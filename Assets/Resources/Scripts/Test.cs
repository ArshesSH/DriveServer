using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	/*--- Public Fields ---*/
	public string Name;
	public int Qty;

	/*--- Protected Fields ---*/


	/*--- Private Fields ---*/
	SheetReader sheetReader;

	/*--- MonoBehaviour Callbacks ---*/
	void Start()
	{
		sheetReader.getSheetRange( "Sheet1" );
	}
	void Update()
	{
		
	}


	/*--- Public Methods ---*/


	/*--- Protected Methods ---*/


	/*--- Private Methods ---*/
}