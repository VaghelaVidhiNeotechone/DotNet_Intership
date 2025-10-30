
// ------------------- 1. IF-ELSE & ELSE-IF -------------------
let score = 75;
let message = "";

if (score > 90) {
    message = "Grade: A";
} else if (score > 75) {
    message = "Grade: B";
} else if (score > 50) {
    message = "Grade: C";
} else {
    message = "Grade: F";
}

console.log("If-Else Result:", message);

// ------------------- 2. SWITCH -------------------
let day1 = 3;
let dayName = "";

switch(day) {
    case 1: dayName = "Monday"; break;
    case 2: dayName = "Tuesday"; break;
    case 3: dayName = "Wednesday"; break;
    case 4: dayName = "Thursday"; break;
    case 5: dayName = "Friday"; break;
    case 6: dayName = "Saturday"; break;
    case 7: dayName = "Sunday"; break;
    default: dayName = "Invalid day";
}

console.log("Switch Result:", dayName);

// ------------------- 3. TRUTHY & FALSY VALUES -------------------
let testValue = ""; // Empty string is Falsy

if (testValue) {
    console.log("Truthy value detected!");
} else {
    console.log("Falsy value detected!"); // This will run
}

// Examples: Falsy values in JS: false, 0, "", null, undefined, NaN
// Everything else is truthy

// ------------------- 4. LOOPS -------------------
// ARRAY LOOP
let fruits = ["Apple", "Banana", "Cherry"];
console.log("Array items:");
for (let i = 0; i < fruits.length; i++) {
    console.log(fruits[i]);
}

// OBJECT LOOP
let person1 = { name: "Alice", age: 25, city: "London" };
console.log("Object properties:");
for (let key in person1) {
    console.log(key + ": " + person1[key]);
}

// ------------------- 5. Display in HTML -------------------
document.getElementById("output").innerHTML = `
    <strong>If-Else:</strong> ${message} <br>
    <strong>Switch:</strong> ${dayName} <br>
    <strong>Falsy Check:</strong> ${testValue ? "Truthy" : "Falsy"} <br>
    <strong>Array:</strong> ${fruits.join(", ")} <br>
    <strong>Object:</strong> Name=${person.name}, Age=${person.age}, City=${person.city}
`;