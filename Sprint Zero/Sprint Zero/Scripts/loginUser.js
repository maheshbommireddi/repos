function logInFailed() {
    var logOff = document.getElementById("LogOff");
    if (logOff.style.display === "none") {
        logOff.style.display = "block";
    } else {
        logOff.style.display = "none";
    }
}