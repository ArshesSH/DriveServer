using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

public class SheetReader
{
    /*--- Constructor ---*/
    static SheetReader()
    {
        //  Loading private key from resources as a TextAsset
        string key = Resources.Load<TextAsset>( "Creds/key" ).ToString();

        Debug.Log( key );

        // Creating a  ServiceAccountCredential.Initializer
        // ref: https://googleapis.dev/dotnet/Google.Apis.Auth/latest/api/Google.Apis.Auth.OAuth2.ServiceAccountCredential.Initializer.html
        ServiceAccountCredential.Initializer initializer = new ServiceAccountCredential.Initializer( serviceAccountID );

        // Getting ServiceAccountCredential from the private key
        // ref: https://googleapis.dev/dotnet/Google.Apis.Auth/latest/api/Google.Apis.Auth.OAuth2.ServiceAccountCredential.html
        ServiceAccountCredential credential = new ServiceAccountCredential( initializer.FromPrivateKey( key ) );

        service = new SheetsService(
            new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
            }
        );
    }

    //static SheetReader()
    //{
    //    string fullJsonPath = Application.dataPath + jsonPath;
    //    Stream jsonCreds = (Stream)File.Open( fullJsonPath, FileMode.Open );

    //    ServiceAccountCredential credential = ServiceAccountCredential.FromServiceAccountData( jsonCreds );

    //    service = new SheetsService(
    //        new BaseClientService.Initializer()
    //        {
    //            HttpClientInitializer = credential,
    //        }
    //    );
    //}

    /*--- Public Fields ---*/


    /*--- Protected Fields ---*/


    /*--- Private Fields ---*/
    static string spreadsheetId = "1PkeWS0iVfICh46A_vWJbzYVkEcxsMy-mdwMaZECd2s0";
	static string serviceAccountID = "testaccount@snappy-abode-365300.iam.gserviceaccount.com";
    static string jsonPath = "/StreamingAssets/Credentials/snappy-abode-365300-40c566526c2b.json";

    static SheetsService service;


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

    public void PrintSheet(string sheetNameAndRange)
    {
        var request = service.Spreadsheets.Values.Get( spreadsheetId, sheetNameAndRange );
        ValueRange response = request.Execute();
        IList<IList<object>> values = response.Values;
        if ( values != null && values.Count > 0 )
        {
            foreach(var row in values)
            {
                Debug.Log( $"{row[0]}, {row[4]}" );
            }
        }
        else
        {
            Debug.Log( "No data found." );
        }
    }

    /*--- Protected Methods ---*/


    /*--- Private Methods ---*/

}