#!/usr/bin/env ruby

class Hello

	def printhello(name)
		puts "Hello #{name}!"
	end
end

test = Hello.new()
test.printhello("test")
