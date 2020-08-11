using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace InputManager
{
    public class InputManager : MonoBehaviour
    {
        public List<ButtonHandler> allButtonsHandlers = new List<ButtonHandler>();
        public List<AxisHandler> allAxisHandlers = new List<AxisHandler>();
        public List<AxisHandler2D> allAxisHandlers2D = new List<AxisHandler2D>();

        private XRController controller;
        public bool verifyEveryFrame = true;
        public float timeHandle = 0.01f;

        private void Start()
        {
            controller = GetComponent<XRController>();
            StartCoroutine(UpdateHandler());
        }

        private IEnumerator UpdateHandler()
        {
            HandleButtonEvents();
            HandleAxis2dEvents();
            HandleAxisEvents();

            if (verifyEveryFrame)
                yield return new WaitForEndOfFrame();
            else
                yield return new WaitForSeconds(timeHandle);

            StartCoroutine(UpdateHandler());
        }

        private void HandleButtonEvents()
        {
            foreach (ButtonHandler handler in allButtonsHandlers)
            {
                handler.HandleState(controller);
            }
        }

        private void HandleAxis2dEvents()
        {
            foreach (AxisHandler2D handler in allAxisHandlers2D)
            {
                handler.HandleState(controller);
            }
        }

        private void HandleAxisEvents()
        {
            foreach (AxisHandler handler in allAxisHandlers)
            {
                handler.HandleState(controller);
            }
        }
    }
}