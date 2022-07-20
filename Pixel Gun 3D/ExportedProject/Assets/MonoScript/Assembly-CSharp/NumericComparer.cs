using System.Collections;
using UnityEngine;

public class NumericComparer : IComparer
{
	private static int baseLngth = "multi_skin_".Length;

	public int Compare(object x, object y)
	{
		string name = ((Texture)x).name;
		string name2 = ((Texture)y).name;
		name = name.Substring(baseLngth);
		name2 = name2.Substring(baseLngth);
		int num = int.Parse(name);
		int num2 = int.Parse(name2);
		return num - num2;
	}
}
