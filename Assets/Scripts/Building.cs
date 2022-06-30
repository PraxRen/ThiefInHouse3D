using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out Thief thief) == true)
        {
            var alarm = gameObject.GetComponentInChildren<Alarm>();
            alarm.TurnOff();
        }
    }
}
