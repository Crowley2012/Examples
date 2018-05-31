using System;

public class Hello{
	public static void Main(string[] args){

		//Print
		Console.WriteLine("Hello World\n");

		//Print number of args
		Console.WriteLine("Number of args: {0}", args.Length);

		//Print args
		for(int i=0; i<args.Length; i++){
			Console.WriteLine("args[{1}] = {0}", args[i], i);
		}

		//Create int array
		int[] nums = new int[3] {1, 2, 3};

		//Array size
		Console.WriteLine("\nArray size : {0}", nums.Length);
		
		//Print array
		for(int i=0; i<nums.Length; i++){
			Console.WriteLine("nums[{0}] = {1}", i, nums[i]);
		}

		//String variable
		string str = "String Variable!";
		Console.WriteLine("\nString length : {0}", str.Length);
		Console.WriteLine(str);
		Console.WriteLine("Last char : {0}\n", str[str.Length-1]);

		//Objects
		Hello test = new Hello();
		test.printVar();
		test.mod();
		test.printVar();

		//Mod array
		nums = test.modArray(nums);
		for(int i=0; i<nums.Length; i++){
			Console.WriteLine("nums[{0}] = {1}", i, nums[i]);
		}
	}

	private string a;
	private int b;

	public Hello(){
		a = "This is an object";
		b = 100;
	}

	public void printVar(){
		Console.WriteLine(a);
		Console.WriteLine("{0}\n", b);
	}

	public void mod(){
		a = "This is a modified object";
		b = 150;
	}

	public int[] modArray(int[] x){
		x[0] = 8;
		x[1]++;
		x[2] += 7;

		return x;
	}
}
