using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class SphereManager : MonoBehaviour
{
    [Header("Configuración de Inputs")]
    public InputActionReference shootAction;
    public InputActionReference destroyAction;

    [Header("Referencias")]
    public GameObject spherePrefab;
    public Transform spawnerTransform; // <-- El nuevo punto de aparición
    public float shootForce = 10f;

    private List<GameObject> spawnedSpheres = new List<GameObject>();

    void OnEnable()
    {
        shootAction.action.performed += ShootSphere;
        destroyAction.action.performed += ClearSpheres;
    }

    void OnDisable()
    {
        shootAction.action.performed -= ShootSphere;
        destroyAction.action.performed -= ClearSpheres;
    }

    private void ShootSphere(InputAction.CallbackContext context)
    {
        // Instanciar en la posición y rotación exacta del Spawner
        GameObject newSphere = Instantiate(spherePrefab, spawnerTransform.position, spawnerTransform.rotation);
        
        Rigidbody rb = newSphere.GetComponent<Rigidbody>();
        if(rb != null)
        {
            // Aplicar fuerza hacia adelante impulsada por el frente del Spawner
            rb.AddForce(spawnerTransform.forward * shootForce, ForceMode.Impulse);
        }
        
        spawnedSpheres.Add(newSphere);
    }

    private void ClearSpheres(InputAction.CallbackContext context)
    {
        foreach(GameObject sphere in spawnedSpheres)
        {
            if(sphere != null)
            {
                Destroy(sphere);
            }
        }
        spawnedSpheres.Clear();
    }
}