/******************************************************************************
 * File: RuntimeTrackerController.cs
 * Copyright (c) 2021 Qualcomm Technologies, Inc. and/or its subsidiaries. All rights reserved.
 *  2016-2021 Wikitude GmbH.
 * 
 * Confidential and Proprietary - Qualcomm Technologies, Inc.
 *
 ******************************************************************************/

﻿using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class RuntimeTrackerController : SampleController
{
    /* UI control to specify the URL from which the TargetCollectionResource should be loaded. */
    public InputField Url;
    public GameObject TrackablePrefab;
    public GameObject MarkerInstructions;
    public Text InfoMessage;

    private ImageTracker _currentTracker;
    /* Flag to keep track if a tracker is currently loading. */
    private bool _isLoadingTracker = false;

    public void OnLoadTracker() {
        if (_isLoadingTracker) {
            /* Wait until previous request was completed. */
            return;
        }
        /* Destroy any previously loaded tracker. */
        if (_currentTracker != null) {
            Destroy(_currentTracker.gameObject);
        }

        _isLoadingTracker = true;

        /* Create and configure the tracker. */
        GameObject trackerObject = new GameObject("ImageTracker");
        _currentTracker = trackerObject.AddComponent<ImageTracker>();
        _currentTracker.TargetSourceType = TargetSourceType.TargetCollectionResource;
        _currentTracker.TargetCollectionResource = new TargetCollectionResource();
        _currentTracker.TargetCollectionResource.UseCustomURL = true;
        _currentTracker.TargetCollectionResource.TargetPath = Url.text;

        _currentTracker.TargetCollectionResource.OnFinishLoading.AddListener(OnFinishLoading);
        _currentTracker.TargetCollectionResource.OnErrorLoading.AddListener(OnErrorLoading);

        _currentTracker.OnTargetsLoaded.AddListener(OnTargetsLoaded);
        _currentTracker.OnErrorLoadingTargets.AddListener(OnErrorLoadingTargets);
        _currentTracker.OnInitializationError.AddListener(OnInitializationError);

        /* Create and configure the trackable. */
        GameObject trackableObject = GameObject.Instantiate(TrackablePrefab);
        trackableObject.transform.SetParent(_currentTracker.transform, false);
    }

    public override void OnTargetsLoaded() {
        base.OnTargetsLoaded();
        MarkerInstructions.SetActive(true);
        _isLoadingTracker = false;
        InfoMessage.text = "";
    }

    public override void OnErrorLoadingTargets(Error error) {
        base.OnErrorLoadingTargets(error);
        _isLoadingTracker = false;
        InfoMessage.text = "The following error occurred when loading the instant target. " +
            "Error code: " + error.Code + " domain: " + error.Domain + " message: " + error.Message;
    }
}
