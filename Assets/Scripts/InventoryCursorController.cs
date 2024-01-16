using UnityEngine;
using UnityEngine.UI;
public class InventoryCursorController : MonoBehaviour
{
    bool isLocked;
    void Start()
    {
        SetCursorLock(true);
    }
    void SetCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = isLocked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            SetCursorLock(!isLocked);
    }

}