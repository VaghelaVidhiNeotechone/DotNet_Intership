
    //  Single-line comment: Declare a variable using var , let , const
    var studentName = "Arya";
    document.getElementById("nameOutput").innerHTML = "Student Name (var): " + studentName;

    let studentAge = 14;
    document.getElementById("ageOutput").innerHTML = "Student Age (let): " + studentAge;

    const schoolName = "B.A.P.S. Gurkul";
    document.getElementById("schoolOutput").innerHTML = "School Name (const): " + schoolName;

    /*
     Multi-line comment:
     Update output using getElementById again
    */

    studentName = "yashvi";
    studentAge = 21;

    document.getElementById("updateOutput").innerHTML = "Updated Name: " + studentName + "<br>" + "Updated Age: " + studentAge;


    let carName="bmw",person="yashvi",price=200000;
    document.getElementById('var').innerHTML=person;

    document.getElementById('demo2').innerHTML=10.20;
 
    let x,y,z;
    x=3;
    y=3;
    z=x+y;
    document.getElementById("sum").innerHTML="The value of z is "+z+".";
    document.getElementById("multiplication").innerHTML=5*10;
 
  let name = "Yashvi";
console.log(name);
