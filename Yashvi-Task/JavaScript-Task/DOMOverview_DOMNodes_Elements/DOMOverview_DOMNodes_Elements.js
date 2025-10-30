     // Using getElementById
    let heading = document.getElementById("title");
    heading.style.color = "red";

    // Using querySelector
    let firstParagraph = document.querySelector(".text");
    firstParagraph.style.fontWeight = "bold";

    function changeContent() {
      // Change HTML text
      document.getElementById("heading").innerHTML = "Hello JavaScript DOM!";

      // Change CSS styles
      let desc = document.getElementById("description");
      desc.style.color = "white";
      desc.style.backgroundColor = "green";
      desc.style.padding = "10px";
      desc.style.borderRadius="18px";
    }