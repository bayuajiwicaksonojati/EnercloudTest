namespace Utilities{
    public static class StringHelper{
        public static List<int> AllIndexOf(this string textToCompare, string comparer)
        {
            if(string.IsNullOrEmpty(textToCompare) || string.IsNullOrEmpty(comparer)) throw new ArgumentNullException("The Text and Comparer string cannot be null or empty");
            textToCompare = textToCompare.ToLower();
            comparer = comparer.ToLower();
            List<int> indexPool = new List<int>();
            int i = textToCompare.IndexOf(comparer);
            while(i!=-1)
            {
                indexPool.Add(i);
                i = textToCompare.IndexOf(comparer, i+1);
            }
            return indexPool;
        }
    }
}