using UnityEngine;
using Vuforia;

public class MyTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    [SerializeField] private TrackableBehaviour trackableBehaviour;
    [SerializeField] private GameObject canvasControllers;

    private void Start()
    {
        trackableBehaviour.RegisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            canvasControllers.SetActive(true);
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            canvasControllers.SetActive(false);
        }
        else
        {
            canvasControllers.SetActive(false);
        }
    }
}