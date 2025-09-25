  const loginForm = document.getElementById("loginForm");//variable
  const luser = document.getElementById("loginUsername");
  const lpass = document.getElementById("loginPassword");

  loginForm.addEventListener("submit", function (e) {
    e.preventDefault();//event listener 
    let valid = true;

    const nameRegex = /^[A-Za-z]+(?:\s[A-Za-z]+)*$/; //reguler Expression
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    // Username or Email 
    if (!(nameRegex.test(luser.value.trim()) || emailRegex.test(luser.value.trim()))) {
      luser.classList.add("is-invalid");
      valid = false;
    } else {
      luser.classList.remove("is-invalid");
    }

    // Password 
    if (lpass.value.trim().length < 6) {
      lpass.classList.add("is-invalid");
      valid = false;
    }
    else {
  let passPattern = /^(?=.*[^A-Za-z0-9]).{6,8}$/;

  if (!passPattern.test(lpass.value)) {
    lpass.classList.add("is-invalid");
    valid = false;
  } else {
    lpass.classList.remove("is-invalid");
    
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

// Photo Preview
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
      return;
    }

    if (file.size > 104857600) {
      preview.classList.add("d-none");
      photoInput.value = ""; // reset input
      photoInput.classList.add("is-invalid");
      return;
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

      //variable
      const fname = document.getElementById("firstName");
      const lname = document.getElementById("lastName");
      const email = document.getElementById("email");
      const pass = document.getElementById("password");
      const cpass = document.getElementById("confirmPassword");
      const address = document.getElementById("address");
      const website = document.getElementById("website");
      const dob = document.getElementById("dob");
      const ctime=document.getElementById("contacttime");
      const bmonth=document.getElementById("birthmonth");
     // const satisfaction=document.getElementById("satisfactionRange");
      const search=document.getElementById("searches"); 
      const photo = document.getElementById("photo");
      const hobbyGroup = document.querySelector(".hobby-group");
      const checkedHobbies = document.querySelectorAll(".hobby:checked");
      const genderGroup = document.querySelector(".gender-group");
      const checkedGender = document.querySelectorAll(".gender:checked");

      //fname,lname
      const nameRegex = /^[A-Za-z]{2,}$/;
      if (!nameRegex.test(fname.value.trim())) { 
        fname.focus();
        fname.classList.add("is-invalid"); valid = false;
       } 
       else {
         fname.classList.remove("is-invalid");
         }
      if (!nameRegex.test(lname.value.trim())) {
         lname.focus();
         lname.classList.add("is-invalid"); valid = false;
         }
          else { 
          lname.classList.remove("is-invalid");
         }

         //email
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/;
      if (!emailRegex.test(email.value) || !email.value.includes(".com")) {
         email.focus();
         email.classList.add("is-invalid"); valid = false; 
        } 
        else {
           email.classList.remove("is-invalid"); 
          }

          //pass,confirmpass
      
      if (pass.value.trim() === "") {
        pass.classList.add("is-invalid");
        valid = false;
      } else {
        let passPattern = /^(?=.*[^A-Za-z0-9]).{6,8}$/;
      
        if (!passPattern.test(pass.value)) {
          pass.classList.add("is-invalid");
          valid = false;
        } else {
          pass.classList.remove("is-invalid");
        }
      }

      if (pass.value !== cpass.value || !cpass.value) { 
        cpass.focus();
        cpass.classList.add("is-invalid"); valid = false;
       }
        else {
         cpass.classList.remove("is-invalid");
         }

      if (checkedGender.length === 0) {
          genderGroup.classList.add("is-invalid");
          valid = false;
      } else {
          genderGroup.classList.remove("is-invalid");
      }

         //address
      if (!address.value.trim()) {
        address.focus();
        address.classList.add("is-invalid"); valid = false;
       } 
       else {
         address.classList.remove("is-invalid");
         }

         //country
      if (country.value === "Select Country") {
        country.focus();
         country.classList.add("is-invalid"); valid = false;
         }
          else { 
          country.classList.remove("is-invalid");
         }

         //state
      if (state.value === "Select State") {
         state.focus();
         state.classList.add("is-invalid"); valid = false;
         } 
         else { 
          state.classList.remove("is-invalid");
         }

         //city
      if (city.value === "Select City") {
         city.focus();
         city.classList.add("is-invalid"); valid = false; 
        }
         else { 
          city.classList.remove("is-invalid"); 
        }

  // Phone
  // Prevent letters (allow only digits, +, and space)
  phone.addEventListener("input", function () {
    this.value = this.value.replace(/[^0-9+\s]/g, ""); // remove letters
  });

  const phoneRegex = /^[0-9]{10}$/;
    if (!phoneRegex.test(phone.value.trim())) {
      phone.focus();
      phone.classList.add("is-invalid");
      valid = false;
    } else {
      phone.classList.remove("is-invalid");
    }

    // Phone
  phone.addEventListener("input", function () {
    this.value = this.value.replace(/[^0-9+\s]/g, ""); // remove letters
  });

  
const codeRegex = /^\+(91|55|61)$/;
    if (phoneRegex.test(phone.value.trim()) && !codeRegex.test(cphone.value.trim())) {
      cphone.classList.add("is-invalid");
      valid = false;
    } else {
      cphone.classList.remove("is-invalid");
    }
    
      // DOB
         const today = new Date().toISOString().split("T")[0];
      dob.max = today;
      if (!dob.value) {
        dob.classList.add("is-invalid");
        valid = false;
      } else if (dob.value > today) {
        dob.classList.add("is-invalid");
        valid = false;
      } else {
        dob.classList.remove("is-invalid");
      }

      //Url
      if (!website.value.startsWith("http")) { 
        website.focus();
        website.classList.add("is-invalid"); valid = false;
       }
        else { 
        website.classList.remove("is-invalid");
       }

       //ctime
      if(!ctime.value){
        ctime.focus();
        ctime.classList.add("is-invalid");valid=false;
      }
      else{
        ctime.classList.remove("is-invalid");
      }

      //bmonth
      if(!bmonth.value){
        bmonth.focus();
        bmonth.classList.add("is-invalid"); valid=false;
      }
      else{
        bmonth.classList.remove("is-invalid");
      }


      //if(!satisfaction.value){
      //  satisfaction.classList.add("is-invalid");valid=false;
      //}else{
      //  satisfaction.classList.remove("is-invalid");
      //}


    //search
      if(!search.value){
        search.focus();
        search.classList.add("is-invalid");
      }
      else{
        search.classList.remove("is-invalid");
      }

      //hobbies
      if (checkedHobbies.length === 0) {
          hobbyGroup.classList.add("is-invalid");
          valid = false;
      } else {
          hobbyGroup.classList.remove("is-invalid");
      }



         //upload PHoto
      if (!photo.value) { 
        photo.focus();
        photo.classList.add("is-invalid"); valid = false; 
      } 
      else {
         photo.classList.remove("is-invalid");
         }

      if (valid) 
        { window.location.href="ExclamationMark.html" }
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
