using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BAB.Movement;

namespace BAB.Control
{
    public class PlayerController : MonoBehaviour
    {

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }
        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                GetComponent<Move>().MoveTo(hit.point);
            }
        }
    }
}