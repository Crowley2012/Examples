using System;

public class CaesarCipher{
    public static string Caesar(string value, int shift){
	char[] buffer = value.ToCharArray();

	for (int i = 0; i < buffer.Length; i++){
	    char letter = buffer[i];
	    letter = (char)(letter + shift);

	    if (letter > 'z'){
		letter = (char)(letter - 26);
	    }else if (letter < 'a'){
		letter = (char)(letter + 26);
	    }
	
	    buffer[i] = letter;
	}
	return new string(buffer);
    }

    public static void Main(){
	string m1 = "hello";
	string m1e = Caesar(m1, 10);
	string m1d = Caesar(m1e, -10);

	string m2 = "thisisatest";
	string m2e = Caesar(m2, 23);
	string m2d = Caesar(m2e, -23);

	string m3 = "sean";
	string m3e = Caesar(m3, 1);
	string m3d = Caesar(m3e, -1);

	Console.WriteLine(m1);
	Console.WriteLine(m1e);
	Console.WriteLine(m1d);
	Console.WriteLine("\n");
	Console.WriteLine(m2);
	Console.WriteLine(m2e);
	Console.WriteLine(m2d);
	Console.WriteLine("\n");
	Console.WriteLine(m3);
	Console.WriteLine(m3e);
	Console.WriteLine(m3d);
    }
}
