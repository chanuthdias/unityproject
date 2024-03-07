using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    [SerializeField]
    GameObject myPrefab; // Assign this in the inspector with the prefab you want to spawn

    Dictionary<ARTrackedImage, GameObject> spawnedPrefabs = new Dictionary<ARTrackedImage, GameObject>();

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            // Instantiate prefab at the position of the tracked image
            var prefabInstance = Instantiate(myPrefab, newImage.transform.position, newImage.transform.rotation);
            prefabInstance.SetActive(false); // Initially deactivate
            spawnedPrefabs.Add(newImage, prefabInstance);
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Activate or update the prefab only if the tracking state is Tracking
            if (updatedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                GameObject prefabInstance;
                if (spawnedPrefabs.TryGetValue(updatedImage, out prefabInstance))
                {
                    prefabInstance.transform.position = updatedImage.transform.position;
                    prefabInstance.transform.rotation = updatedImage.transform.rotation;
                    prefabInstance.SetActive(true);
                }
            }
            else
            {
                // If it's no longer tracking, deactivate the prefab
                GameObject prefabInstance;
                if (spawnedPrefabs.TryGetValue(updatedImage, out prefabInstance))
                {
                    prefabInstance.SetActive(false);
                }
            }
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Remove the prefab from the scene if the image is no longer tracked
            GameObject prefabInstance;
            if (spawnedPrefabs.TryGetValue(removedImage, out prefabInstance))
            {
                spawnedPrefabs.Remove(removedImage);
                Destroy(prefabInstance);
            }
        }
    }

    void ListAllImages()
        {
            Debug.Log(
                $"There are {m_TrackedImageManager.trackables.count} images being tracked.");

            foreach (var trackedImage in m_TrackedImageManager.trackables)
            {
                Debug.Log($"Image: {trackedImage.referenceImage.name} is at " +
                          $"{trackedImage.transform.position}");
            }
        }

}
