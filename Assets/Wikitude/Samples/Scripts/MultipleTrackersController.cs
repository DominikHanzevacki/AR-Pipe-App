/******************************************************************************
 * File: MultipleTrackersController.cs
 * Copyright (c) 2021 Qualcomm Technologies, Inc. and/or its subsidiaries. All rights reserved.
 *  2016-2021 Wikitude GmbH.
 * 
 * Confidential and Proprietary - Qualcomm Technologies, Inc.
 *
 ******************************************************************************/

﻿using UnityEngine;
using Wikitude;

public class MultipleTrackersController : SampleController
{
    public ImageTracker MarkerTracker;
    public ImageTracker FarmerTracker;

    /* Prefabs that display which targets should be scanned, based on which tracker is active. */
    public GameObject MarkerInstructions;
    public GameObject FarmerInstructions;

    /* Flag to keep track if the Wikitude SDK is currently transitioning from one tracker to another.
     * We shouldn't start another transition until the previous one completed.
     */
    private bool _waitingForTrackerToLoad = false;

    public void OnTrackCar() {
        if (!MarkerTracker.enabled && !_waitingForTrackerToLoad) {
            _waitingForTrackerToLoad = true;

            FarmerInstructions.SetActive(false);
            MarkerInstructions.SetActive(true);

            MarkerTracker.enabled = true;
        }
    }

    public void OnTrackFarmer() {
        if (!FarmerTracker.enabled && !_waitingForTrackerToLoad) {
            _waitingForTrackerToLoad = true;
            FarmerInstructions.SetActive(true);

            MarkerInstructions.SetActive(false);

            FarmerTracker.enabled = true;
        }
    }

    public override void OnTargetsLoaded() {
        _waitingForTrackerToLoad = false;
    }
}
