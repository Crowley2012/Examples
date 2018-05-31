#include <stdio.h>
#include <string.h>

struct Hello{
	char a[30];
	int b;
};

void modStruct(struct Hello *a);
void modArray(int *x);

int main(int argc, char *argv[]){

	//Print
	printf("Hello World\n\n");

	//Print number of args
	printf("Number of args: %i\n", argc-1);

	//Print args
	for(int i=1; i<argc; i++){
		printf("args[%i] = %s\n", i, argv[i]);
	}

	//Create int array
	int nums[3] = {1, 2, 3};

	//Array size
	printf("\nArray size : %i\n", (sizeof(nums)/sizeof(nums[0])));

	//Print array
	for(int i=0; i<(sizeof(nums)/sizeof(nums[0])); i++){
		printf("nums[%i] = %i\n", i, nums[i]);
	}

	//String variable
	char str[] = "String Variable!";
	printf("\nString length : %i\n", sizeof(str)/sizeof(str[0]));
	printf("%s\n", str);
	printf("Last char : %c\n\n", str[(sizeof(str)/sizeof(str[0]))-2]);

	//Pointers
	int a = 5;
	int *a_ptr = &a;

	printf("Var a : %i\n", a);
	printf("Var a_ptr : %p\n", a_ptr);
	printf("Var *a_ptr : %i\n", *a_ptr);

	//Structs
	struct Hello test;
	strcpy(test.a, "This is a struct");
	test.b = 100;

	printf("\n%s\n", test.a);
	printf("%i\n", test.b);

	//Struct pointer
	struct Hello *test_ptr = &test;

	printf("\ntest_ptr : %p\n", test_ptr);
	printf("(*test_ptr).a : %s\n", (*test_ptr).a);
	printf("test_ptr -> b : %i\n", test_ptr -> b);

	//Modify struct
	modStruct(test_ptr);
	printf("\n%s\n", (*test_ptr).a);
	printf("%i\n\n", (*test_ptr).b);

	//Modify array
	modArray(nums);
	for(int i=0; i<(sizeof(nums)/sizeof(nums[0])); i++){
		printf("nums[%i] = %i\n", i, nums[i]);
	}

	return 0;
}

//Method accepting pointer struct
void modStruct(struct Hello *a){
	strcpy((*a).a, "This is a modified struct");
	a -> b = 150;
}

//Method to modify array
void modArray(int *x){
	x[0] = 8;
	x[1]++;
	x[2] += 7;
}
