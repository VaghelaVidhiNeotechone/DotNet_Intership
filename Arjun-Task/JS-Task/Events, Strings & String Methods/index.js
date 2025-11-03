function practiceStrings() {
    console.log("===== CREATING STRINGS =====");

    let firstName = " Alice ";
    let lastName = "Smith";
    let greeting = "hello world!";

    console.log("Original firstName:", `"${firstName}"`);
    console.log("Original lastName:", lastName);
    console.log("Original greeting:", greeting);

    console.log("===== TRIMMING AND LENGTH =====");
    console.log("Trimmed firstName:", `"${firstName.trim()}"`);
    console.log("Length of trimmed firstName:", firstName.trim().length);

    console.log("===== CHANGING CASE =====");
    console.log("Uppercase:", greeting.toUpperCase());
    console.log("Lowercase:", greeting.toLowerCase());

    console.log("===== CONCATENATION =====");
    let fullName = firstName.trim() + " " + lastName;
    console.log("Full Name:", fullName);

    let message = `Hello, ${firstName.trim()} ${lastName}! Welcome.`;
    console.log("Template literal message:", message);

    console.log("===== SEARCHING AND REPLACING =====");
    console.log("Index of 'world' in greeting:", greeting.indexOf("world"));
    console.log("Includes 'Hello'? ", greeting.includes("Hello"));
    console.log("Replace 'world' with 'Alice':", greeting.replace("world", "Alice"));

    console.log("===== SLICING AND SUBSTRING =====");
    console.log("Slice (0,5):", greeting.slice(0,5));
    console.log("Substring (6,11):", greeting.substring(6,11));

    console.log("===== SPLIT AND JOIN =====");
    let words = greeting.split(" ");
    console.log("Split words:", words);
    let joined = words.join("-");
    console.log("Joined with dash:", joined);

    console.log("===== STRING PRACTICE COMPLETE =====");
}



console.log("===== JS Button Events Practice =====");

function sayHello() {
    alert("Hello! You clicked the button.");
    console.log("sayHello function triggered");
}

function changeColor(button) {
    button.style.backgroundColor = "lightgreen";
    console.log("Mouse over button - color changed");
}

function resetColor(button) {
    button.style.backgroundColor = "";
    console.log("Mouse left button - color reset");
}

function greetPerson(name) {
    alert(`Hello, ${name}!`);
    console.log(`greetPerson triggered with name: ${name}`);
}