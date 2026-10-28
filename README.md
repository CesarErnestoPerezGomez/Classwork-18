# Classwork 18 - VR Interaction on Meta Quest

A Unity project for Meta Quest 2 and Meta Quest 3. The activity allows users to grab, release, and throw a cube, shoot spheres in the direction of the left controller, and remove the spawned spheres using another button.

This guide explains how to download the project, build an APK, and install it directly on the headset.

| Detail | Value |
| --- | --- |
| Repository | [CesarErnestoPerezGomez/Classwork-18](https://github.com/CesarErnestoPerezGomez/Classwork-18) |
| Branch used in this guide | `CESAR` |
| Unity version | **6000.5.7f1 (Unity 6.5)** |
| Main scene | `Assets/Scenes/SampleScene.unity` |
| Application name on the headset | `VRTest` |
| Build platform | Android |

## 1. Prerequisites

- A Meta Quest 2 or Meta Quest 3 with both Touch controllers turned on and paired.
- A computer with Unity Hub and an Internet connection to download dependencies.
- A USB-C cable that supports **data transfer**.
- Git or Git Bash, if you download the project using the commands in the next section.
- A Meta developer account that allows you to enable Developer Mode on the headset.

In **Unity Hub > Installs**, install **6000.5.7f1**. If it is already installed, open the menu for that version and select **Add modules**. Include these three components:

- **Android Build Support**.
- **Android SDK & NDK Tools**.
- **OpenJDK**.

Use the Android tools provided by Unity Hub for that version. Refer to [Installing Android dependencies in Unity](https://docs.unity3d.com/6000.5/Documentation/Manual/android-install-dependencies.html) if you need help with this step.

## 2. Download the Repository

### Option A: Git Bash

Open Git Bash in the folder where you want to save the project and run:

```bash
git clone --branch CESAR --single-branch https://github.com/CesarErnestoPerezGomez/Classwork-18.git
cd Classwork-18
git branch --show-current
```

The last command should display `CESAR`. The downloaded folder should contain `Assets`, `Packages`, and `ProjectSettings`.

The branch is specified because the repository page opens `main` by default; this guide uses the project on `CESAR`.

### Option B: Download ZIP

1. Open the repository’s [CESAR branch](https://github.com/CesarErnestoPerezGomez/Classwork-18/tree/CESAR).
2. Select **Code > Download ZIP**.
3. Fully extract the archive.
4. Locate the folder containing `Assets`, `Packages`, and `ProjectSettings`; this is the project root you will open in Unity Hub.

## 3. Open the Project in Unity

1. Open **Unity Hub > Projects**.
2. Select **Add > Add project from disk** and choose the downloaded project’s root folder.
3. Open it with **Unity 6000.5.7f1**.
4. Wait for Unity to finish importing files, downloading packages, and compiling. Opening the project for the first time may take several minutes.
5. In the **Project** window, open `Assets > Scenes > SampleScene`.
6. Check that `XR Origin (XR Rig)`, `Cube`, and `GameManager` appear in the Hierarchy.

Dependencies are declared in `Packages/manifest.json`: Unity restores XR Interaction Toolkit 3.5.1, OpenXR 1.17.1, and Input System 1.20.0, among others. There is no need to create another project or rebuild the scene.

## 4. Set Up and Connect the Meta Quest

1. If you do not have developer access yet, complete the registration, verification, and any team or organization requirements requested by Meta.
2. Open the **Meta Horizon** app on your phone using the account linked to the headset.
3. Select the headset and go to **Headset Settings > Developer Mode**. Enable it.
4. Turn on the headset and connect it to the computer using the USB-C data cable.
5. Put on the headset and accept **Allow USB debugging** for that computer.
6. Keep the headset turned on and connected during installation.

Menu names may vary depending on the language and system version. [Meta’s official guide to testing apps on your device](https://developers.meta.com/vr/documentation/android-apps/enable-developer-mode/) explains Developer Mode and USB authorization.

## 5. Select Android and Review the Settings

1. In Unity, open **File > Build Profiles**.
2. If an Android profile already exists, select it. Otherwise, click **Add Build Profile**, choose **Android**, and add it.
3. Click **Switch Profile** to activate it and wait for the platform switch to finish.
4. Check **Scene List**. `Assets/Scenes/SampleScene.unity` must be enabled and listed as the first scene. If it is missing, open that scene and use **Add Open Scenes**.

The repository already includes the following settings. To check them, open **Edit > Project Settings** and select the **Android** tab in each section:

| Section | Project Setting |
| --- | --- |
| Player > Other Settings > Scripting Backend | `IL2CPP` |
| Player > Other Settings > Target Architectures | `ARM64` |
| Player > Other Settings > Active Input Handling | `Input System Package (New)` |
| XR Plug-in Management | `OpenXR` enabled and XR initialization on startup |
| XR Plug-in Management > OpenXR > Interaction Profiles | `Oculus Touch Controller Profile` |
| XR Plug-in Management > OpenXR | `Meta Quest Support` enabled |
