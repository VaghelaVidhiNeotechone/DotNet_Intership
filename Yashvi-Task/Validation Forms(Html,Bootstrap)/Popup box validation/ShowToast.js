//create function
function showToast(message, field = null, type = "danger") {
  const container = document.getElementById("toastContainer");//variable
  const toast = document.createElement("div");
  toast.className = `toast align-items-center text-bg-${type.toLowerCase()} border-0 mb-2`;
  toast.role = "toast";
  toast.innerHTML = `
    <div class="d-flex">
      <div class="toast-body">${message}</div>
      <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
    </div>`;
  container.appendChild(toast);// method appends as the last child of an element.
  const bsToast = new bootstrap.Toast(toast, { delay: 3000 });
  bsToast.show();
  toast.addEventListener("hidden.bs.toast", () => toast.remove());//hidden toast message
  if (field) field.focus();
}

const loginForm = document.getElementById("loginForm");
if (loginForm) {
  const luser = document.getElementById("loginUsername");
  const lpass = document.getElementById("loginPassword");

  loginForm.addEventListener("submit", function (e) {
    e.preventDefault();//event listener one home page multiple form can logout how can that

    const nameRegex = /^[A-Za-z]+(?:\s[A-Za-z]+)*$/;
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (luser.value.trim()==="")
        return showToast("Please Enter User Name",luser);
        Valid=false;
    if (!(nameRegex.test(luser.value.trim()) || emailRegex.test(luser.value.trim()))) {
      return showToast("Enter a valid username (letters only) or a valid email.", luser);
    }
     let passPattern =/^(?=.*[A-Za-z])(?=.*[@#$%])[A-Za-z0-9@#$%]{6,20}$/;
      
      

    if (lpass.value.trim() === "") {
      Valid = false;
      return showToast("Please enter password", lpass);
    }
    
    if (!passPattern.test(lpass.value)) {
      Valid = false;
      return showToast("Password must include at least one special character.", lpass);
    }


    showToast("Login Successful!", null, "success");
    setTimeout(() => (window.location.href = "Toasthome.html"), 1500);
  });
}



    const locationData = {
      india: { gujarat: ["Ahmedabad", "Rajkot"], kerala: ["Kochi", "Trivandrum"] },
      brazil: { acre: ["Rio Branco"], amazonas: ["Manaus"] },
      us: { victoria: ["Melbourne", "Ballarat"], tasmania: ["Hobart", "Burnie"] }
    };

    const country = document.getElementById("country");
    const state = document.getElementById("state");
    const city = document.getElementById("city");
    const phone = document.getElementById("phone");
    const cphone=document.getElementById("phoneCode");
//when user can select satate use this function
    country.addEventListener("change", () => {
      state.innerHTML = '<option selected disabled>Select State</option>';
      city.innerHTML = '<option selected disabled>Select City</option>';
      const states = Object.keys(locationData[country.value]);
      states.forEach(s => state.innerHTML += `<option value="${s}">${s}</option>`);

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
      cities.forEach(c => city.innerHTML += `<option value="${c}">${c}</option>`);
    });

const photoInput = document.getElementById("photo");
const preview = document.getElementById("preview");

photoInput.addEventListener("change", () => {
  if (photoInput.files.length > 0) {
    const file = photoInput.files[0];

    const allowedTypes = ["image/jpeg", "image/jpg", "image/png"];
    if (!allowedTypes.includes(file.type)) {
      return showToast("Only PNG, JPG, or JPEG files are allowed.");
    }
    if (file.size > 104857600) {
      return showToast("File size must be under 100KB.");
    }
    preview.src = URL.createObjectURL(file);
    preview.classList.remove("d-none");

  } else {
    return showToast("Please upload a photo (PNG, JPG, JPEG, max 100KB).");
 
  }
});
    // Form Validation
    document.getElementById("regForm").addEventListener("submit", function (e) {
      e.preventDefault();

      const fname = document.getElementById("firstName");
      const lname = document.getElementById("lastName");
      const email = document.getElementById("email");
      const pass = document.getElementById("password");
      const cpass = document.getElementById("confirmPassword");
      const address = document.getElementById("address");
      const website = document.getElementById("website");
      const dob = document.getElementById("dob");
      const ctime = document.getElementById("contacttime");
      const bmonth = document.getElementById("birthmonth");
      const photo = document.getElementById("photo");
      const search=document.getElementById("searches");
      const hobbies = document.querySelectorAll(".hobby:checked");
      const genders = document.querySelectorAll(".gender:checked");

      //reguler Expression 
      const nameRegex = /^[A-Za-z]{2,}$/;
      //first name
      if (fname.value.trim()==="")
        return showToast("Please Enter First Name",fname);
        Valid =false;
      if (!nameRegex.test(fname.value.trim()))
        return showToast("First name must contain only letters.",fname);


      //last name
      if (lname.value.trim()==="")
        return showToast("Please Enter Last Name",lname);
        Valid = false;
      if (!nameRegex.test(lname.value.trim()))
        return showToast("Last Name must contain only letters.",lname);

       //email address
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/;
      if (email.value.trim()==="")
        return showToast("Please Enter Your Email Address",email);
        Valid = false;
      if (!emailRegex.test(email.value) || !email.value.includes(".com"))
        return showToast("Enter a valid email (must include @ and .com).",email);

       //password
      if (pass.value.trim() === "") {
        Valid = false;
        return showToast("Please enter password", pass);
      }
      if (pass.value.length < 6 || pass.value.length > 8) {
        Valid = false;
        return showToast("Password must be 6 to 8 characters long.", pass);
      }
      if (!/[!@#$%^&*(),.?":{}|<>]/.test(pass.value)) {
        Valid = false;
        return showToast("Password must include at least one special character.", pass);
      }
      if (pass.value !== cpass.value) {
        Valid = false;
        return showToast("Passwords do not match.", cpass);
      }


       //gender
      if (genders.length === 0)
        return showToast("Please select gender.");

       //address
      if (!address.value.trim())
        return showToast("Please enter your address.",address);

       //country
      if (country.value === "Select Country")
        return showToast("Please select a country.",country);

       //state
      if (state.value === "Select State")
        return showToast("Please select a state.",state);

       //city
      if (city.value === "Select City")
        return showToast("Please select a city.",city);

      //phone
   
      
      const phoneRegex = /^[0-9]{10}$/;
      if (phone.value.trim()==="") {
        return showToast("Please Enter Phone Number", phone);
      }
      if (!phoneRegex.test(phone.value.trim())) {
        return showToast("Enter a valid 10-digit phone number.", phone);
      }

          
const codeRegex = /^\+(91|55|61)$/;
    if (phoneRegex.test(phone.value.trim()) && !codeRegex.test(cphone.value.trim())) {
      cphone.focus();
      return showToast("Please display country code ");
      
    } 


     // DOB
      const today = new Date().toISOString().split("T")[0];
      dob.max = today;
      if (!dob.value) {
        return showToast("Select a valid date of birth", dob);
      } else if (dob.value > today) {
        return showToast("Date of birth cannot be in the future", dob);
      } 

       //Url
      if (!website.value.startsWith("http"))
        return showToast("Enter a valid website URL (must start with http).",website);

       //Contact time
      if (!ctime.value)
        return showToast("Enter a valid contact time.",ctime);

       //birth month
      if (!bmonth.value)
        return showToast("Enter a valid birth month.",bmonth);

       //hobbies
      if (hobbies.length === 0)
        return showToast("Select at least one hobby.");

       //photo
      if (!photo.value)
        return showToast("Please upload File",photo);

      if(!search.value)
        return showToast("Please search something.");

      // Success
      showToast("Registration Successful!", null, "success");
setTimeout(() => window.location.href = "ShowToast.html", 2000);
    });



    // reset form
document.getElementById("clearReg").addEventListener("click", () => {
  const form = document.getElementById("regForm");
  form.reset();

  form.querySelectorAll(".is-invalid").forEach(el => el.classList.remove("is-invalid"));

  state.innerHTML = '<option selected disabled>Select State</option>';
  city.innerHTML = '<option selected disabled>Select City</option>';
  cphone.value = "";

  preview.classList.add("d-none");
  preview.src = "";

  document.querySelectorAll(".gender, .hobby").forEach(el => (el.checked = false));

  const container = document.getElementById("toastContainer");
  if (container) {
    container.innerHTML = ""; // clear all toasts from DOM
  }

  showToast("Form has been reset!", null, "info");
}); 