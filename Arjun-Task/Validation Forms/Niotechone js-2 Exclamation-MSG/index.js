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

  function showError(id, condition) {
    const element = document.getElementById(id);
    if (condition) {
      element.classList.add("is-invalid");
      isValid = false;
    } else {
      element.classList.remove("is-invalid");
    }
  }

  showError(
    "fullName",
    document.getElementById("fullName").value.trim() === ""
  );
  showError(
    "regEmail",
    document.getElementById("regEmail").value.trim() === ""
  );
  showError(
    "regPassword",
    document.getElementById("regPassword").value.trim() === ""
  );
  showError(
    "confirmPassword",
    document.getElementById("confirmPassword").value.trim() === ""
  );
  showError("age", document.getElementById("age").value.trim() === "");
  showError(
    "birthDate",
    document.getElementById("birthDate").value.trim() === ""
  );
  showError(
    "countryCode",
    document.getElementById("countryCode").value.trim() === ""
  );
  showError("phone", document.getElementById("phone").value.trim() === "");
  showError(
    "birthTime",
    document.getElementById("birthTime").value.trim() === ""
  );
  showError("url", document.getElementById("url").value.trim() === "");
  showError("Country", document.getElementById("Country").value.trim() === "");
  showError("State", document.getElementById("State").value.trim() === "");
  showError("City", document.getElementById("City").value.trim() === "");
  showError("MyFile", document.getElementById("MyFile").files.length === 0);

  const gender = document.querySelector('input[name="gender"]:checked');
  const genderError = document.getElementById("genderError");
  if (!gender) {
    genderError.style.color = "red";
    genderError.style.display = "block";
    isValid = false;
  } else {
    genderError.style.display = "none";
  }

  const marital = document.querySelectorAll('input[name="marital"]:checked');
  const maritalError = document.getElementById("maritalError");
  if (marital.length === 0) {
    maritalError.style.color = "red";
    maritalError.style.display = "block";
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

  const countryCode = document.getElementById("countryCode").value.trim();
  const phone = document.getElementById("phone").value.trim();
  const phoneError = document.getElementById("phoneError");

  if (countryCode === "" || phone === "") {
    phoneError.style.display = "block";
    phoneError.style.color = "red";
    return false;
  }

  const phoneRegex = /^[0-9]{7,15}$/;
  if (!phoneRegex.test(phone)) {
    phoneError.style.display = "block";
    phoneError.style.color = "red";
    phoneError.textContent =
      "Enter a valid phone number (only digits, 7-15 characters).";
    return false;
  }

  phoneError.style.display = "none";
  return true;
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
      isValid = false;
    }

    if (!isValid) {
      e.preventDefault();
    }
  });
});

document.addEventListener("DOMContentLoaded", function () {
  const passwordInput = document.getElementById("regPassword");
  const confirmPasswordInput = document.getElementById("confirmPassword");
  const confirmPasswordError = document.getElementById("confirmPasswordError");

  function validatePasswords() {
    if (passwordInput.value !== confirmPasswordInput.value) {
      confirmPasswordInput.classList.add("is-invalid");
    } else {
      confirmPasswordInput.classList.remove("is-invalid");
      confirmPasswordError.textContent = "";
    }
  }

  confirmPasswordInput.addEventListener("input", validatePasswords);
  passwordInput.addEventListener("input", validatePasswords);
});


function resetImagePreview() {
    const preview = document.getElementById('imagePreview');
    preview.src = '#';
    preview.style.display = 'none';
    document.getElementById('MyFile').value = '';
}
