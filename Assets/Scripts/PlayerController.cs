using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Tooltip ("m/s en frame")][SerializeField] float xSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //captura el float horizontal
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical"); // captura el float vertical

        float xOffset = horizontalThrow * xSpeed * Time.deltaTime; //cuanto se mueve en m/s la nave sobre x
        float yOffseet = verticalThrow * xSpeed * Time.deltaTime; // cuanto se mueve en m/s la nave sobre y

        float rawNewXPos = xOffset + transform.localPosition.x; // tranforma la poss  de la nave en el eje X
        float rawNewYPos = yOffseet + transform.localPosition.y; // tranforma la poss  de la nave en el eje y


        float xPos = Mathf.Clamp(rawNewXPos, -4, 4);
        float yPos = Mathf.Clamp(rawNewYPos, -2, 2);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z); // Mueve la nave
    }
}
