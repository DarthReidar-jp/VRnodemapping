using UnityEngine;

public class KeepLocalPosition : MonoBehaviour
{
    Vector3 ownInitialLocalPos;

    void Awake()
    {
        ownInitialLocalPos = transform.localPosition;
    }

    void Update()
    {
        Vector3 parentPos = transform.parent.position;
        transform.position = parentPos + ownInitialLocalPos;
    }
}