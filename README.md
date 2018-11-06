# Fibonacci Benchmark
Benchmark of recursive and iterative Fibonacci number generation

Fibonacci Sequence is defined as _A series of numbers in which each number ( Fibonacci number ) is the sum of the two preceding numbers. The simplest is the series 1, 1, 2, 3, 5, 8, etc._

Source code of recursive, iterative and tail recursive Fibonacci methods are listed below. They are the same for both C++ and C#. Tail recursive version is contributed by Peter Becker.

```Cpp
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

int iterative_fib(int n)
{
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
```

### C++ Benchmark result for finding fibonacci of 42

```
recursive_fib timing: 1051ms
iterative_fib timing:    0ms
tail_recursion_fib timing:    0ms
```

### C# Benchmark result for finding fibonacci of 42

```
recursive_fib timing:01.179
iterative_fib timing:00.000
tail_recursion_fib timing:00.000
```

C# timing is just slightly behind C++. We will add a global variable named count to keep track of how many times the recursive method is called for fibonacci of 8.

```Cpp
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
```

Output is as below

```
recursive_fib(8) total number of recursive calls:67
```

We can see recursive_fib is a very inefficient way of generating Fibonacci. During interview, remember never to give recursive_fib as an answer because this is not what interviewers are looking out for!