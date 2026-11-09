using UnityEngine;
using System.Collections;

public class Localizacion : MonoBehaviour
{
    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)
            Debug.Log("Location not enabled on device or app does not have permission to access location");

        float desiredAccuracyInMeters = 10f;
        float updateDistanceInMeters = 10f;
        
        Input.location.Start(desiredAccuracyInMeters, updateDistanceInMeters);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determinate device location");
            yield break;
        }
        else
        {

            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy);
            
        }
        Input.location.Stop();
    }
   
}
