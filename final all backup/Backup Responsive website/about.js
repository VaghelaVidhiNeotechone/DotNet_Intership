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