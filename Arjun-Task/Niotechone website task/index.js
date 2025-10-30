document.addEventListener("DOMContentLoaded", () => {
    const slider = document.querySelector(".logo-slider-track");

    slider.addEventListener("mouseenter", () => {
      slider.style.animationPlayState = "paused";
    });

    slider.addEventListener("mouseleave", () => {
      slider.style.animationPlayState = "running";
    });
  });


  document.addEventListener("DOMContentLoaded", () => {
    const cards = document.querySelectorAll(".box");

    const observer = new IntersectionObserver((entries, observer) => {
      entries.forEach((entry, i) => {
        if (entry.isIntersecting) {
          setTimeout(() => {
            entry.target.classList.add("animate");
          }, i * 200); 
          observer.unobserve(entry.target);
        }
      });
    }, {
      threshold: 0.2
    });

    cards.forEach(card => observer.observe(card));
  });




  document.addEventListener("DOMContentLoaded", () => {
  const cards = document.querySelectorAll('.card-box');

  const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
      if (entry.isIntersecting) {
        entry.target.classList.add('animate');
        observer.unobserve(entry.target);
      }
    });
  }, {
    threshold: 0.2
  });

  cards.forEach(card => observer.observe(card));
});






document.addEventListener("DOMContentLoaded", () => {
  const observerOptions = {
    threshold: 0.2,
  };

  const revealOnScroll = (entries, observer) => {
    entries.forEach((entry) => {
      if (entry.isIntersecting) {
        entry.target.classList.add("animate");
        observer.unobserve(entry.target);
      }
    });
  };

  const observer = new IntersectionObserver(revealOnScroll, observerOptions);

  // Observe blog cards and others
  document.querySelectorAll(".blog-card, .box, .card-box").forEach((el) => {
    observer.observe(el);
  });
});


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
    showToast("Full Name must be filled out", "bg-danger");
    return false;
  } else if (email == "") {
    showToast("Email must be filled out", "bg-danger");
    return false;
  } else if (password.length < 8) {
    showToast("Password must be at least 8 characters long.", "bg-danger");
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
    showToast(`Password must include${errorMessage}.`, "bg-danger");
    return false;
  } else if (confirmPassword == "") {
    showToast("Confirm password must be filled out", "bg-danger");
    return false;
  } else if (password !== confirmPassword) {
    showToast("Passwords do not match!", "bg-danger");
    return false;
  } else if (age == "") {
    showToast("Age must be filled out", "bg-danger");
    return false;
  } else if (date == "") {
    showToast("BirthDate must be filled out", "bg-danger");
    return false;
  } else if (number == "") {
    showToast("Mobile Number must be filled out", "bg-danger");
    return false;
  } else if (time == "") {
    showToast("BirthTime must be filled out", "bg-danger");
    return false;
  } else if (site == "") {
    showToast("Url must be filled out", "bg-danger");
    return false;
  } else if (con == "") {
    showToast("Country must be filled out", "bg-danger");
    return false;
  } else if (sta == "") {
    showToast("State must be filled out", "bg-danger");
    return false;
  } else if (cit == "") {
    showToast("City must be filled out", "bg-danger");
    return false;
  } else if (!genderSelected) {
    showToast("Gender must be selected", "bg-danger");
    return false;
  } else if (!marriedSelected) {
    showToast("Married Status must be selected", "bg-danger");
    return false;
  } else if (ser == "") {
    showToast("Search must be filled out", "bg-danger");
    return false;
  } else if (file == "") {
    showToast("File must be filled out", "bg-danger");
    return false;
  } else {
    showToast("Form is success full submit", "bg-success");
  }
}

function showToast(message, color = "bg-primary") {
  const toastEl = document.getElementById("liveToast");
  const toastBody = document.getElementById("toastMessage");

  toastBody.innerText = message;
  toastEl.className = `toast align-items-center text-white ${color} border-0`;

  const toast = new bootstrap.Toast(toastEl);
  toast.show();
}

const data = {
  India: {
    Gujarat: ["Ahmedabad", "Rajkot", "Surat"],
    Maharashtra: ["Mumbai", "Pune", "Nagpur"],
  },
  USA: {
    California: ["Los Angeles", "San Francisco"],
    Texas: ["Houston", "Dallas"],
  },
  UK: {
    England: ["London", "Manchester"],
    Scotland: ["Edinburgh", "Glasgow"],
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
    showToast(
      "Invalid file type. Please upload a valid image file (PNG, JPG, JPEG, etc.)",
      "bg-danger"
    );
    return;
  }

  if (file.size > maxSize) {
    fileError.style.display = "block";
    fileInput.value = "";
    showToast(
      "File size exceeds 5MB. Please upload a smaller image.",
      "bg-danger"
    );
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
    showToast("Email must be filled out", "bg-danger");
    return false;
  } else if (password === "") {
    showToast("Password must be filled out", "bg-danger");
    return false;
  }

  showToast("Login successful", "bg-success");
  return true;
} 

function validatePasswords() {
  var password = document.getElementById("Password").value;
  var confirmPassword = document.getElementById("ConfirmPassword").value;

  if (password !== confirmPassword) {
    showToast("Passwords do not match!", "bg-danger");
    return false;
  }
  
}

function resetImagePreview() {
  const preview = document.getElementById("imagePreview");
  preview.src = "#";
  preview.style.display = "none";
  document.getElementById("MyFile").value = "";
}