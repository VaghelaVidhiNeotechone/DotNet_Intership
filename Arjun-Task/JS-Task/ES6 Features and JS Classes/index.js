function runExample() {
    console.log("===== ES5 vs ES6 Comparison =====");

    function addNumbers(a, b) {
        return a + b;
    }
    console.log("ES5 addNumbers(2, 3):", addNumbers(2, 3));

    var personOld = {
        firstName: "Alice",
        lastName: "Smith",
        getFullName: function() {
            return this.firstName + " " + this.lastName;
        }
    };
    console.log("ES5 getFullName():", personOld.getFullName());


    const add = (a, b) => a + b;
    console.log("ES6 add(2, 3):", add(2, 3));

    const greet = (name) => `Hello, ${name}!`;
    console.log(greet("Bob"));

    const firstName = "John";
    const lastName = "Doe";

    const personNew = {
        firstName,
        lastName,
        getFullName() {
            return `${this.firstName} ${this.lastName}`;
        },
        greet: () => "Hi there!"
    };

    console.log("ES6 getFullName():", personNew.getFullName());
    console.log("ES6 greet():", personNew.greet());

    const { firstName: fName, lastName: lName } = personNew;
    console.log(`Destructured Name: ${fName} ${lName}`);

    const multiply = (a, b = 2) => a * b;
    console.log("multiply(5):", multiply(5));
    console.log("multiply(5, 3):", multiply(5, 3));

    const nums = [1, 2, 3];
    const moreNums = [...nums, 4, 5];
    console.log("Spread Operator Result:", moreNums);

    const propName = "favoriteColor";
    const profile = {
        name: "Ella",
        age: 25,
        [propName]: "Blue" 
    };
    console.log("Enhanced Object Literal:", profile);
}



function run() {
    console.log("===== CLASS HIERARCHY: Person → Student =====");

    class Person {
        constructor(firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        getFullName() {
            return `${this.firstName} ${this.lastName}`;
        }

        describe() {
            return `${this.getFullName()} is ${this.age} years old.`;
        }
    }

    class Student extends Person {
        constructor(firstName, lastName, age, studentId, major) {
            super(firstName, lastName, age);
            this.studentId = studentId;
            this.major = major;
        }

        study() {
            return `${this.getFullName()} is studying ${this.major}.`;
        }

        describe() {
            return `${this.getFullName()} (ID: ${this.studentId}) is ${this.age} years old and majors in ${this.major}.`;
        }
    }

    const person1 = new Person("Alice", "Smith", 30);
    const student1 = new Student("Bob", "Johnson", 20, "S12345", "Computer Science");

    console.log(person1.describe());
    console.log(student1.describe());
    console.log(student1.study());

    console.log("Is student1 a Person?", student1 instanceof Person);
    console.log("Is person1 a Student?", person1 instanceof Student);
}