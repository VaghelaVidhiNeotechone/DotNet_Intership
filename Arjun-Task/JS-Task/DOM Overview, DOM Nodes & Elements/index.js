function changeText() {
    let message = document.getElementById("message");
    message.textContent = "Text changed using getElementById!";
    message.style.color = "blue";
    console.log("changeText() → updated #message");
}

function highlightNote() {
    let note = document.querySelector(".note");
    note.style.backgroundColor = "yellow";
    note.style.fontWeight = "bold";
    console.log("highlightNote() → highlighted .note");
}

function showInputValue() {
    let input = document.querySelector("#nameInput");
    let value = input.value;

    if (value.trim() === "") {
        alert("Please enter your name!");
    } else {
        alert(`Hello, ${value}!`);
    }

    console.log("showInputValue() → Input value:", value);
}




function changeText() {
    let message = document.getElementById("message");
    message.textContent = "The text has been changed dynamically!";
    console.log("changeText() → Text updated");
}

function changeColor() {
    let message = document.querySelector("#message");
    let randomColor = getRandomColor();
    message.style.color = randomColor;
    message.style.backgroundColor = "lightyellow";
    console.log("changeColor() → Color changed to", randomColor);
}

function toggleStyle() {
    let message = document.getElementById("message");
    if (message.style.fontWeight === "bold") {
        message.style.fontWeight = "normal";
        message.style.fontStyle = "normal";
    } else {
        message.style.fontWeight = "bold";
        message.style.fontStyle = "italic";
    }
    console.log("toggleStyle() → Toggled text style");
}

function resetStyle() {
    let message = document.querySelector("#message");
    message.textContent = "This text will change!";
    message.style = "";
    console.log("resetStyle() → Reset to original");
}

function getRandomColor() {
    const letters = "0123456789ABCDEF";
    let color = "#";
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}