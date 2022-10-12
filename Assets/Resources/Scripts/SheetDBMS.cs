using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;

using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;


public class SheetDBMS : MonoBehaviour
{
	/*--- Singleton ---*/
	public static SheetDBMS Instance
    {
        get
        {
			if(instance == null)
            {
				GameObject obj = new GameObject( "_SheetDBMS" );
				instance = obj.AddComponent<SheetDBMS>();
            }
			return instance;
        }
    }
	static SheetDBMS instance;

	/*--- Public Fields ---*/


	/*--- Protected Fields ---*/


	/*--- Private Fields ---*/
	string spreadsheetId = "1PkeWS0iVfICh46A_vWJbzYVkEcxsMy-mdwMaZECd2s0";
	string serviceAccountID = "testaccount@snappy-abode-365300.iam.gserviceaccount.com";
	string jsonPath = "/StreamingAssets/Credentials/snappy-abode-365300-40c566526c2b.json";

	SheetsService service;

	string range = "Sheet1";
	List<object> objList = new List<object>() { "new Sheet2" };
	ValueRange valueRange = new ValueRange();



	/*--- MonoBehaviour Callbacks ---*/
	void Start()
	{
        ////  Loading private key from resources as a TextAsset
        //string key = Resources.Load<TextAsset>( "Creds/key" ).ToString();

        //Debug.Log( key );

        //// Creating a  ServiceAccountCredential.Initializer
        //// ref: https://googleapis.dev/dotnet/Google.Apis.Auth/latest/api/Google.Apis.Auth.OAuth2.ServiceAccountCredential.Initializer.html
        //ServiceAccountCredential.Initializer initializer = new ServiceAccountCredential.Initializer( serviceAccountID );

        //// Getting ServiceAccountCredential from the private key
        //// ref: https://googleapis.dev/dotnet/Google.Apis.Auth/latest/api/Google.Apis.Auth.OAuth2.ServiceAccountCredential.html
        //ServiceAccountCredential credential = new ServiceAccountCredential( initializer.FromPrivateKey( key ) );

        //service = new SheetsService(
        //    new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //    }
        //);


        string fullJsonPath = Application.dataPath + jsonPath;
        Stream jsonCreds = (Stream)File.Open( fullJsonPath, FileMode.Open );

        ServiceAccountCredential credential = ServiceAccountCredential.FromServiceAccountData( jsonCreds );

        service = new SheetsService(
            new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
            }
        );
        if (service != null)
		{
			Debug.Log( "DBMS Connected" );
		}
		else
        {
			Debug.LogError( "Cannot connet to DBMS" );
        }
    }


	/*--- Public Methods ---*/
	public IList<IList<object>> getSheetRange( String sheetNameAndRange )
	{
		SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get( spreadsheetId, sheetNameAndRange );

		ValueRange response = request.Execute();
		IList<IList<object>> values = response.Values;
		if ( values != null && values.Count > 0 )
		{
			return values;
		}
		else
		{
			Debug.Log( "No data found." );
			return null;
		}
	}

	public void PrintSheet( string sheetNameAndRange )
	{
		var request = service.Spreadsheets.Values.Get( spreadsheetId, "Sheet1" );
		ValueRange response = request.Execute();
		IList<IList<object>> values = response.Values;
		if ( values != null && values.Count > 0 )
		{
			foreach ( var row in values )
			{
				Debug.Log( $"{row[0]}, {row[4]}" );
			}
		}
		else
		{
			Debug.Log( "No data found." );
		}
	}

	public void AddSheet()
    {

    }


	/*--- Protected Methods ---*/


	/*--- Private Methods ---*/
}