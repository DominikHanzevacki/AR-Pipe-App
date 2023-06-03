/******************************************************************************
 * File: MenuController.cs
 * Copyright (c) 2021 Qualcomm Technologies, Inc. and/or its subsidiaries. All rights reserved.
 *  2016-2021 Wikitude GmbH.
 * 
 * Confidential and Proprietary - Qualcomm Technologies, Inc.
 *
 ******************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Wikitude;

public class MenuController : MonoBehaviour
{
    public GameObject InfoPanel;

    public Text VersionNumberText;
    public Text BuildDateText;
    public Text BuildNumberText;
    public Text BuildConfigurationText;
    public Text UnityVersionText;

    private void Awake() {
        /* Allow the screen to sleep in the main menu */
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }

    public void OnSampleButtonClicked(Button sender) {
        /* Start the appropriate scene based on the button name that was pressed. */
        SceneManager.LoadScene(sender.name);
    }

    public void OnInfoButtonPressed() {
        /* Display the info panel, which contains additional information about the Wikitude SDK. */
        InfoPanel.SetActive(true);

        var buildInfo = WikitudeSDK.BuildInformation;
        VersionNumberText.text = buildInfo.SDKVersion;
        BuildDateText.text = buildInfo.BuildDate;
        BuildNumberText.text = buildInfo.BuildNumber;
        BuildConfigurationText.text = buildInfo.BuildConfiguration;
        UnityVersionText.text = Application.unityVersion;
    }

    public void OnInfoDoneButtonPressed() {
        InfoPanel.SetActive(false);
    }

    void Update() {
        /* Also handles the back button on Android */
        if (Input.GetKeyDown(KeyCode.Escape)) {
            /* There is nowhere else to go back, so quit the app. */
            Application.Quit();
        }
    }
}