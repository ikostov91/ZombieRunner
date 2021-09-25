using Assets.Scripts.Constants;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _mainCamera;

    private void Awake()
    {
        this._mainCamera = GameObject.FindGameObjectWithTag(TagConstants.MainCamera).transform;
    }

    private void LateUpdate()
    {
        this.transform.LookAt(this.transform.position + this._mainCamera.forward);
    }
}
