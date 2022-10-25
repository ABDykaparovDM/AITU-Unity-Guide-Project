using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public InputAction inputWASD;
    public InputAction inputInteraction;
    public InputAction attack;
    public Vector2 direction;

    public LevelManager levelManager;
    public Player player;

    private void OnEnable()
    {
        inputWASD.Enable();
        inputInteraction.Enable();
        attack.Enable();
    }

    private void OnDisable()
    {
        inputWASD.Disable();
        inputInteraction.Disable();
        attack.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction = inputWASD.ReadValue<Vector2>();
        if (inputInteraction.triggered)
            levelManager.NextLevel();

        if (attack.triggered)
            player.Attack();
    }
}
