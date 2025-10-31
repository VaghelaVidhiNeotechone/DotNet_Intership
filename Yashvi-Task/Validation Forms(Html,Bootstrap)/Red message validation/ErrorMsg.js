const loginForm = document.getElementById("loginForm");//variable
  const luser = document.getElementById("loginUsername");
  const lpass = document.getElementById("loginPassword");
  const euser=document.getElementById("Emptyuser")
  const euserpass=document.getElementById("Emptypassword")
  let ipass = document.getElementById("Invalidpassword");

  loginForm.addEventListener("submit", function (e) {
    e.preventDefault(); //event listener
    let valid = true;

    const nameRegex = /^[A-Za-z]+(?:\s[A-Za-z]+)*$/; //reguler Expression
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    // Username or Email 
    if(luser.value.trim()===""){
       luser.classList.add("is-invalid");
  euser.style.display = "block"; 
  luser.nextElementSibling.style.display = "none";//read only
  valid = false;
    }
    else if (!(nameRegex.test(luser.value.trim()) || emailRegex.test(luser.value.trim()))) {
      luser.classList.add("is-invalid");
  euser.style.display = "none";
  luser.nextElementSibling.style.display = "block"; 
  valid = false;
    } else {
      luser.classList.remove("is-invalid");
  euser.style.display = "none";
  luser.nextElementSibling.style.display = "none";
    }

    // Password 
if (lpass.value.trim() === "") {
  lpass.classList.add("is-invalid");
  euserpass.style.display = "block";
  ipass.style.display = "none";
  valid = false;
} else {
  let passPattern = /^(?=.*[A-Za-z])(?=.*[@#$%])[A-Za-z0-9@#$%]{6,20}$/;

  if (!passPattern.test(lpass.value)) {
    lpass.classList.add("is-invalid");
    euserpass.style.display = "none";
    ipass.style.display = "block";
    valid = false;
  } else {
    lpass.classList.remove("is-invalid");
    euserpass.style.display = "none";
    ipass.style.display = "none";
  }
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
const cphone =document.getElementById("phoneCode");

// Country -> State -> City -> Phone Code
//when user can select state use this fuction
country.addEventListener("change", () => {
  state.innerHTML = '<option selected disabled>Select State</option>';
  city.innerHTML = '<option selected disabled>Select City</option>';
  const states = Object.keys(locationData[country.value] || {});
  states.forEach(s => state.innerHTML += `<option value="${s}">${s}</option>`);//state select and loop runing
  
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
  const cities = (locationData[country.value] || {})[state.value] || [];
  cities.forEach(c => city.innerHTML += `<option value="${c}">${c}</option>`);//city select
});


//Photo Preview
const photoInput = document.getElementById("photo");
const preview = document.getElementById("preview");

photoInput.addEventListener("change", () => {
  if (photoInput.files.length > 0) {
    const file = photoInput.files[0];

    const allowedTypes = ["image/jpeg", "image/jpg", "image/png"];
    if (!allowedTypes.includes(file.type)) {
      preview.classList.add("d-none");
      photoInput.value = ""; // reset
      photoInput.classList.add("is-invalid");
      valid=false;
    }

    if (file.size > 104857600) {
      preview.classList.add("d-none");
      photoInput.value = ""; // reset input
      photoInput.classList.add("is-invalid");
      valid=false;
    }
    preview.src = URL.createObjectURL(file);
    preview.classList.remove("d-none");
    photoInput.classList.remove("is-invalid");
  } else {
    preview.classList.add("d-none");
    photoInput.classList.add("is-invalid");
  }
});




// Form Validation 
document.getElementById("regForm").addEventListener("submit", function (e) {
  e.preventDefault();//event listener
  let valid = true;

  const fname = document.getElementById("firstName");//variable
  const lname = document.getElementById("lastName");
  const email = document.getElementById("email");
  const pass = document.getElementById("password");
  const cpass = document.getElementById("confirmPassword");
  const address = document.getElementById("address");
  const website = document.getElementById("website");
  const dob = document.getElementById("dob");
  const ctime = document.getElementById("contactTime");
  const bmonth = document.getElementById("birthMonth");
  const search = document.getElementById("searches");
  const photo = document.getElementById("photo");
  const checkedHobbies = document.querySelectorAll(".hobby:checked");
  const checkedGender = document.querySelectorAll(".gender:checked");
  const efname=document.getElementById("Emptyfname");
  const elname=document.getElementById("Emptylname");
  const empty=document.getElementById("Emptyemail");
  const epass=document.getElementById("Emptypass");

  // First Name
  const nameRegex = /^[A-Za-z]{2,}$/;
  if(fname.value.trim()===""){
      fname.classList.add("is-invalid");
  efname.style.display = "block"; 
  fname.nextElementSibling.style.display = "none";
  valid = false;
  }
  else if (!nameRegex.test(fname.value.trim())) {
     fname.classList.add("is-invalid");
  efname.style.display = "none";
  fname.nextElementSibling.style.display = "block"; 
  valid = false;
  } else {
     fname.classList.remove("is-invalid");
  efname.style.display = "none";
  fname.nextElementSibling.style.display = "none";
  }

  // Last Name
   if(lname.value.trim()===""){
      lname.classList.add("is-invalid");
  elname.style.display = "block"; 
  lname.nextElementSibling.style.display = "none";
  valid = false;
  }
  else if (!nameRegex.test(lname.value.trim())) {
      lname.classList.add("is-invalid");
  elname.style.display = "none";
  lname.nextElementSibling.style.display = "block"; 
  valid = false;
  } else {
     lname.classList.remove("is-invalid");
  elname.style.display = "none";
  lname.nextElementSibling.style.display = "none";
  }

  // Email
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/;
  if(email.value.trim()===""){  
  email.classList.add("is-invalid");
  empty.style.display = "block"; 
  email.nextElementSibling.style.display = "none";
  valid = false;
  }else  if (!emailRegex.test(email.value) || !email.value.includes(".com")) {
     email.classList.add("is-invalid");
  empty.style.display = "none";
  email.nextElementSibling.style.display = "block"; 
  valid = false;
  } else {
  email.classList.remove("is-invalid");
  empty.style.display = "none";
  email.nextElementSibling.style.display = "none";
  }

  // Password

  let ipass = document.getElementById("Invalidpass");
  if (pass.value.trim() === "") {
    pass.classList.add("is-invalid");
    epass.style.display = "block";
    ipass.style.display = "none";
    valid = false;
  } else {
    let passPattern = /^(?=.*[A-Za-z])(?=.*[@#$%])[A-Za-z0-9@#$%]{6,20}$/;
  
    if (!passPattern.test(pass.value)) {
      pass.classList.add("is-invalid");
      epass.style.display = "none";
      ipass.style.display = "block";
      valid = false;
    } else {
      pass.classList.remove("is-invalid");
      epass.style.display = "none";
      ipass.style.display = "none";
    }
  }
  
  // Confirm Password
  if (pass.value !== cpass.value || !cpass.value) {
    cpass.focus();
    cpass.classList.add("is-invalid");
    valid = false;
  } else {
    cpass.classList.remove("is-invalid");
  }


  // Gender
 if (checkedGender.length === 0) {
  document.getElementById("genderWrapper").classList.add("is-invalid");
  genderError.style.display = "block";
  valid = false;
} else {
  document.getElementById("genderWrapper").classList.remove("is-invalid");
  genderError.style.display = "none";
}



  // Address
  if (!address.value.trim()) {
    address.focus();
    address.classList.add("is-invalid"); valid = false;
  } else {
    address.classList.remove("is-invalid");
  }

  // Country
  if (!country.value || country.value === "Select Country") {
    country.focus();
    country.classList.add("is-invalid"); valid = false;
  } else {
    country.classList.remove("is-invalid");
  }

  // State
  if (!state.value || state.value === "Select State") {
    state.focus();
    state.classList.add("is-invalid"); valid = false;
  } else {
    state.classList.remove("is-invalid");
  }

  // City
  if (!city.value || city.value === "Select City") {
    city.focus();
    city.classList.add("is-invalid"); valid = false;
  } else {
    city.classList.remove("is-invalid");
  }

  

const phone = document.getElementById("phone");
  const phoneCode = document.getElementById("phoneCode");
  const phoneError = document.getElementById("phoneError");
  const countryError = document.getElementById("countryError");
  const ephone=document.getElementById("Emptyphone");

  // Allow only digits in phone
  phone.addEventListener("input", function () {
    this.value = this.value.replace(/[^0-9]/g, ""); 
  });


    const phoneRegex = /^[0-9]{10}$/;
    const codeRegex = /^\+(91|55|61)$/; 

    if(phone.value.trim()===""){
    phone.classList.add("is-invalid");
    ephone.style.display = "block";
    countryError.style.display = "none";
    phoneError.style.display = "none";
    phoneCode.classList.remove("is-invalid");
    phoneCode.classList.remove("is-invalid");
    valid = false;
  }
    else if (!phoneRegex.test(phone.value.trim())) {
      phone.classList.add("is-invalid");
      phoneError.style.display = "block";
    countryError.style.display = "none";
    ephone.style.display = "none";
    phoneCode.classList.remove("is-invalid");
      valid = false;
     } 
    else if (!codeRegex.test(phoneCode.value.trim())) {
      phoneCode.classList.add("is-invalid");
      countryError.style.display = "block";
      ephone.style.display = "none";
       phone.classList.remove("is-invalid");
    phoneError.style.display = "none";
      valid = false;
    }
    else{
    phone.classList.remove("is-invalid");
    phoneError.style.display = "none";
    countryError.style.display = "none";
    phoneCode.classList.remove("is-invalid");
    }

   
  // DOB
  const today = new Date().toISOString().split("T")[0];//current(today) date show
  dob.max = today;
  
  if (!dob.value) {
    dob.focus();
    dob.classList.add("is-invalid");
    valid = false;
  } else if (dob.value > today) {
    dob.classList.add("is-invalid");
    valid = false;
  } else {
    dob.classList.remove("is-invalid");
  }

  // Website
  if (!website.value.startsWith("http")) {
    website.focus();
    website.classList.add("is-invalid"); valid = false;
  } else {
    website.classList.remove("is-invalid");
  }

  // Contact Time
  if (!ctime.value) {
    ctime.focus();
    ctime.classList.add("is-invalid"); valid = false;
  } else {
    ctime.classList.remove("is-invalid");
  }

  // Birth Month
  if (!bmonth.value) {
    bmonth.focus();
    bmonth.classList.add("is-invalid"); valid = false;
  } else {
    bmonth.classList.remove("is-invalid");
  }

  // Search
  if (!search.value.trim()) {
    search.focus();
    search.classList.add("is-invalid"); valid = false;
  } else {
    search.classList.remove("is-invalid");
  }

  // Hobbies
 
if (checkedHobbies.length === 0) {
  document.getElementById("hobbiesWrapper").classList.add("is-invalid");
  hobbiesError.style.display = "block";  
  valid = false;
} else {
  document.getElementById("hobbiesWrapper").classList.remove("is-invalid");
  hobbiesError.style.display = "none";   
}




  // Photo in this upload field
  if (!photo.files.length) {
    photo.focus();
    photo.classList.add("is-invalid"); valid = false;
  } else {
    photo.classList.remove("is-invalid");
  }

  // Final Submit
  if (valid) {
    window.location.href = "ErrorMsg.html";
  }
});


// reset form
document.getElementById("clearReg").addEventListener("click", () => {
  const form = document.getElementById("regForm");
  form.reset();

  form.querySelectorAll(".is-invalid").forEach(el => el.classList.remove("is-invalid"));

  form.querySelectorAll(".invalid-feedback, .text-danger, .custom-error").forEach(el => {
    el.style.display = "none";
  });

  state.innerHTML = '<option selected disabled>Select State</option>';
  city.innerHTML = '<option selected disabled>Select City</option>';
  cphone.value = "";

  preview.classList.add("d-none");
  preview.src = "";

  document.querySelectorAll(".gender, .hobby").forEach(el => (el.checked = false));

  document.getElementById("genderError").style.display = "none";
  document.getElementById("hobbiesError").style.display = "none";
});

