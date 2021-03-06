#include <iostream>
#include <iomanip>
#include <chrono>
#include <string>

class timer
{
public:
	timer() = default;
	void start(const std::string& text_)
	{
		text = text_;
		begin = std::chrono::high_resolution_clock::now();
	}
	void stop()
	{
		auto end = std::chrono::high_resolution_clock::now();
		auto dur = end - begin;
		auto ms = std::chrono::duration_cast<std::chrono::milliseconds>(dur).count();
		std::cout << std::setw(20) << text << " timing:" << std::setw(5) << ms << "ms" << std::endl;
	}

private:
	std::string text;
	std::chrono::high_resolution_clock::time_point begin;
};

int recursive_fib(int n)
{
	if (n < 2)
	{
		return n;
	}
	else
	{
		return recursive_fib(n - 2) + recursive_fib(n - 1);
	}
}

int count = 0;
int recursive_fib_with_count(int n)
{
	++count;
	if (n < 2)
	{
		return n;
	}
	else
	{
		return recursive_fib_with_count(n - 2) + recursive_fib_with_count(n - 1);
	}
}

int iterative_fib(int n)
{
	if (n < 2)
		return n;

	int second_fib = 0, first_fib = 1, current_fib = 0;
	for(int i=2; i<=n; i++)
	{    
		current_fib = second_fib+first_fib;    
		second_fib = first_fib;    
		first_fib = current_fib;  
	}  
	return current_fib; 
}

int tail_recursion_fib(int n, int a = 0, int b = 1)
{
	if (n == 0)
		return a;
	if (n == 1)
		return b;
	return tail_recursion_fib(n - 1, b, a + b);
}

int main()
{
	timer stopwatch;
	std::int64_t n = 0;

	stopwatch.start("recursive_fib");
	std::cout << "recursive_fib(42) result:" << recursive_fib(42) << std::endl;
	stopwatch.stop();

	stopwatch.start("iterative_fib");
	std::cout << "iterative_fib(42) result:" << iterative_fib(42) << std::endl;
	stopwatch.stop();

	stopwatch.start("tail_recursion_fib");
	std::cout << "tail_recursion_fib(42) result:" << tail_recursion_fib(42) << std::endl;
	stopwatch.stop();

	recursive_fib_with_count(8);
	std::cout << "recursive_fib(8) total number of recursive calls:" << count << std::endl;

}

