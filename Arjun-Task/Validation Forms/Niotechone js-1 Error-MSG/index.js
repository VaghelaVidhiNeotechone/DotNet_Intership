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
  fileInput.classList.remove("is-invalid");

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
    fileError.textContent =
      "Only image files (PNG, JPG, JPEG, etc.) are allowed.";
    fileError.style.display = "block";
    fileInput.classList.add("is-invalid");
    fileInput.value = ""; 
    return;
  }

  if (file.size > maxSize) {
    fileError.textContent = "Maximum file size is 5MB.";
    fileError.style.display = "block";
    fileInput.classList.add("is-invalid");
    fileInput.value = ""; 
    return;
  }

  const reader = new FileReader();
  reader.onload = function (e) {
    imagePreview.src = e.target.result;
    imagePreview.style.display = "block";
  };
  reader.readAsDataURL(file);
}

function validateForm() {
  let isValid = true;

  function showError(inputId, condition, errorId, errorMsg) {
    const input = document.getElementById(inputId);
    const error = errorId ? document.getElementById(errorId) : null;

    if (condition) {
      input.classList.add("is-invalid");
      if (error) {
        error.style.display = "block";
        error.textContent = errorMsg || "This field is required";
      }
      isValid = false;
    } else {
      input.classList.remove("is-invalid");
      if (error) error.style.display = "none";
    }
  }

  showError("fullName", document.getElementById("fullName").value.trim() === "", "fullNameError", "Full Name is required");
  showError("regEmail", document.getElementById("regEmail").value.trim() === "", null);
  showError("age", document.getElementById("age").value.trim() === "", "ageError");
  showError("birthDate", document.getElementById("birthDate").value.trim() === "", "birthDateError");
  showError("Country", document.getElementById("Country").value.trim() === "", null);
  showError("State", document.getElementById("State").value.trim() === "", null);
  showError("City", document.getElementById("City").value.trim() === "", null);
  showError("birthTime", document.getElementById("birthTime").value.trim() === "", null);
  showError("url", document.getElementById("url").value.trim() === "", "urlError");

  const password = document.getElementById("regPassword").value.trim();
  showError("regPassword", password === "", "regPasswordError", "Password is required");

  const confirmPassword = document.getElementById("confirmPassword").value.trim();
  showError("confirmPassword", confirmPassword === "", "confirmPasswordError", "Confirm Password is required");

  const passwordMatchMsg = document.getElementById("Message");
  if (password && confirmPassword) {
    if (password !== confirmPassword) {
      passwordMatchMsg.innerHTML = "Passwords do NOT match!";
      passwordMatchMsg.style.color = "red";
      isValid = false;
    } else {
      passwordMatchMsg.innerHTML = "Passwords match!";
      passwordMatchMsg.style.color = "green";
    }
  }

  const phone = document.getElementById("phone").value.trim();
  const code = document.getElementById("countryCode").value.trim();
  const phoneError = document.getElementById("phoneError");

  if (!code || !phone) {
    phoneError.style.display = "block";
    phoneError.textContent = "Please select country code and enter your phone number.";
    phoneError.style.color = "red";
    isValid = false;
  } else {
    const phoneRegex = /^[0-9]{7,15}$/;
    if (!phoneRegex.test(phone)) {
      phoneError.style.display = "block";
      phoneError.textContent = "Enter a valid phone number (only digits, 7-15 characters).";
      phoneError.style.color = "red";
      isValid = false;
    } else {
      phoneError.style.display = "none";
    }
  }

  const fileInput = document.getElementById("MyFile");
  const fileError = document.getElementById("fileError");
  const allowedTypes = ['image/jpeg', 'image/png', 'image/jpg'];

  if (fileInput.files.length === 0) {
    fileInput.classList.add("is-invalid");
    fileError.style.display = "block";
    fileError.textContent = "Please upload an image file.";
    isValid = false;
  } else if (!allowedTypes.includes(fileInput.files[0].type)) {
    fileInput.classList.add("is-invalid");
    fileError.style.display = "block";
    fileError.textContent = "Only PNG, JPG, and JPEG files are allowed.";
    isValid = false;
  } else {
    fileInput.classList.remove("is-invalid");
    fileError.style.display = "none";
  }

  const gender = document.querySelector('input[name="gender"]:checked');
  const genderError = document.getElementById("genderError");
  if (!gender) {
    genderError.style.display = "block";
    genderError.style.color = "red";
    isValid = false;
  } else {
    genderError.style.display = "none";
  }

  const marital = document.querySelectorAll('input[name="marital"]:checked');
  const maritalError = document.getElementById("maritalError");
  if (marital.length === 0) {
    maritalError.style.display = "block";
    maritalError.style.color = "red";
    isValid = false;
  } else {
    maritalError.style.display = "none";
  }

  return isValid;
}

function validateSearch() {
  const searchInput = document.getElementById("search");
  const errorMsg = searchInput.nextElementSibling;

  if (searchInput.value.trim() === "") {
    errorMsg.style.display = "block";
    searchInput.classList.add("is-invalid");
  } else {
    errorMsg.style.display = "none";
    searchInput.classList.remove("is-invalid");
  }

  return validateForm();
}

document.addEventListener("DOMContentLoaded", function () {
  const loginForm = document.getElementById("loginForm");
  const loginEmail = document.getElementById("loginEmail");
  const loginPassword = document.getElementById("loginPassword");
  const loginPasswordError = document.getElementById("loginPasswordError");

  loginForm.addEventListener("submit", function (e) {
    let isValid = true;

    loginEmail.classList.remove("is-invalid");
    loginPassword.classList.remove("is-invalid");

    if (loginEmail.value.trim() === "") {
      loginEmail.classList.add("is-invalid");
      isValid = false;
    }

    if (loginPassword.value.trim() === "") {
      loginPassword.classList.add("is-invalid");
      loginPasswordError.textContent = "Password is required";
      isValid = false;
    }

    if (!isValid) e.preventDefault();
  });
});

function passConfirm() {
  const password = document.getElementById("regPassword").value;
  const confirmPassword = document.getElementById("confirmPassword").value;
  const message = document.getElementById("Message");

  if (!password && !confirmPassword) {
    message.innerHTML = "";
    return;
  }

  if (password === confirmPassword) {
    message.style.color = "green";
    message.innerHTML = "Passwords match!";
  } else {
    message.style.color = "red";
    message.innerHTML = "Passwords do NOT match!";
  }
}

function resetImagePreview() {
  const preview = document.getElementById("imagePreview");
  preview.src = "#";
  preview.style.display = "none";
  document.getElementById("MyFile").value = "";
}

function validateAndPreviewImage(event) {
  const file = event.target.files[0];
  const preview = document.getElementById("imagePreview");
  const fileError = document.getElementById("fileError");

  if (!file) {
    preview.style.display = "none";
    fileError.style.display = "block";
    fileError.textContent = "No file selected.";
    return;
  }

  const validTypes = ["image/png", "image/jpeg", "image/jpg"];
  if (!validTypes.includes(file.type)) {
    preview.style.display = "none";
    fileError.style.display = "block";
    fileError.textContent = "Only image files (PNG, JPG, JPEG) are allowed.";
    return;
  }

  fileError.style.display = "none";
  const reader = new FileReader();
  reader.onload = function (e) {
    preview.src = e.target.result;
    preview.style.display = "block";
  };
  reader.readAsDataURL(file);
}