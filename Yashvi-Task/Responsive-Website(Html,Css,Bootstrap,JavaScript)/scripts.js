  // Navbar Contact button scroll to #contact section
  document.getElementById("contactBtn").addEventListener("click", function () {
    document.getElementById("contact").scrollIntoView({
      behavior: "smooth",
      block: "start"
    });
  });
    document.getElementById("serviceBtn").addEventListener("click", function () {
    document.getElementById("service").scrollIntoView({
      behavior: "smooth",
      block: "start"
    });
  });
      document.getElementById("technologyBtn").addEventListener("click", function () {
    document.getElementById("technology").scrollIntoView({
      behavior: "smooth",
      block: "start"
    });
  });

    // Sidebar toggle
  function toggleSidebar() {
    document.getElementById("mySidebar").classList.toggle("sidebar-open");
  }

   // Dropdown toggle for sidebar
  document.querySelectorAll(".sidebar-dropbtn").forEach(btn => {
    btn.addEventListener("click", function () {
      this.nextElementSibling.classList.toggle("show");
    });
  });
  // Navbar scroll effect
  window.addEventListener('scroll', function() {
    document.querySelector('.navbar').classList.toggle('scrolled', window.scrollY > 50);
  });

  // Slideshow
  let slideIndex = 0;
  showSlides();

  function showSlides() {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    let dots = document.getElementsByClassName("dot");

    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }

    for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
    }

    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";

    setTimeout(showSlides, 3000); // change image every 3 seconds
  }

  function currentDiv(n) {
    slideIndex = n - 1;
    showSlides();
  }

  // Navbar blur + background on scroll
  window.addEventListener("scroll", function () {
    let navbar = document.querySelector(".navbar");
    if (window.scrollY > 50) {
      navbar.classList.add("scrolled");
    } else {
      navbar.classList.remove("scrolled");
    }
  });


  // contact form validation
  document.getElementById("contactForm").addEventListener("submit", function (e) {
  e.preventDefault();
  let isValid = true;

  // Clear old errors
  document.querySelectorAll(".error-message").forEach(el => el.textContent = "");

  // Name validation
  const name = document.getElementById("name");
  const nameValue = name.value.trim();
  if (nameValue === "") {
    name.nextElementSibling.textContent = "Name is required.";
    isValid = false;
  } else if (!/^[A-Za-z\s]+$/.test(nameValue)) {
    name.nextElementSibling.textContent = "Name can only contain letters and spaces.";
    isValid = false;
  }

  // Phone validation
  const phone = document.getElementById("phone");
  const phoneValue = phone.value.trim();
  if (phoneValue === "") {
    phone.nextElementSibling.textContent = "Phone number is required.";
    isValid = false;
  } else if (!/^[0-9]{10}$/.test(phoneValue)) {
    phone.nextElementSibling.textContent = "Enter a valid 10-digit phone number.";
    isValid = false;
  }

  // Email validation
  const email = document.getElementById("email");
  const emailValue = email.value.trim();
  const emailPattern = /^[^ ]+@[^ ]+\.[a-z]{2,}$/;
  if (emailValue === "") {
    email.nextElementSibling.textContent = "Email is required.";
    isValid = false;
  } else if (!emailPattern.test(emailValue)) {
    email.nextElementSibling.textContent = "Enter a valid email address (e.g. user@example.com).";
    isValid = false;
  }

  // Message validation
  const message = document.getElementById("message");
  const messageValue = message.value.trim();
  if (messageValue === "") {
    message.nextElementSibling.textContent = "Message is required.";
    isValid = false;
  } else if (messageValue.length < 10) {
    message.nextElementSibling.textContent = "Message must be at least 10 characters long.";
    isValid = false;
  }

  // Final check
  if (isValid) {
    alert("Form submitted successfully!");
    e.target.reset();
  }
});

  