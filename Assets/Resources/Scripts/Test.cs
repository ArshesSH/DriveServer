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

	/*--- MonoBehaviour Callbacks ---*/
	void Start()
	{
		SheetDBMS.Instance.PrintSheet( "TestSheet!A1:D4" );
	}


	/*--- Public Methods ---*/


	/*--- Protected Methods ---*/


	/*--- Private Methods ---*/
}