using System.Collections;
using System.Collections.Generic;
	    public static class ExtensionList
    {
        public static void Swap<T>(this List<T> list, int from, int to)
        {
            T tmp = list[from];
            list[from] = list[to];
            list[to] = tmp;
        }
    }
