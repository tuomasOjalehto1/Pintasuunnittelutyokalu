using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]


public class ARPainaJaLisaa : MonoBehaviour
{
    //N‰m‰ hommat m‰‰ritet‰‰n toisessa skriptiss‰
    public GameObject gameObjectToInstantiateTO;

    public GameObject spawnedObjectTO;
    private ARRaycastManager _arRaycastManagerTO;
    private Vector2 touchPositionTO;

    public static ARPainaJaLisaa instanssi;
    



    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManagerTO = GetComponent<ARRaycastManager>();

        if (instanssi == null)
        {
            instanssi = this;
        }


    }

    bool TryGetTouchPosition(out Vector2 touchPositionTO)
    {
        if(Input.touchCount > 0) 
        {
            touchPositionTO = Input.GetTouch(0).position;
            return true;
        }
        touchPositionTO = default;
        return false;
    }

   
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPositionTO))
        {
            return;
        }

        if(_arRaycastManagerTO.Raycast(touchPositionTO,hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if(spawnedObjectTO == null)
            {
                spawnedObjectTO = Instantiate(gameObjectToInstantiateTO, hitPose.position, hitPose.rotation);
            }
            /*else
            {
                spawnedObjectTO.transform.position = hitPose.position;
            }*/

            //T‰m‰n pit‰isi saada objekti k‰‰ntym‰‰n esim sein‰n tai lattian mukaan pystyyn tai vaakaan.
            else
            {
                spawnedObjectTO.transform.position = hitPose.position;

                
                spawnedObjectTO.transform.rotation = hitPose.rotation;
            }
        }
    }
}
