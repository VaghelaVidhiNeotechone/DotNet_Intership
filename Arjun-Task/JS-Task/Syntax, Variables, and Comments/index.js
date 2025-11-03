function demoVariables() {
    console.log("Starting variable demo...");

    /* 
       This is a multi-line comment.
       We will declare variables using let, const, and var
    */

    let name = "Alice";
    const birthYear = 1990;
    var city = "New York";

    console.log("Name:", name);
    console.log("Birth Year:", birthYear);
    console.log("City:", city);

    name = "Bob";
    console.log("Updated Name:", name);

    // birthYear = 2000;

    // Changing the 'var' variable
    city = "Los Angeles";
    console.log("Updated City:", city);
}