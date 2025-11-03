function calculateSquare() {
    let input = document.getElementById("numInput").value;
    let resultElement = document.getElementById("result");

    try {
        let num = parseFloat(input);

        if (isNaN(num)) {
            throw "Input is not a number!";
        }

        if (num < 0) {
            throw "Number must be positive!";
        }

        let square = num * num;
        resultElement.textContent = `The square of ${num} is ${square}.`;
        resultElement.style.color = "green";
        console.log("Square calculated successfully");

    } catch (error) {
        console.error("Error caught:", error);
        resultElement.textContent = `Error: ${error}`;
        resultElement.style.color = "red";

    } finally {
        console.log("calculateSquare() → finished execution");
    }
}

function riskyOperation() {
    try {
        let result = undefinedVariable + 10;
        console.log(result);
    } catch (err) {
        console.error("Runtime error handled:", err.message);
    } finally {
        console.log("riskyOperation() → cleanup complete");
    }
}

riskyOperation();