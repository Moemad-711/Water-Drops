using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logout : MonoBehaviour
{
    public void LogOut()
    {
        StartCoroutine(MainScript.Instance.Web.Logout());
    }
}
