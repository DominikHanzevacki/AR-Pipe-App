/******************************************************************************
 * File: ExtendedImageTrackingController.cs
 * Copyright (c) 2021 Qualcomm Technologies, Inc. and/or its subsidiaries. All rights reserved.
 *  2018-2021 Wikitude GmbH.
 *
 * Confidential and Proprietary - Qualcomm Technologies, Inc.
 *
 ******************************************************************************/

using System;
﻿using UnityEngine;
using UnityEngine.UI;
using Wikitude;

[Obsolete("This controller is deprecated and will be removed in future releases")]
public class ExtendedImageTrackingController : SampleController
{
    public ImageTracker Tracker;

    public Text TrackingQualityText;
    public Image TrackingQualityBackground;
    public GameObject StopExtendedTrackingButton;

    protected override void Start() {
        base.Start();
        /* Hide the Stop Extended Tracking button until a target is recognized. */
        StopExtendedTrackingButton.SetActive(false);
    }

    [Obsolete("This method is deprecated and will be removed in future releases")]
    public void OnStopExtendedTrackingButtonPressed() {
        Tracker.StopExtendedTracking();
        /* Hide the Stop Extended Tracking button until a target is recognized. */
        StopExtendedTrackingButton.SetActive(false);
        /* Also hide the status text until we recognize the target again. */
        TrackingQualityText.text = "";
    }

    [Obsolete("This method is deprecated and will be removed in future releases")]
    public void OnExtendedTrackingQualityChanged(ImageTarget target, ExtendedTrackingQuality oldQuality, ExtendedTrackingQuality newQuality) {
        /* Update the UI based on the new extended tracking quality. */
        switch (newQuality) {
        case ExtendedTrackingQuality.Bad:
            TrackingQualityText.text = "Target: " + target.Name + " Quality: Bad";
            TrackingQualityBackground.color = Color.red;
            break;
        case ExtendedTrackingQuality.Average:
            TrackingQualityText.text = "Target: " + target.Name + " Quality: Average";
            TrackingQualityBackground.color = Color.yellow;
            break;
        case ExtendedTrackingQuality.Good:
            TrackingQualityText.text = "Target: " + target.Name + " Quality: Good";
            TrackingQualityBackground.color = Color.green;
            break;
        default:
            break;
        }
    }

    [Obsolete("This method is deprecated and will be removed in future releases")]
    public void OnImageRecognized(ImageTarget target) {
        /* Now that a target was recognized, show the Stop Extended Tracking button. */
        StopExtendedTrackingButton.SetActive(true);
    }

    [Obsolete("This method is deprecated and will be removed in future releases")]
    public void OnImageLost(ImageTarget target) {
        TrackingQualityText.text = "Target lost";
        TrackingQualityBackground.color = Color.white;
    }
}
