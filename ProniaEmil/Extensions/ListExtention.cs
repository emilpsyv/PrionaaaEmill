using System.Text;

namespace ProniaEmil.Extentions
{
    public static class ListExtention
    {     
            public static string Bind(this IEnumerable<string>? list, char letter)
            {
                if (list?.Count() == 0) return string.Empty;
                StringBuilder sb = new StringBuilder();
                foreach (string item in list)
                {
                    sb.Append(item);
                    sb.Append(letter);
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
        
    }
}
