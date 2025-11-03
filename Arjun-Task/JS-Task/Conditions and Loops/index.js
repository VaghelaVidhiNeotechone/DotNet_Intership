function practiceConditionalsAndLoops() {
    console.log("===== IF-ELSE and ELSE-IF =====");
    
    let score = 85;

    if (score >= 90) {
        console.log("Grade: A");
    } else if (score >= 75) {
        console.log("Grade: B");
    } else if (score >= 60) {
        console.log("Grade: C");
    } else {
        console.log("Grade: F");
    }

    console.log("===== SWITCH STATEMENT =====");

    let day = 3;

    switch(day) {
        case 1:
            console.log("Monday");
            break;
        case 2:
            console.log("Tuesday");
            break;
        case 3:
            console.log("Wednesday");
            break;
        case 4:
            console.log("Thursday");
            break;
        case 5:
            console.log("Friday");
            break;
        default:
            console.log("Weekend");
    }

    console.log("===== TRUTHY and FALSY VALUES =====");

    let values = [0, 1, "", "Hello", null, undefined, [], {}, false, true];

    values.forEach((val, index) => {
        if (val) { 
            console.log(`values[${index}] (${val}) is truthy`);
        } else { 
            console.log(`values[${index}] (${val}) is falsy`);
        }
    });

    console.log("===== LOOPS: ARRAYS =====");

    let fruits = ["Apple", "Banana", "Cherry"];
    
    for (let i = 0; i < fruits.length; i++) {
        console.log(`Fruit ${i}: ${fruits[i]}`);
    }

    for (let fruit of fruits) {
        console.log("For-of loop:", fruit);
    }

    console.log("===== LOOPS: OBJECTS =====");

    let person = {
        firstName: "Alice",
        lastName: "Smith",
        age: 28,
        city: "New York"
    };

    for (let key in person) {
        console.log(`${key}: ${person[key]}`);
    }

    console.log("===== Practice Complete =====");
}