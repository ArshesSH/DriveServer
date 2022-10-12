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
		SheetDBMS.Instance.PrintSheet( "Sheet1!A1	" );
	}
	void Update()
	{
		
	}


	/*--- Public Methods ---*/


	/*--- Protected Methods ---*/


	/*--- Private Methods ---*/
}