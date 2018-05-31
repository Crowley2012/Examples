#include <stdio.h>

void add(int *a);
void add2(int a);
void printMem(int *a);

int main(){
    const char * s1 = "zero";

	printf("s1: %s\n", s1);
	printf("s1: %c\n", *s1);
	printf("s1*: %p\n", &s1);
	printf("---------------------\n");

	int var1 = 1;
	int *var2 = &var1;

	printf("Var1: %d\n", var1);
	printf("Var2: %p\n", var2);
	printf("Var2*: %d\n", *var2);
	printf("---------------------\n");

	*var2 = *var2 + 2;

	printf("Var1: %d\n", var1);
	printf("Var2: %p\n", var2);
	printf("Var2*: %d\n", *var2);
	printf("---------------------\n");

	add(var2);

	printf("Var1: %d\n", var1);
	printf("Var2: %p\n", var2);
	printf("Var2*: %d\n", *var2);
	printf("---------------------\n");

	add2(var1);

	printf("Var1: %d\n", var1);
	printf("Var2: %p\n", var2);
	printf("Var2*: %d\n", *var2);
	printf("---------------------\n");

	printMem(var2);

	return 0;
}

void add(int *a){
	*a = *a + 2;
	printf("A: %p\n", a);
}

void add2(int a){
	a = a + 2;
	printf("A: %d\n", a);
}

void printMem(int *a){
	while(1){
		printf("%c\n", *a);
		a = a + 1;
	}
}



