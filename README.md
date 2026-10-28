# Classwork 18 - Interacción VR en Meta Quest

Proyecto de Unity para Meta Quest 2 y Meta Quest 3. La actividad permite agarrar, soltar y lanzar un cubo, disparar esferas en la dirección del control izquierdo y eliminar las esferas generadas con otro botón.

Esta guía explica cómo descargar el proyecto, generar un APK e instalarlo directamente en el visor.

| Dato | Valor |
| --- | --- |
| Repositorio | [CesarErnestoPerezGomez/Classwork-18](https://github.com/CesarErnestoPerezGomez/Classwork-18) |
| Rama utilizada en esta guía | `CESAR` |
| Versión de Unity | **6000.5.7f1 (Unity 6.5)** |
| Escena principal | `Assets/Scenes/SampleScene.unity` |
| Nombre de la aplicación en el visor | `VRTest` |
| Plataforma de compilación | Android |

## 1. Preparar lo necesario

- Meta Quest 2 o Meta Quest 3 con sus dos controles Touch encendidos y vinculados.
- Una computadora con Unity Hub y conexión a Internet para descargar las dependencias.
- Un cable USB-C que permita **transferencia de datos**.
- Git o Git Bash, si se descarga mediante los comandos de la siguiente sección.
- Una cuenta de desarrollador de Meta habilitada para activar el modo desarrollador del visor.

En **Unity Hub > Installs**, instala **6000.5.7f1**. Si ya está instalada, abre el menú de esa versión y selecciona **Add modules**. Incluye estos tres componentes:

- **Android Build Support**.
- **Android SDK & NDK Tools**.
- **OpenJDK**.

Utiliza las herramientas Android proporcionadas por Unity Hub para esa versión. Consulta la [instalación de dependencias de Android en Unity](https://docs.unity3d.com/6000.5/Documentation/Manual/android-install-dependencies.html) si necesitas revisar este paso.

## 2. Descargar el repositorio

### Opción A: Git Bash

Abre Git Bash en la carpeta donde quieras guardar el proyecto y ejecuta:

```bash
git clone --branch CESAR --single-branch https://github.com/CesarErnestoPerezGomez/Classwork-18.git
cd Classwork-18
git branch --show-current
```

El último comando debe mostrar `CESAR`. La carpeta descargada debe contener `Assets`, `Packages` y `ProjectSettings`.

Se especifica la rama porque la página del repositorio abre `main` de forma predeterminada; para seguir esta guía se utiliza el proyecto de `CESAR`.

### Opción B: Descargar ZIP

1. Abre la [rama CESAR del repositorio](https://github.com/CesarErnestoPerezGomez/Classwork-18/tree/CESAR).
2. Selecciona **Code > Download ZIP**.
3. Extrae el archivo completamente.
4. Localiza la carpeta que contiene `Assets`, `Packages` y `ProjectSettings`; esa es la raíz del proyecto que abrirás en Unity Hub.

## 3. Abrir el proyecto en Unity

1. Abre **Unity Hub > Projects**.
2. Selecciona **Add > Add project from disk** y elige la raíz del proyecto descargado.
3. Ábrelo con **Unity 6000.5.7f1**.
4. Espera a que Unity termine de importar los archivos, descargar los paquetes y compilar. La primera apertura puede tardar varios minutos.
5. En la ventana **Project**, abre `Assets > Scenes > SampleScene`.
6. Comprueba que en la jerarquía aparezcan `XR Origin (XR Rig)`, `Cube` y `GameManager`.

Las dependencias están declaradas en `Packages/manifest.json`: Unity restaura, entre otras, XR Interaction Toolkit 3.5.1, OpenXR 1.17.1 e Input System 1.20.0. No hace falta crear otro proyecto ni reconstruir la escena.

## 4. Preparar y conectar el Meta Quest

1. Si aún no tienes acceso de desarrollador, completa el registro, la verificación y los requisitos de equipo u organización que solicite Meta.
2. Abre la aplicación **Meta Horizon** en el teléfono con la cuenta vinculada al visor.
3. Selecciona el visor y entra en **Headset Settings / Configuración del visor > Developer Mode / Modo desarrollador**. Actívalo.
4. Enciende el visor y conéctalo a la computadora mediante el cable USB-C de datos.
5. Ponte el visor y acepta **Allow USB debugging / Permitir depuración USB** para esa computadora.
6. Mantén el visor encendido y conectado durante la instalación.

Los nombres de los menús pueden variar con el idioma y la versión del sistema. La [guía oficial de Meta para probar aplicaciones en el dispositivo](https://developers.meta.com/vr/documentation/android-apps/enable-developer-mode/) detalla el modo desarrollador y la autorización USB.

## 5. Seleccionar Android y revisar la configuración

1. En Unity, abre **File > Build Profiles**.
2. Si ya existe un perfil Android, selecciónalo. Si no existe, pulsa **Add Build Profile**, elige **Android** y añádelo.
3. Pulsa **Switch Profile** para activarlo y espera a que termine el cambio de plataforma.
4. Revisa **Scene List**. `Assets/Scenes/SampleScene.unity` debe estar habilitada y ser la primera escena. Si falta, abre esa escena y usa **Add Open Scenes**.

El repositorio ya incluye los siguientes ajustes. Si necesitas comprobarlos, abre **Edit > Project Settings** y revisa la pestaña de **Android** en cada apartado:

| Apartado | Configuración del proyecto |
| --- | --- |
| Player > Other Settings > Scripting Backend | `IL2CPP` |
| Player > Other Settings > Target Architectures | `ARM64` |
| Player > Other Settings > Active Input Handling | `Input System Package (New)` |
| XR Plug-in Management | `OpenXR` activado e inicialización de XR al arrancar |
| XR Plug-in Management > OpenXR > Interaction Profiles | `Oculus Touch Controller Profile` |
| XR Plug-in Management > OpenXR | `Meta Quest Support` habilitado |

