function practiceFunctions() {
    console.log("===== REUSABLE FUNCTIONS =====");

    function addNumbers(a, b) {
        return a + b;
    }

    function multiplyNumbers(a, b) {
        return a * b;
    }

    function greet() {
        return "Hello, welcome!";
    }

    let sum = addNumbers(10, 5);
    console.log("Sum of 10 + 5 =", sum);

    let product = multiplyNumbers(4, 6);
    console.log("Product of 4 * 6 =", product);

    let message = greet();
    console.log(message);

    function sayHello(name = "Guest") {
        return `Hello, ${name}!`;
    }

    console.log(sayHello("Alice"));
    console.log(sayHello());

    function calculateArea(length, width) {
        return multiplyNumbers(length, width);
    }

    let area = calculateArea(5, 10);
    console.log("Area of rectangle 5x10 =", area);

    console.log("===== Practice Complete =====");
}

function practiceArrowAndScope() {
    console.log("===== REGULAR FUNCTIONS VS ARROW FUNCTIONS =====");

    function greetRegular(name) {
        return "Hello, " + name + "!";
    }

    console.log(greetRegular("Alice"));

    const greetArrow = (name) => "Hello, " + name + "!";
    console.log(greetArrow("Bob"));

    const addNumbers = (a, b) => a + b;
    console.log("5 + 7 =", addNumbers(5, 7));

    const sayHi = () => "Hi there!";
    console.log(sayHi());

    console.log("===== VAR, LET, CONST SCOPE =====");

    if (true) {
        var varVariable = "I am var";
        let letVariable = "I am let";
        const constVariable = "I am const";

        console.log("Inside block - var:", varVariable);
        console.log("Inside block - let:", letVariable);
        console.log("Inside block - const:", constVariable);
    }

    console.log("Outside block - var:", varVariable);
    // console.log("Outside block - let:", letVariable);
    // console.log("Outside block - const:", constVariable);

    function testVarScope() {
        var insideVar = "Inside function var";
        let insideLet = "Inside function let";
        const insideConst = "Inside function const";
        console.log("Inside function - var:", insideVar);
        console.log("Inside function - let:", insideLet);
        console.log("Inside function - const:", insideConst);
    }

    testVarScope();
    // console.log(insideVar);
}