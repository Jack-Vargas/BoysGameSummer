using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GunAim : MonoBehaviour
{
    public Transform gunParent;
    public Transform gun;
    public InputAction AimAction;
    private float gunHeight; // I know this isn't optimal

    public void Start()
    {
        //AimAction = InputSystem.actions.FindAction("Look");
        gunHeight = gun.localScale.y;
    }

    public void Update()
    {        
        //Vector2 input = AimAction.ReadValue<Vector2>();
        //gunParent.right = input;

          
    }

    public void AdjustAim(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        gunParent.right = input;

        if (input.x < 0)
        {
            gun.localScale = new Vector3(gun.localScale.x, gunHeight * -1, 1f);
        }
        else
        {
            gun.localScale = new Vector3(gun.localScale.x, gunHeight, 1f);
        }
    }
}

