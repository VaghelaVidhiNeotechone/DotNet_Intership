function practiceObjects() {
    console.log("===== CREATING OBJECTS WITH METHODS =====");

    let person = {
        firstName: "Alice",
        lastName: "Smith",
        age: 28,
        city: "New York",

        getFullName: function() {
            return this.firstName + " " + this.lastName;
        },

        greet: () => "Hello from arrow function!"
    };

    console.log("First Name:", person.firstName);
    console.log("Last Name:", person.lastName);
    console.log("Age:", person.age);
    console.log("City:", person.city);

    console.log("Full Name:", person.getFullName());
    console.log("Greeting:", person.greet());

    console.log("===== ANOTHER OBJECT EXAMPLE =====");

    const calculator = {
        add: function(a, b) {
            return a + b;
        },
        subtract: function(a, b) {
            return a - b;
        },
        multiply: (a, b) => a * b,
        divide: (a, b) => (b !== 0 ? a / b : "Cannot divide by zero")
    };

    console.log("5 + 3 =", calculator.add(5, 3));
    console.log("10 - 4 =", calculator.subtract(10, 4));
    console.log("6 * 7 =", calculator.multiply(6, 7));
    console.log("20 / 4 =", calculator.divide(20, 4));
    console.log("20 / 0 =", calculator.divide(20, 0));
}



function practiceArrays() {
    console.log("===== CREATING AN ARRAY =====");

    let fruits = ["Apple", "Banana", "Cherry"];
    console.log("Initial array:", fruits);

    console.log("===== ADDING ELEMENTS =====");

    fruits.push("Mango");
    console.log("After push:", fruits);

    fruits.unshift("Strawberry");
    console.log("After unshift:", fruits);

    console.log("===== REMOVING ELEMENTS =====");

    let removedEnd = fruits.pop();
    console.log("Removed from end:", removedEnd);
    console.log("Array now:", fruits);

    let removedStart = fruits.shift();
    console.log("Removed from start:", removedStart);
    console.log("Array now:", fruits);

    console.log("===== ITERATING THROUGH ARRAY =====");

    for (let i = 0; i < fruits.length; i++) {
        console.log(`Fruit ${i}:`, fruits[i]);
    }

    for (let fruit of fruits) {
        console.log("For-of loop:", fruit);
    }

    fruits.forEach((fruit, index) => {
        console.log(`forEach - index ${index}: ${fruit}`);
    });

    console.log("===== SEARCHING IN ARRAY =====");

    console.log("Index of 'Banana':", fruits.indexOf("Banana"));
    console.log("Includes 'Cherry'?", fruits.includes("Cherry"));

    console.log("===== OTHER ARRAY OPERATIONS =====");

    let moreFruits = ["Pineapple", "Grapes"];
    let allFruits = fruits.concat(moreFruits);
    console.log("Concatenated array:", allFruits);

    let someFruits = allFruits.slice(1, 4); 
    console.log("Sliced array (1-3):", someFruits);

    let fruitsString = allFruits.join(", ");
    console.log("Joined string:", fruitsString);

    let sortedFruits = allFruits.slice().sort();
    console.log("Sorted array:", sortedFruits);
    console.log("Reversed array:", sortedFruits.reverse());

    console.log("===== ARRAY PRACTICE COMPLETE =====");
}