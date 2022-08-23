using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnOnPlane : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> spawnedObejcts = new List<GameObject>();

    private ARRaycastManager _raycastManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    
    void Start()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if(!TryGetTouch(out Vector2 touchPos)) return;
        
        if(_raycastManager.Raycast(touchPos,_hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPos = _hits[0].pose;
            spawnedObejcts.Add(Instantiate(prefab,hitPos.position,hitPos.rotation));
            
        }
        
    }


    private bool TryGetTouch(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            return true;
        }

        touchPos = default;
        return false;
    }
}
