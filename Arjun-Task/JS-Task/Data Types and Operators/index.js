function practice() {
    console.log("===== JS Data Types =====");
    
    let name = "Alice";
    console.log("name:", name, "| type:", typeof name);

    let age = 25;
    console.log("age:", age, "| type:", typeof age);

    let isStudent = true;
    console.log("isStudent:", isStudent, "| type:", typeof isStudent);

    let emptyValue = null;
    console.log("emptyValue:", emptyValue, "| type:", typeof emptyValue);

    let unknownValue;
    console.log("unknownValue:", unknownValue, "| type:", typeof unknownValue);

    console.log("===== JS Arrays =====");

    let fruits = ["Apple", "Banana", "Cherry"];
    console.log("fruits array:", fruits, "| type:", typeof fruits);
    console.log("First fruit:", fruits[0]);

    console.log("===== JS Objects =====");

    let person = {
        firstName: "John",
        lastName: "Doe",
        age: 30,
        hobbies: ["reading", "traveling"]
    };
    console.log("person object:", person, "| type:", typeof person);
    console.log("Person's first name:", person.firstName);

    console.log("===== JS Operators =====");

    let x = 10;
    let y = 5;
    console.log("x:", x, "| y:", y);

    console.log("x + y =", x + y);
    console.log("x - y =", x - y);
    console.log("x * y =", x * y);
    console.log("x / y =", x / y);
    console.log("x % y =", x % y);

    console.log("x == y:", x == y);
    console.log("x != y:", x != y);
    console.log("x > y:", x > y);
    console.log("x <= y:", x <= y);

    let a = true;
    let b = false;
    console.log("a && b:", a && b);
    console.log("a || b:", a || b); 
    console.log("!a:", !a); 

    console.log("===== Combining Multiple Conditions =====");

    if (x > 5 && y < 10) {
        console.log("x is greater than 5 AND y is less than 10");
    }

    if (x === 10 || y === 10) {
        console.log("Either x or y equals 10");
    }

    if (!(x < 5)) {
        console.log("x is NOT less than 5");
    }

    console.log("===== Practice Complete =====");
}