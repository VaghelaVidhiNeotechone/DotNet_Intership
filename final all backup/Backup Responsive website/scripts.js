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

  