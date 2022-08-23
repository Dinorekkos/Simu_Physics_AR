using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageIdentifier : MonoBehaviour
{
    private ARTrackedImageManager _imageManager;
    void Start()
    {
        _imageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _imageManager.trackedImagesChanged += OnImageChange;
    }

    private void OnDisable()
    {
        _imageManager.trackedImagesChanged -= OnImageChange;

    }

    void OnImageChange(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var item in args.added)
        {
            Debug.Log(item.referenceImage.name);
        }
    }
}
