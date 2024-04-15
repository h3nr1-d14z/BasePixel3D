

using System;
using System.Collections.Generic;
using UnityEngine;

public class UniAndroidQueryPermission : MonoBehaviour
{
	public static Queue<AndroidPermission> permissionQueue = new Queue<AndroidPermission>();

	public static Action allPermissionRequested; 

	public static void RequestPermissions(List<AndroidPermission> listPermission)
	{
		foreach (AndroidPermission item in listPermission)
		{
			UniAndroidQueryPermission.permissionQueue.Enqueue(item);
		}
		UniAndroidQueryPermission.allPermissionRequested = delegate
		{
		};
		UniAndroidQueryPermission.RequestPermission();
	}

	private static void RequestPermission()
	{
		if (UniAndroidQueryPermission.permissionQueue.Count > 0)
		{
			AndroidPermission permission = UniAndroidQueryPermission.permissionQueue.Dequeue();
			UniAndroidPermission.RequestPermission(permission, new Action(UniAndroidQueryPermission.RequestPermission), new Action(UniAndroidQueryPermission.RequestPermission));
		}
		else
		{
			UniAndroidQueryPermission.allPermissionRequested();
		}
	}
}


