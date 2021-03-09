using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{
	string linkURL = "";

	public void OpenLink()
	{
		linkURL = "https://www.cdc.gov/coronavirus/2019-ncov/index.html"; 
		
		#if !UNITY_EDITOR
		openWindow(linkURL);
		#endif
	}



	[DllImport("__Internal")]
	private static extern void openWindow(string url);



}