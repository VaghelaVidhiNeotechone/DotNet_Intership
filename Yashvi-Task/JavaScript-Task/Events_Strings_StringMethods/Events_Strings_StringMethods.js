  function showMessage() {
    document.getElementById("output").innerHTML = "Button was clicked!";
  }

  
  function changeColor() {
    document.getElementById("hoverBox").style.backgroundColor = "orange";
    document.getElementById("hoverBox").innerHTML = "Mouse Over!";
  }

  function resetColor() {
    document.getElementById("hoverBox").style.backgroundColor = "lightblue";
    document.getElementById("hoverBox").innerHTML = "Hover Me";
  }