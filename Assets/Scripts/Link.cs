using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{
	public string linkURL = "";

	public void OpenLink()
	{	
		#if !UNITY_EDITOR
		openWindow(linkURL);
		#endif
	}



	[DllImport("__Internal")]
	private static extern void openWindow(string url);



}