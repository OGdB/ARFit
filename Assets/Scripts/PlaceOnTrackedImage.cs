using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaceOnTrackedImage : MonoBehaviour
{
    public ARTrackedImageManager _trackedImageManager;

    public GameObject arPrefab;
    private Rigidbody rb;
    private DressMaterials dressMaterials;

    private void Awake()
    {
        arPrefab = Instantiate(arPrefab);
        rb = arPrefab.GetComponent<Rigidbody>();
        dressMaterials = arPrefab.GetComponent<DressMaterials>();
        arPrefab.name = _trackedImageManager.referenceLibrary[0].name;
        arPrefab.SetActive(false);
    }

    private void OnEnable()
    {
        _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;

    }

    private void OnDestroy()
    {
        _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

/*    private void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Change clothes
                dressMaterials.ChangeCloth();
            }
        }
    }*/


    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    { 
        // Which image is recognized?s
        foreach (var trackedImage in eventArgs.added)
        {
            arPrefab.SetActive(true);
            rb.MovePosition(trackedImage.transform.position);
            rb.MoveRotation(trackedImage.transform.rotation);
        }

        // foreach currently tracked image, set their 
        foreach (var trackedImage in eventArgs.updated)
        {
            rb.MovePosition(trackedImage.transform.position);
            rb.MoveRotation(trackedImage.transform.rotation);
            arPrefab.SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            arPrefab.SetActive(false);
        }
    }

}