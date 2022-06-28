using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Thief>() == true)
        {
            var alarm = gameObject.GetComponentInChildren<Alarm>();
            alarm.TurnOff();
        }
    }
}
