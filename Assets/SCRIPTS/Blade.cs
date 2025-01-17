using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] TrailRenderer _bladeTrail;
    private Vector3 mousePosition;
    [SerializeField] private Grabber _grabber;
    [SerializeField] private Basket _basket;

    Plant _plant;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateCut();
        }
    }

    private void UpdateCut()
    {
        if (Input.mousePosition != null)
        {
            mousePosition = Input.mousePosition;
        }
        else if (Input.touchCount > 0)
        {
            mousePosition = Input.GetTouch(0).position;
        }

        transform.position = mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
        {
            if (raycastHit.collider.TryGetComponent(out Plant plant))
            {
                print("задел фрукт");
                plant.CutFruit(_basket);
            }
        }
    }
}