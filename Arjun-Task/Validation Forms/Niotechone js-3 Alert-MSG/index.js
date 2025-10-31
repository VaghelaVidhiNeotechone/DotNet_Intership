function validateForm() {
  let name = document.forms["myForm"]["fullName"].value;
  let email = document.forms["myForm"]["Email"].value;
  let pass = document.forms["myForm"]["password"].value;
  let cpass = document.forms["myForm"]["Cpassword"].value;
  let age = document.forms["myForm"]["Age"].value;
  let date = document.forms["myForm"]["birthDate"].value;
  let number = document.forms["myForm"]["phone"].value;
  let time = document.forms["myForm"]["birthTime"].value;
  let site = document.forms["myForm"]["url"].value;
  let con = document.forms["myForm"]["country"].value;
  let sta = document.forms["myForm"]["state"].value;
  let cit = document.forms["myForm"]["city"].value;
  let file = document.forms["myForm"]["myfile"].value;
  let ser = document.forms["myForm"]["search"].value;
  let genderOptions = document.getElementsByName("gender");
  let genderSelected = false;
  let marriedOptions = document.getElementsByName("marriedStatus");
  let marriedSelected = false;

  for (let i = 0; i < genderOptions.length; i++) {
    if (genderOptions[i].checked) {
      genderSelected = true;
      break;
    }
  }

  for (let i = 0; i < marriedOptions.length; i++) {
    if (marriedOptions[i].checked) {
      marriedSelected = true;
      break;
    }
  }

  var password = document.getElementById("Password").value;
  var confirmPassword = document.getElementById("ConfirmPassword").value;

  const upperCaseRegex = /[A-Z]/;
  const lowerCaseRegex = /[a-z]/;
  const numberRegex = /[0-9]/;
  const specialCharRegex = /[!@#$%^&*(),.?":{}|<>]/;

  if (name == "") {
    alert("Full Name must be filled out");
    return false;
  } else if (email == "") {
    alert("Email must be filled out");
    return false;
  } else if (password.length < 8) {
    alert("Password must be at least 8 characters long.");
    return false;
  } else if (
    !upperCaseRegex.test(password) ||
    !lowerCaseRegex.test(password) ||
    !numberRegex.test(password) ||
    !specialCharRegex.test(password)
  ) {
    let errorMessage = "";
    if (!upperCaseRegex.test(password))
      errorMessage += " one uppercase letter,";
    if (!lowerCaseRegex.test(password))
      errorMessage += " one lowercase letter,";
    if (!numberRegex.test(password)) errorMessage += " one number,";
    if (!specialCharRegex.test(password))
      errorMessage += " one special character";
    console.log(errorMessage);
    alert(`Password must include${errorMessage}.`);
    return false;
  } else if (confirmPassword == "") {
    alert("Confirm password must be filled out");
    return false;
  } else if (password !== confirmPassword) {
    alert("Passwords do not match!");
    return false;
  } else if (age == "") {
    alert("Age must be filled out");
    return false;
  } else if (date == "") {
    alert("BirthDate must be filled out");
    return false;
  } else if (number == "") {
    alert("Mobile Number must be filled out");
    return false;
  } else if (time == "") {
    alert("BirthTime must be filled out");
    return false;
  } else if (site == "") {
    alert("Url must be filled out");
    return false;
  } else if (con == "") {
    alert("Country must be filled out");
    return false;
  } else if (sta == "") {
    alert("State must be filled out");
    return false;
  } else if (cit == "") {
    alert("City must be filled out");
    return false;
  } else if (!genderSelected) {
    alert("Gender must be selected");
    return false;
  } else if (!marriedSelected) {
    alert("Married Status must be selected");
    return false;
  } else if (ser == "") {
    alert("Search must be filled out");
    return false;
  } else if (file == "") {
    alert("File must be filled out");
    return false;
  } else {
    alert("Form is success full submit");
  }
}

const data = {
  India: {
    Maharashtra: ["Mumbai", "Pune", "Nagpur"],
    Gujarat: ["Ahmedabad", "Surat", "Vadodara"],
    Karnataka: ["Bengaluru", "Mysuru", "Hubli"],
  },
  USA: {
    California: ["Los Angeles", "San Francisco", "San Diego"],
    Texas: ["Houston", "Dallas", "Austin"],
    "New York": ["New York City", "Buffalo", "Albany"],
  },
  UK: {
    England: ["London", "Manchester", "Liverpool"],
    Scotland: ["Edinburgh", "Glasgow", "Aberdeen"],
    Wales: ["Cardiff", "Swansea", "Newport"],
  },
};

function updateStates() {
  const country = document.getElementById("Country").value;
  const stateSelect = document.getElementById("State");
  const citySelect = document.getElementById("City");

  stateSelect.innerHTML = '<option value="">Select State</option>';
  citySelect.innerHTML = '<option value="">Select City</option>';

  if (country && data[country]) {
    const states = Object.keys(data[country]);
    states.forEach((state) => {
      let option = document.createElement("option");
      option.value = state;
      option.textContent = state;
      stateSelect.appendChild(option);
    });
  }
}

function updateCities() {
  const country = document.getElementById("Country").value;
  const state = document.getElementById("State").value;
  const citySelect = document.getElementById("City");

  citySelect.innerHTML = '<option value="">Select City</option>';

  if (country && state && data[country] && data[country][state]) {
    const cities = data[country][state];
    cities.forEach((city) => {
      let option = document.createElement("option");
      option.value = city;
      option.textContent = city;
      citySelect.appendChild(option);
    });
  }
}

const phoneCodes = {
  India: "+91",
  USA: "+1",
  UK: "+44",
};

function updatePhoneCode() {
  const country = document.getElementById("Country").value;
  const phoneSelect = document.getElementById("countryCode");

  if (country in phoneCodes) {
    phoneSelect.value = phoneCodes[country];
  } else {
    phoneSelect.value = "";
  }
}

window.onload = function () {
  const birthDateInput = document.getElementById("BirthDate");
  const today = new Date().toISOString().split("T")[0];
  birthDateInput.setAttribute("max", today);
};

function validateAndPreviewImage(event) {
  const fileInput = event.target;
  const file = fileInput.files[0];
  const imagePreview = document.getElementById("imagePreview");
  const fileError = document.getElementById("fileError");

  imagePreview.style.display = "none";
  fileError.style.display = "none";

  if (!file) {
    return;
  }

  const allowedTypes = [
    "image/jpeg",
    "image/png",
    "image/jpg",
    "image/gif",
    "image/webp",
  ];
  const maxSize = 5 * 1024 * 1024;

  if (!allowedTypes.includes(file.type)) {
    fileError.style.display = "block";
    fileInput.value = "";
    alert(
      "Invalid file type. Please upload a valid image file (PNG, JPG, JPEG, etc.)"
    );
    return;
  }

  if (file.size > maxSize) {
    fileError.style.display = "block";
    fileInput.value = "";
    alert("File size exceeds 5MB. Please upload a smaller image.");
    return;
  }

  const reader = new FileReader();
  reader.onload = function (e) {
    imagePreview.src = e.target.result;
    imagePreview.style.display = "block";
  };
  reader.readAsDataURL(file);
}

function validateLoginForm() {
  const email = document.getElementById("loginEmail").value.trim();
  const password = document.getElementById("loginPassword").value.trim();

  if (email === "") {
    alert("Email is required");
    return false;
  }

  if (password === "") {
    alert("Password is required");
    return false;
  }

  alert("Login successful!");
  return true;
}

function validatePasswords() {
  var password = document.getElementById("Password").value;
  var confirmPassword = document.getElementById("ConfirmPassword").value;

  if (password.length < 8) {
    alert("Password must be at least 8 characters long.");
    return false;
  }

  const upperCaseRegex = /[A-Z]/;
  const lowerCaseRegex = /[a-z]/;
  const numberRegex = /[0-9]/;
  const specialCharRegex = /[!@#$%^&*(),.?":{}|<>]/;

  if (!upperCaseRegex.test(password)) {
    alert("Password must include at least one uppercase letter.");
    return false;
  }

  if (!lowerCaseRegex.test(password)) {
    alert("Password must include at least one lowercase letter.");
    return false;
  }

  if (!numberRegex.test(password)) {
    alert("Password must include at least one number.");
    return false;
  }

  if (!specialCharRegex.test(password)) {
    alert("Password must include at least one special character.");
    return false;
  }

  if (password !== confirmPassword) {
    alert("Passwords do not match!");
    return false;
  }

}

function resetImagePreview() {
  const preview = document.getElementById("imagePreview");
  preview.src = "#";
  preview.style.display = "none";
  document.getElementById("MyFile").value = "";
}