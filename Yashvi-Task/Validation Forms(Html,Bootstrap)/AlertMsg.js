 //variable
  const loginForm = document.getElementById("loginForm");
  const luser = document.getElementById("loginUsername");
  const lpass = document.getElementById("loginPassword");

  loginForm.addEventListener("submit", function (e) {
    e.preventDefault(); //event listener
    let valid = true;

    const nameRegex = /^[A-Za-z]+(?:\s[A-Za-z]+)*$/; //reguler listener
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    // Username or Email 
    if (luser.value.trim() === "") {
    valid = false;
    alert("Please Enter User Name");
    luser.focus();
    return;
  }
    else if (!(nameRegex.test(luser.value.trim()) || emailRegex.test(luser.value.trim()))) {
      valid =false;
      alert("Please enter a valid username (letters only) or a valid email.");
      luser.focus();
      return;
    } 

    // Password 
     let passPattern =/^(?=.*[A-Za-z])(?=.*[@#$%])[A-Za-z0-9@#$%]{6,20}$/;
      
    if (lpass.value.trim() === "") {
      valid = false;
      alert("Please enter password");
      lpass.focus();
      return;
    } 
    else if (lpass.value.trim().length < 6 || lpass.value.trim().length > 8) {
      valid = false;
      alert("Password must be 6 to 8 characters long.");
      lpass.focus();
      return;
    } 
    
    else if (!passPattern.test(lpass.value)) {
      valid = false;
      alert("Password must include at least one special character.");
      lpass.focus();
      return;
    }

    if (valid) {
      loginForm.submit();
    }
  });

//object
const locationData = {
  india: { gujarat: ["Ahmedabad", "Rajkot"], kerala: ["Kochi", "Trivandrum"] },
  brazil: { acre: ["Rio Branco"], amazonas: ["Manaus"] },
  us: { victoria: ["Melbourne", "Ballarat"], tasmania: ["Hobart", "Burnie"] }
};

//variable
const country = document.getElementById("country");
const state = document.getElementById("state");
const city = document.getElementById("city");
const phone = document.getElementById("phone");
const cphone=document.getElementById("phoneCode");

country.addEventListener("change", () => {
  state.innerHTML = '<option selected disabled>Select State</option>';
  city.innerHTML = '<option selected disabled>Select City</option>';
  const states = Object.keys(locationData[country.value]);
  states.forEach(s => state.innerHTML += `<option value="${s}">${s}</option>`);//state select

  if (country.value === "india")
    cphone.value = "+91 ";
  else if (country.value === "brazil")
    cphone.value = "+55 ";
  else if (country.value === "us")
    cphone.value = "+61 ";
  else
    cphone.value = "";
});

state.addEventListener("change", () => {
  city.innerHTML = '<option selected disabled>Select City</option>';
  const cities = locationData[country.value][state.value];
  cities.forEach(c => city.innerHTML += `<option value="${c}">${c}</option>`);//city select
});


const photoInput = document.getElementById("photo");
const preview = document.getElementById("preview");

photoInput.addEventListener("change", () => {
  if (photoInput.files.length > 0) {
    const file = photoInput.files[0];

    const allowedTypes = ["image/jpeg", "image/jpg", "image/png"];
    if (!allowedTypes.includes(file.type)) {
      alert("Only PNG, JPG, or JPEG files are allowed.");
      preview.classList.add("d-none");
      photoInput.value = ""; // reset
      return;
    }
    if (file.size > 104857600) {
      alert("File size must be under 100KB.");
      preview.classList.add("d-none");
      photoInput.value = ""; // reset
      return;
    }
    preview.src = URL.createObjectURL(file);
    preview.classList.remove("d-none");

  } else {
    alert("Please upload a photo (PNG, JPG, JPEG, max 100KB).");
    preview.classList.add("d-none");
  }
});

document.getElementById("regForm").addEventListener("submit", function (e){
  e.preventDefault();//event listener

  //variable
  const fname = document.getElementById("firstName");
  const lname = document.getElementById("lastName");
  const email = document.getElementById("email");
  const pass = document.getElementById("password");
  const cpass = document.getElementById("confirmPassword");
  const address = document.getElementById("address");
  const search=document.getElementById("searches");
  const website = document.getElementById("website");
  const ctime = document.getElementById("contacttime");
  const bmonth = document.getElementById("birthmonth");
  const photo = document.getElementById("photo");
  const hobbies = document.querySelectorAll(".hobby:checked");
  const genders = document.querySelectorAll(".gender:checked");
  const dob = document.getElementById("dob");


  // First Name
  const nameRegex = /^[A-Za-z]{2,}$/;
  if (fname.value.trim() === "") {
    valid = false;
    alert("Please Enter First Name");
    fname.focus();
    return;
  } else if (!nameRegex.test(fname.value.trim())) {
    alert("First name must contain only letters.");
    valid = false;
    fname.focus();
    return;
  }

  // Last Name
  if (lname.value.trim() === "") {
    alert("Please Enter Last Name");
    valid = false
    lname.focus();
    return;
  } else if (!nameRegex.test(lname.value.trim())) {
    alert("Last Name must contain only letters.");
    valid = false;
    lname.focus();
    return;
  }
  
  // Email Validation
  
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/;
  
  if (email.value.trim() === "") {
    alert("Enter Email ID");
    valid = false;
    email.focus();
    return;
  } else if (!emailRegex.test(email.value) || !email.value.includes(".com")) {
    alert("Enter a valid email (must include @ & .com).");
    valid = false;
    email.focus();
    return;
  } 
  
    // Password
     let passPattern =/^(?=.*[A-Za-z])(?=.*[@#$%])[A-Za-z0-9@#$%]{6,20}$/;
      
         
  if (pass.value.trim() === "") {
    alert("Please enter password");
    valid = false;
    pass.focus();
    return;
   
  } else if (!passPattern.test(pass.value)) {
    alert("Password must include at least one special character.");
    valid = false;
    pass.focus();
    return;
  }
  
  //confirmPassword
  if (pass.value !== cpass.value) {
    alert("Passwords do not match.");
    cpass.focus();
    return;
  }
  

  // Gender
  if (genders.length === 0) {
    alert("Please select gender.");
    return;
  }

  // Address
  if (!address.value.trim()) {
    alert("Please enter your address.");
    address.focus();
    return;
  }

  // Country
  if (country.value === "Select Country") {
    alert("Please select a country.");
    country.focus();
    return;
  }

  // State
  if (state.value === "Select State") {
    alert("Please select a state.");
    state.focus();
    return;
  }

  // City
  if (city.value === "Select City") {
    alert("Please select a city.");
    city.focus();
    return;
  }



    const phoneRegex = /^[0-9]{10}$/;
    const codeRegex = /^\+(91|55|61)$/; // example: +91, +55, +61

    if(phone.value.trim()===""){
    alert("Please Enter Phone Number");
    phone.focus();
    return;

    }
    else if (!phoneRegex.test(phone.value.trim())) {
     alert("Enter a valid 10-digit phone number.");
    phone.focus();
    return;
    } 
    else if (!codeRegex.test(phoneCode.value.trim())) {
          alert("Please display country code ");
      cphone.focus();
      return;
    }



  

  //DOB
   const today = new Date().toISOString().split("T")[0];
  dob.max = today;
  
  if (!dob.value) {
    alert("Please enter your date of birth.");
    dob.focus();
    return
  } else if (dob.value > today) {
    alert("Date of birth cannot be in the future.");
    dob.focus();
    return;
  }

  // Website
  if (!website.value.startsWith("http")) {
    alert("Enter a valid website URL (must start with http).");
    website.focus();
    return;
  }

  // Contact Time
  if (!ctime.value) {
    alert("Enter a valid contact time.");
    ctime.focus();
    return;
  }

  // Birth Month
  if (!bmonth.value) {
    alert("Enter a valid birth month.");
    bmonth.focus();
    return;
  }

  // Hobbies
  if (hobbies.length === 0) {
    alert("Select at least one hobby.");
    hobbies.focus();
    return;
  }

  // Photo
  if (!photo.value) {
    alert("Please upload a File");
    photo.focus();
    return;
  }

  if(!search.value){
    alert("Plase Search something...");
    search.focus();
    return;
  }
  // Success
  alert("Registration Successful!");
  window.location.href = "AlertMsg.html";
});



// reset form
document.getElementById("clearReg").addEventListener("click", () => {
  const form = document.getElementById("regForm");
  form.reset();

  state.innerHTML = '<option selected disabled>Select State</option>';
  city.innerHTML = '<option selected disabled>Select City</option>';
  cphone.value = "";

  preview.classList.add("d-none");
  preview.src = "";

  document.querySelectorAll(".gender, .hobby").forEach(el => (el.checked = false));

  alert("Form has been reset!");
});