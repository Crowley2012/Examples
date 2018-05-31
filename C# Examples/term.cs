using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
class Program{

	//Converts infix to postfix notation
	public static void InfixToPostfixConvert(ref string infixBuffer, out string postfixBuffer){
		int priority = 0;
		postfixBuffer = "";
 
		//Stack containing equation elements
		Stack<Char> s1 = new Stack<char>();
 
		for (int i = 0; i < infixBuffer.Length; i++){
			char ch = infixBuffer[i];

			//Checks for special charachters 
			if (ch == '+' || ch == '-' || ch == '*' || ch == '/'){
				//Check the precedence
				if (s1.Count <= 0){
					s1.Push(ch);
				}else{
					//Sets the priority of special charachters
					if (s1.Peek() == '*' || s1.Peek() == '/'){
						priority = 1;
					}else{
						priority = 0;
					}

					//Adds elements of equation based on their priority
					if (priority == 1){
						if (ch == '+' || ch == '-'){
							postfixBuffer += s1.Pop();
							i--;
						}else{
							postfixBuffer += s1.Pop();
							i--;
						}
					}else{
						if (ch == '+' || ch == '-'){
							postfixBuffer += s1.Pop();
							s1.Push(ch);
						}else{
                        	s1.Push(ch);
						}
					}
				}
			}else{
				postfixBuffer += ch;
			}
		}
		int len = s1.Count;

		//Creates a string with the postfix notation
		for (int j = 0; j < len; j++){
			postfixBuffer += s1.Pop();
		}
	}

	public static void CalcPostfix(ref string postfixBuffer){
		Console.WriteLine(postfixBuffer);
		
		
		Stack<Char> stack = new Stack<char>();

		for(int i=0; i<postfixBuffer.Length; i++){
			char current = postfixBuffer[i];
			Console.WriteLine(current);

			if(int.TryParse(current)){
				Console.WriteLine('t', null);
			}
		}
	}

//					 def evaluatePostfix(exprStr)
//							stack = Array.new
//
//							for i in 0...exprStr.split.length
//								current = exprStr.split[i]
//
//								if operand?(current)
//									stack.push(current)
//								end
//
//								if operator?(current)
//									y = stack.pop
//									x = stack.pop
//									o = current
//									results = applyOperator(x, y, o.to_s)
//									stack.push(results)
//								end
//							end
//
//							return stack.pop
//					  end
 
	public static void Main(string[] args){
		string infixBuffer = "";
		string postfixBuffer = "";
		double answer = 0;
 
		infixBuffer = args[0];
           
		InfixToPostfixConvert(ref infixBuffer, out postfixBuffer);
		CalcPostfix(ref postfixBuffer);

		Console.WriteLine("InFix:\t\t" + infixBuffer);
		Console.WriteLine("PostFix:\t" + postfixBuffer);
		Console.WriteLine("Answer:\t\t" + answer);
	}
}
