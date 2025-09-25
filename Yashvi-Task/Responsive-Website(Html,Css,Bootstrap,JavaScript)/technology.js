    document.getElementById("frontendBtn").addEventListener("click", function () {
    document.getElementById("frontend").scrollIntoView({
      behavior: "smooth",
      block: "start"
    });
  });

      document.getElementById("backendBtn").addEventListener("click", function () {
    document.getElementById("backend").scrollIntoView({
      behavior: "smooth",
      block: "start"
    });
  });

       document.getElementById("mobileBtn").addEventListener("click", function () {
    document.getElementById("mobile").scrollIntoView({
      behavior: "smooth",
      block: "start"
    });
  });

       document.getElementById("databaseBtn").addEventListener("click", function () {
    document.getElementById("database").scrollIntoView({
      behavior: "smooth",
      block: "start"
    });
  });

      document.getElementById("testingBtn").addEventListener("click", function () {
    document.getElementById("testing").scrollIntoView({
      behavior: "smooth",
      block: "start"
    });
  });

//   // Map button IDs to their target section IDs
// const scrollMap = {
//   frontendBtn: "frontend",
//   backendBtn: "backend",
//   mobileBtn: "mobile",
//   databaseBtn: "database",
//   testingBtn: "testing"
// };

// // Loop through each button → section mapping
// Object.entries(scrollMap).forEach(([btnId, targetId]) => {
//   const btn = document.getElementById(btnId);
//   const target = document.getElementById(targetId);

//   if (btn && target) {
//     btn.addEventListener("click", () => {
//       target.scrollIntoView({
//         behavior: "smooth",
//         block: "start"
//       });
//     });
//   }
// });
