#
# InfixPostfix class contains methods for infix to postfix conversion and
# postfix expression evaluation.
#
class InfixPostfix

  # converts the infix expression string to postfix expression and returns it
  def infixToPostfix(exprStr)
		postfix = Array.new
		stack = Array.new
		temp = Array.new
		index = 0

		for i in 0...exprStr.split.length
			input = exprStr.split[i]

			if operand?(input)
				postfix.push(input)
			end

			if isLeftParen?(input)
				stack.push(input)
			end

			if operator?(input)
				for j in 0...stack.length
					pop = stack.pop
					if stackPrecedence(pop) >= inputPrecedence(input)
						postfix.push(pop)
					else
						temp.push(pop)
					end
				end
				stack = temp
				stack.push(input)
			end

			if isRightParen?(input)
				pop = stack.pop
				while !isLeftParen?(pop)
					postfix.push(pop)
					pop = stack.pop
				end
			end
		end

		while stack.length != 0
			postfix.push(stack.pop)
		end

		return postfix.join(" ")
  end
  
  # evaluate the postfix string and returns the result
  def evaluatePostfix(exprStr)
		stack = Array.new

		for i in 0...exprStr.split.length
			current = exprStr.split[i]

			if operand?(current)
				stack.push(current)
			end

			if operator?(current)
				y = stack.pop
				x = stack.pop
				o = current
				results = applyOperator(x, y, o.to_s)
				stack.push(results)
			end
		end

		return stack.pop
  end
  
  private # subsequent methods are private methods
  
  # returns true if the input is an operator and false otherwise
  def operator?(str)
    if str == "+" || str == "-" || str == "*" || str == "/" || str == "%" || str == "^"
			return true
		end

		return false
  end
  
  # returns true if the input is an operand and false otherwise
  def operand?(str)
		true if Float(str) rescue false
  end
  
  # returns true if the input is a left parenthesis and false otherwise
  def isLeftParen?(str)
    if str == "("
			return true
		end

		return false
  end
  
  # returns true if the input is a right parenthesis and false otherwise
  def isRightParen?(str)
    if str == ")"
			return true
		end

		return false
  end
  
  # returns the stack precedence of the input operator
  def stackPrecedence(operator)
    if operator == "+" || operator == "-"
			return 1
		end

    if operator == "*" || operator == "/" || operator == "%"
			return 2
		end

    if operator == "^"
			return 3
		end

    if operator == "("
			return -1
		end

  end
  
  # returns the input precedence of the input operator
  def inputPrecedence(operator)
    if operator == "+" || operator == "-"
			return 1
		end

    if operator == "*" || operator == "/" || operator == "%"
			return 2
		end

    if operator == "^"
			return 4
		end

    if operator == "("
			return 5
		end

  end
  
  # applies the operators to num1 and num2 and returns the result
  def applyOperator(num1, num2, operator)

		if operator == "+"
			return num1.to_i + num2.to_i
		end

		if operator == "-"
			return num1.to_i - num2.to_i
		end

		if operator == "*"
			return num1.to_i * num2.to_i
		end

		if operator == "/"
			return num1.to_i / num2.to_i
		end

		if operator == "%"
			return num1.to_i % num2.to_i
		end

		if operator == "^"
			return num1.to_i ** num2.to_i
		end

  end
end

#
#  main driver for the program - similar to the main() function in Project 2
#
def main()
  puts "What is your equation?"
	equation = gets

  infix = InfixPostfix.new()

	if isPostfix?(equation)
		equation = infix.infixToPostfix(equation)
	end

	puts "\nPostfix"
	puts equation

	puts "\nAnswer"
	puts infix.evaluatePostfix(equation)
end

def isPostfix?(str)
	if str.split[1] == "+" || str.split[1] == "-" || str.split[1] == "*" || str.split[1] == "/" || str.split[1] == "%" || str.split[1] == "^" || str.split[0] == "("
		return true
	end
	return false
end

# invoke main function
main()

