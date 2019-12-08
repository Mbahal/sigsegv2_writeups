using System.IO;
using System;

class Program
{
  static void Main()
{
  string key = "funny";
  string input = "xctfclp{T04g_P34I1ht_S0p_yB3_J!a}";
  Console.WriteLine(Cipher(input,key,false));
}
private static string Cipher(string input, string key, bool encipher)
{
  for (int i = 0; i < key.Length; i++)
  {
  bool flag = !char.IsLetter(key[i]);
  if (flag)
    {
    return null;
    }
  }
  string text = string.Empty;
  int num = 0;
  for (int j = 0; j < input.Length; j++)
  {
    bool flag2 = char.IsLetter(input[j]);
    if (flag2)
    {
      bool flag3 = char.IsUpper(input[j]);
      char c = flag3 ? 'A' : 'a';
      int index = (j - num) % key.Length;
      int num2 = (int)((flag3 ? char.ToUpper(key[index]) : char.ToLower(key[index])) - c);
      num2 = (encipher ? num2 : (-num2));
      text += ((char)(Mod((int)input[j] + num2 - (int)c, 26) + (int)c)).ToString();   
    }
    else
    {
      text += input[j].ToString();
      num++;
    }
  }
  return text;
}
private static int Mod(int a, int b)
{
  return (a % b + b) % b;
}
}
	
