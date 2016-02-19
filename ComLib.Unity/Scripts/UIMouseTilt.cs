using UnityEngine;

namespace ComLib.Unity.Scripts
{
    /// <summary>
    /// This is just a fancy script to make the main menu look 3D.
    /// It rotates and translates the menu slightly based on the
    /// mouse position
    /// </summary>
    class UIMouseTilt : MonoBehaviour
    {
        public float rotAmount = 10.0f;
        public float panAmount = 20.0f;
        private Vector2 mousePos;

        // Update is called once per frame
        void Update()
        {
            mousePos.x = Input.mousePosition.x / Screen.width - 0.5f;
            mousePos.y = Input.mousePosition.y / Screen.height - 0.5f;

            transform.rotation = Quaternion.Euler(mousePos.y * rotAmount, -mousePos.x * rotAmount, 0);
            transform.position = new Vector3(-mousePos.x * panAmount, -mousePos.y * panAmount, 0);
        }
    }
}
